using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Créer un bon de commande » et « Suivre les commandes »
    public partial class FormCommandes : Form
    {
        // Ligne de commande affichée dans la petite grille (avant enregistrement)
        public class LigneVue
        {
            public int ArticleId { get; set; }
            public string Article { get; set; }
            public int Quantite { get; set; }
            public decimal PrixUnitaire { get; set; }
            public decimal Montant { get { return Quantite * PrixUnitaire; } }
        }

        private int _id;            // 0 = nouveau bon de commande
        private bool _chargement;
        private readonly BindingList<LigneVue> _lignes = new BindingList<LigneVue>();

        public FormCommandes()
        {
            InitializeComponent();
        }

        private void FormCommandes_Load(object sender, EventArgs e)
        {
            _chargement = true;

            cboStatut.DataSource = Enum.GetValues(typeof(StatutCommande));

            using (var db = new GestionAchatsContext())
            {
                var fournisseurs = db.Fournisseurs.AsNoTracking().OrderBy(f => f.Nom)
                    .Select(f => new { f.Id, f.Nom, f.Actif }).ToList();
                Outils.Remplir(cboFournisseur,
                    fournisseurs.Select(f => new Choix(f.Id, f.Nom + (f.Actif ? "" : " (inactif)"))).ToList());

                var users = db.Utilisateurs.AsNoTracking().OrderBy(u => u.Nom)
                    .Select(u => new { u.Id, u.Nom, u.Role }).ToList();
                Outils.Remplir(cboAcheteur,
                    users.Where(u => u.Role == Role.Acheteur || u.Role == Role.ResponsableAchats || u.Role == Role.Administrateur)
                         .Select(u => new Choix(u.Id, u.Nom + " (" + u.Role + ")")).ToList());

                var articles = db.Articles.AsNoTracking().OrderBy(a => a.Reference)
                    .Select(a => new { a.Id, a.Reference, a.Designation }).ToList();
                Outils.Remplir(cboArticleLigne,
                    articles.Select(a => new Choix(a.Id, a.Reference + " - " + a.Designation)).ToList());
            }

            dgvLignes.DataSource = _lignes;
            dgvLignes.Columns["ArticleId"].Visible = false;
            dgvLignes.Columns["Article"].HeaderText = "Article";
            dgvLignes.Columns["Quantite"].HeaderText = "Quantité";
            Outils.FormatMontant(dgvLignes, "PrixUnitaire", "Prix unitaire");
            Outils.FormatMontant(dgvLignes, "Montant", "Montant");

            _chargement = false;
            ChargerListe();
        }

        // ---------- READ : liste ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();
            bool seulementRetard = chkRetard.Checked;

            using (var db = new GestionAchatsContext())
            {
                List<CommandeAchat> commandes = db.Commandes.AsNoTracking()
                    .Include(c => c.Fournisseur)
                    .Include(c => c.Acheteur)
                    .ToList();

                var liste = commandes
                    .Where(c => Outils.Contient(c.Fournisseur.Nom, filtre) && (!seulementRetard || c.EstEnRetard()))
                    .OrderByDescending(c => c.Id)
                    .Select(c => new
                    {
                        c.Id,
                        c.DateCommande,
                        Fournisseur = c.Fournisseur.Nom,
                        Acheteur = c.Acheteur.Nom,
                        c.DateLivraisonPrevue,
                        c.DateLivraisonReelle,
                        c.Statut,
                        c.MontantTotal,
                        EnRetard = c.EstEnRetard() ? "Oui" : "Non"
                    })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].HeaderText = "N° BC";
                Outils.FormatDate(dgv, "DateCommande", "Date commande");
                Outils.FormatDate(dgv, "DateLivraisonPrevue", "Livraison prévue");
                Outils.FormatDate(dgv, "DateLivraisonReelle", "Livraison réelle");
                Outils.FormatMontant(dgv, "MontantTotal", "Montant total");
                dgv.Columns["EnRetard"].HeaderText = "En retard";

                foreach (DataGridViewRow ligne in dgv.Rows)
                {
                    if ((string)ligne.Cells["EnRetard"].Value == "Oui")
                        ligne.DefaultCellStyle.ForeColor = Color.Firebrick;
                }

                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Fournisseur");
                _chargement = false;
            }

            int id = Outils.IdCourant(dgv);
            if (id != 0)
                Afficher(id);
            else
                Nouvelle();
        }

        private void Afficher(int id)
        {
            using (var db = new GestionAchatsContext())
            {
                CommandeAchat c = db.Commandes.AsNoTracking().Include(x => x.Lignes).FirstOrDefault(x => x.Id == id);
                if (c == null)
                {
                    Nouvelle();
                    return;
                }

                Dictionary<int, string> articles = db.Articles.AsNoTracking().ToList()
                    .ToDictionary(a => a.Id, a => a.Reference + " - " + a.Designation);

                _chargement = true;
                _id = c.Id;
                Outils.Choisir(cboFournisseur, c.FournisseurId);
                Outils.Choisir(cboAcheteur, c.AcheteurId);
                Outils.FixerDate(dtpCommande, c.DateCommande);
                Outils.FixerDate(dtpPrevue, c.DateLivraisonPrevue);
                cboStatut.SelectedItem = c.Statut;
                chkLivree.Checked = c.DateLivraisonReelle.HasValue;
                dtpReelle.Enabled = chkLivree.Checked;
                if (c.DateLivraisonReelle.HasValue)
                    Outils.FixerDate(dtpReelle, c.DateLivraisonReelle.Value);
                else
                    dtpReelle.Value = DateTime.Today;

                _lignes.Clear();
                foreach (LigneCommande l in c.Lignes)
                {
                    LigneVue v = new LigneVue();
                    v.ArticleId = l.ArticleId;
                    v.Article = articles.ContainsKey(l.ArticleId) ? articles[l.ArticleId] : "?";
                    v.Quantite = l.Quantite;
                    v.PrixUnitaire = l.PrixUnitaire;
                    _lignes.Add(v);
                }
                _chargement = false;
            }
            grpDetails.Text = "Modifier le bon de commande BC-" + id;
            btnSupprimer.Enabled = true;
            MajTotal();
        }

        private void Nouvelle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;

            _id = 0;
            cboFournisseur.SelectedIndex = cboFournisseur.Items.Count > 0 ? 0 : -1;
            cboAcheteur.SelectedIndex = cboAcheteur.Items.Count > 0 ? 0 : -1;
            dtpCommande.Value = DateTime.Today;
            dtpPrevue.Value = DateTime.Today.AddDays(7);
            cboStatut.SelectedItem = StatutCommande.Brouillon;
            chkLivree.Checked = false;
            dtpReelle.Enabled = false;
            dtpReelle.Value = DateTime.Today;
            _lignes.Clear();
            _chargement = false;

            grpDetails.Text = "Nouveau bon de commande";
            btnSupprimer.Enabled = false;
            MajTotal();
        }

        private void MajTotal()
        {
            decimal total = _lignes.Sum(l => l.Montant);
            lblTotal.Text = "Montant total : " + Outils.Montant(total);
        }

        // ---------- Événements ----------
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            int id = Outils.IdCourant(dgv);
            if (id != 0)
                Afficher(id);
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerListe();
        }

        private void chkRetard_CheckedChanged(object sender, EventArgs e)
        {
            ChargerListe();
        }

        private void chkLivree_CheckedChanged(object sender, EventArgs e)
        {
            dtpReelle.Enabled = chkLivree.Checked;
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouvelle();
        }

        // ---------- Lignes de commande ----------
        private void btnAjouterLigne_Click(object sender, EventArgs e)
        {
            int idArticle = Outils.Valeur(cboArticleLigne);
            if (idArticle == 0)
            {
                Outils.Alerte("Choisissez un article.");
                return;
            }
            if (nudQteLigne.Value < 1)
            {
                Outils.Alerte("La quantité doit être au moins 1.");
                return;
            }
            if (nudPrixLigne.Value <= 0)
            {
                Outils.Alerte("Le prix unitaire doit être supérieur à 0.");
                nudPrixLigne.Focus();
                return;
            }
            if (_lignes.Any(l => l.ArticleId == idArticle))
            {
                Outils.Alerte("Cet article est déjà dans la commande. Retirez la ligne existante pour la remplacer.");
                return;
            }

            LigneVue v = new LigneVue();
            v.ArticleId = idArticle;
            v.Article = ((Choix)cboArticleLigne.SelectedItem).Libelle;
            v.Quantite = (int)nudQteLigne.Value;
            v.PrixUnitaire = nudPrixLigne.Value;
            _lignes.Add(v);
            MajTotal();
        }

        private void btnRetirerLigne_Click(object sender, EventArgs e)
        {
            if (dgvLignes.CurrentRow == null)
            {
                Outils.Alerte("Sélectionnez la ligne à retirer.");
                return;
            }
            _lignes.RemoveAt(dgvLignes.CurrentRow.Index);
            MajTotal();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int idFournisseur = Outils.Valeur(cboFournisseur);
            int idAcheteur = Outils.Valeur(cboAcheteur);
            StatutCommande statut = (StatutCommande)cboStatut.SelectedItem;

            if (idFournisseur == 0)
            {
                Outils.Alerte("Choisissez le fournisseur.");
                return;
            }
            if (idAcheteur == 0)
            {
                Outils.Alerte("Choisissez l'acheteur.");
                return;
            }
            if (_lignes.Count == 0)
            {
                Outils.Alerte("Un bon de commande doit contenir au moins une ligne.");
                return;
            }
            if (dtpPrevue.Value.Date < dtpCommande.Value.Date)
            {
                Outils.Alerte("La livraison prévue ne peut pas être avant la date de commande.");
                return;
            }
            if (chkLivree.Checked && dtpReelle.Value.Date < dtpCommande.Value.Date)
            {
                Outils.Alerte("La livraison réelle ne peut pas être avant la date de commande.");
                return;
            }
            if (statut == StatutCommande.Livree && !chkLivree.Checked)
            {
                Outils.Alerte("Pour le statut « Livree », cochez « Livrée le » et indiquez la date.");
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    CommandeAchat c;
                    if (_id == 0)
                    {
                        c = new CommandeAchat();                 // CREATE
                        db.Commandes.Add(c);
                    }
                    else
                    {
                        c = db.Commandes.Find(_id);              // UPDATE
                        if (c == null)
                        {
                            Outils.Erreur("Ce bon de commande n'existe plus.");
                            ChargerListe();
                            return;
                        }

                        // On remplace les anciennes lignes par celles de l'écran
                        List<LigneCommande> anciennes = db.LignesCommande.Where(l => l.CommandeId == _id).ToList();
                        db.LignesCommande.RemoveRange(anciennes);
                    }

                    c.FournisseurId = idFournisseur;
                    c.AcheteurId = idAcheteur;
                    c.DateCommande = dtpCommande.Value.Date;
                    c.DateLivraisonPrevue = dtpPrevue.Value.Date;
                    c.DateLivraisonReelle = chkLivree.Checked ? (DateTime?)dtpReelle.Value.Date : null;
                    c.Statut = statut;

                    decimal total = 0;
                    foreach (LigneVue v in _lignes)
                    {
                        LigneCommande l = new LigneCommande();
                        l.Commande = c;
                        l.ArticleId = v.ArticleId;
                        l.Quantite = v.Quantite;
                        l.PrixUnitaire = v.PrixUnitaire;
                        db.LignesCommande.Add(l);
                        total += l.Montant;
                    }
                    c.MontantTotal = total;

                    db.SaveChanges();
                    ChargerListe(c.Id);
                }
                Outils.Info("Bon de commande enregistré.");
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Erreur lors de l'enregistrement :\n" + Outils.Detail(ex));
            }
        }

        // ---------- DELETE ----------
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_id == 0)
                return;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    CommandeAchat c = db.Commandes.Find(_id);
                    if (c == null)
                    {
                        ChargerListe();
                        return;
                    }

                    bool aReceptions = db.Receptions.Any(r => r.CommandeId == _id);
                    bool supprimable = !aReceptions
                                       && (c.Statut == StatutCommande.Brouillon || c.Statut == StatutCommande.Annulee);

                    if (!supprimable)
                    {
                        string message = "Le bon de commande BC-" + _id + " est déjà engagé (statut " + c.Statut
                                         + (aReceptions ? ", réceptions enregistrées" : "") + ") : il ne peut pas être supprimé.";

                        bool annulable = c.Statut != StatutCommande.Annulee && c.Statut != StatutCommande.Cloturee
                                         && c.Statut != StatutCommande.Livree;
                        if (annulable)
                        {
                            if (Outils.Confirmer(message + "\n\nVoulez-vous l'annuler à la place ?"))
                            {
                                c.Statut = StatutCommande.Annulee;
                                db.SaveChanges();
                                ChargerListe(c.Id);
                            }
                        }
                        else
                        {
                            Outils.Alerte(message);
                        }
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer définitivement le bon de commande BC-" + _id + " ?"))
                        return;

                    db.Commandes.Remove(c);
                    db.SaveChanges();
                }
                ChargerListe();
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Suppression impossible :\n" + Outils.Detail(ex));
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
