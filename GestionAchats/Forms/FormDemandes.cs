using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Faire une demande d'achat » (Demandeur)
    public partial class FormDemandes : Form
    {
        private int _id;            // 0 = nouvelle demande
        private bool _chargement;

        public FormDemandes()
        {
            InitializeComponent();
        }

        private void FormDemandes_Load(object sender, EventArgs e)
        {
            cboStatut.DataSource = Enum.GetValues(typeof(StatutDemande));

            using (var db = new GestionAchatsContext())
            {
                var users = db.Utilisateurs.AsNoTracking().OrderBy(u => u.Nom)
                    .Select(u => new { u.Id, u.Nom, u.Role }).ToList();
                Outils.Remplir(cboDemandeur, users.Select(u => new Choix(u.Id, u.Nom + " (" + u.Role + ")")).ToList());

                var articles = db.Articles.AsNoTracking().OrderBy(a => a.Reference)
                    .Select(a => new { a.Id, a.Reference, a.Designation }).ToList();
                Outils.Remplir(cboArticle, articles.Select(a => new Choix(a.Id, a.Reference + " - " + a.Designation)).ToList());
            }

            ChargerListe();
        }

        // ---------- READ ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                var toutes = db.Demandes.AsNoTracking()
                    .Select(d => new
                    {
                        d.Id,
                        d.DateDemande,
                        Demandeur = d.Demandeur.Nom,
                        Article = d.Article.Designation,
                        d.Quantite,
                        d.DateSouhaitee,
                        d.Statut,
                        NbOffres = d.Offres.Count
                    })
                    .OrderByDescending(d => d.Id)
                    .ToList();

                var liste = toutes
                    .Where(d => Outils.Contient(d.Demandeur, filtre) || Outils.Contient(d.Article, filtre))
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                Outils.FormatDate(dgv, "DateDemande", "Date de demande");
                Outils.FormatDate(dgv, "DateSouhaitee", "Date souhaitée");
                dgv.Columns["Quantite"].HeaderText = "Quantité";
                dgv.Columns["NbOffres"].HeaderText = "Offres reçues";
                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Demandeur");
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
                DemandeAchat d = db.Demandes.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (d == null)
                {
                    Nouvelle();
                    return;
                }

                _id = d.Id;
                Outils.Choisir(cboDemandeur, d.DemandeurId);
                Outils.Choisir(cboArticle, d.ArticleId);
                Outils.Fixer(nudQuantite, d.Quantite);
                Outils.FixerDate(dtpDemande, d.DateDemande);
                Outils.FixerDate(dtpSouhaitee, d.DateSouhaitee);
                cboStatut.SelectedItem = d.Statut;
            }
            grpDetails.Text = "Modifier la demande d'achat";
            btnSupprimer.Enabled = true;
        }

        private void Nouvelle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            cboDemandeur.SelectedIndex = cboDemandeur.Items.Count > 0 ? 0 : -1;
            cboArticle.SelectedIndex = cboArticle.Items.Count > 0 ? 0 : -1;
            Outils.Fixer(nudQuantite, 1);
            dtpDemande.Value = DateTime.Today;
            dtpSouhaitee.Value = DateTime.Today.AddDays(15);
            cboStatut.SelectedItem = StatutDemande.EnAttente;
            grpDetails.Text = "Nouvelle demande d'achat";
            btnSupprimer.Enabled = false;
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

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouvelle();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int idDemandeur = Outils.Valeur(cboDemandeur);
            int idArticle = Outils.Valeur(cboArticle);

            if (idDemandeur == 0)
            {
                Outils.Alerte("Choisissez le demandeur.");
                return;
            }
            if (idArticle == 0)
            {
                Outils.Alerte("Choisissez l'article demandé.");
                return;
            }
            if (nudQuantite.Value < 1)
            {
                Outils.Alerte("La quantité doit être au moins 1.");
                return;
            }
            if (dtpSouhaitee.Value.Date < dtpDemande.Value.Date)
            {
                Outils.Alerte("La date souhaitée ne peut pas être avant la date de la demande.");
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    DemandeAchat d;
                    if (_id == 0)
                    {
                        d = new DemandeAchat();              // CREATE
                        db.Demandes.Add(d);
                    }
                    else
                    {
                        d = db.Demandes.Find(_id);           // UPDATE
                        if (d == null)
                        {
                            Outils.Erreur("Cette demande n'existe plus.");
                            ChargerListe();
                            return;
                        }
                    }

                    d.DemandeurId = idDemandeur;
                    d.ArticleId = idArticle;
                    d.Quantite = (int)nudQuantite.Value;
                    d.DateDemande = dtpDemande.Value.Date;
                    d.DateSouhaitee = dtpSouhaitee.Value.Date;
                    d.Statut = (StatutDemande)cboStatut.SelectedItem;

                    db.SaveChanges();
                    ChargerListe(d.Id);
                }
                Outils.Info("Demande d'achat enregistrée.");
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
                    DemandeAchat d = db.Demandes.Find(_id);
                    if (d == null)
                    {
                        ChargerListe();
                        return;
                    }

                    if (db.Offres.Any(o => o.DemandeId == _id))
                    {
                        Outils.Alerte("Cette demande a déjà reçu des offres : elle ne peut pas être supprimée.\n\n"
                                      + "Vous pouvez la passer au statut « Refusee » à la place.");
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer définitivement cette demande d'achat ?"))
                        return;

                    db.Demandes.Remove(d);
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
