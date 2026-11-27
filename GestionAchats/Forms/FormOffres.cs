using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Saisir les offres », « Comparer les offres » (score multicritère),
    // « Valider le choix fournisseur » et « Créer un bon de commande »
    public partial class FormOffres : Form
    {
        private int _id;            // 0 = nouvelle offre
        private bool _chargement;
        private Dictionary<int, int> _quantites = new Dictionary<int, int>();   // Id demande -> quantité demandée

        public FormOffres()
        {
            InitializeComponent();
        }

        private void FormOffres_Load(object sender, EventArgs e)
        {
            _chargement = true;
            ChargerCombos();
            _chargement = false;
            ChargerListe();
        }

        private void ChargerCombos()
        {
            using (var db = new GestionAchatsContext())
            {
                // Demandes
                var demandes = db.Demandes.AsNoTracking()
                    .Select(d => new { d.Id, Article = d.Article.Designation, d.Quantite, Demandeur = d.Demandeur.Nom, d.Statut })
                    .OrderByDescending(d => d.Id)
                    .ToList();

                _quantites = demandes.ToDictionary(d => d.Id, d => d.Quantite);

                List<Choix> choixDemandes = demandes
                    .Select(d => new Choix(d.Id, "DA-" + d.Id + " : " + d.Article + " x" + d.Quantite + " (" + d.Demandeur + ", " + d.Statut + ")"))
                    .ToList();

                List<Choix> filtre = new List<Choix>();
                filtre.Add(new Choix(0, "(Toutes les demandes)"));
                filtre.AddRange(choixDemandes);

                Outils.Remplir(cboFiltreDemande, filtre);
                Outils.Remplir(cboDemande, new List<Choix>(choixDemandes));

                // Fournisseurs
                var fournisseurs = db.Fournisseurs.AsNoTracking().OrderBy(f => f.Nom)
                    .Select(f => new { f.Id, f.Nom, f.Actif }).ToList();
                Outils.Remplir(cboFournisseur,
                    fournisseurs.Select(f => new Choix(f.Id, f.Nom + (f.Actif ? "" : " (inactif)"))).ToList());

                // Acheteurs (pour la création du bon de commande)
                var users = db.Utilisateurs.AsNoTracking().OrderBy(u => u.Nom)
                    .Select(u => new { u.Id, u.Nom, u.Role }).ToList();
                Outils.Remplir(cboAcheteur,
                    users.Where(u => u.Role == Role.Acheteur || u.Role == Role.ResponsableAchats || u.Role == Role.Administrateur)
                         .Select(u => new Choix(u.Id, u.Nom + " (" + u.Role + ")")).ToList());
            }
        }

        // ---------- READ ----------
        private void ChargerListe(int idSelection = 0)
        {
            int idDemandeFiltre = Outils.Valeur(cboFiltreDemande);

            using (var db = new GestionAchatsContext())
            {
                IQueryable<Offre> requete = db.Offres.AsNoTracking();
                if (idDemandeFiltre != 0)
                    requete = requete.Where(o => o.DemandeId == idDemandeFiltre);

                // Demande (quantité) et Fournisseur chargés pour calculer le coût total en mémoire
                List<Offre> offres = requete.Include(o => o.Demande).Include(o => o.Fournisseur).ToList();

                var liste = offres
                    .OrderBy(o => o.DemandeId).ThenByDescending(o => o.Score)
                    .Select(o => new
                    {
                        o.Id,
                        Demande = "DA-" + o.DemandeId,
                        Fournisseur = o.Fournisseur.Nom,
                        o.PrixUnitaire,
                        Remise = o.Remise,
                        Transport = o.FraisTransport,
                        Delai = o.DelaiJours,
                        CoutTotal = o.CalculerCoutTotal(),
                        Score = Math.Round(o.Score, 1)
                    })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Demande"].HeaderText = "Demande";
                Outils.FormatMontant(dgv, "PrixUnitaire", "Prix unitaire");
                dgv.Columns["Remise"].HeaderText = "Remise (%)";
                Outils.FormatMontant(dgv, "Transport", "Transport");
                dgv.Columns["Delai"].HeaderText = "Délai (jours)";
                Outils.FormatMontant(dgv, "CoutTotal", "Coût total");
                dgv.Columns["Score"].HeaderText = "Score /100";

                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Fournisseur");

                // Après une comparaison, la meilleure offre (1re ligne) est mise en évidence
                if (idDemandeFiltre != 0 && dgv.Rows.Count > 0 && liste.Count > 0 && liste[0].Score > 0)
                    dgv.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
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
                Offre o = db.Offres.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (o == null)
                {
                    Nouvelle();
                    return;
                }

                _id = o.Id;
                Outils.Choisir(cboDemande, o.DemandeId);
                Outils.Choisir(cboFournisseur, o.FournisseurId);
                Outils.Fixer(nudPrix, o.PrixUnitaire);
                Outils.Fixer(nudDelai, o.DelaiJours);
                Outils.Fixer(nudRemise, o.Remise);
                Outils.Fixer(nudTransport, o.FraisTransport);
            }
            grpDetails.Text = "Modifier l'offre";
            btnSupprimer.Enabled = true;
            MajCout();
        }

        private void Nouvelle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            int idFiltre = Outils.Valeur(cboFiltreDemande);
            if (idFiltre != 0)
                Outils.Choisir(cboDemande, idFiltre);
            else
                cboDemande.SelectedIndex = cboDemande.Items.Count > 0 ? 0 : -1;
            cboFournisseur.SelectedIndex = cboFournisseur.Items.Count > 0 ? 0 : -1;
            Outils.Fixer(nudPrix, 0);
            Outils.Fixer(nudDelai, 7);
            Outils.Fixer(nudRemise, 0);
            Outils.Fixer(nudTransport, 0);
            grpDetails.Text = "Nouvelle offre";
            btnSupprimer.Enabled = false;
            MajCout();
        }

        // Coût total = prix net x quantité demandée + transport (même formule que Offre.CalculerCoutTotal)
        private void MajCout()
        {
            int quantite = 0;
            int idDemande = Outils.Valeur(cboDemande);
            if (idDemande != 0 && _quantites.ContainsKey(idDemande))
                quantite = _quantites[idDemande];

            decimal prixNet = nudPrix.Value * (1 - nudRemise.Value / 100m);
            decimal cout = prixNet * quantite + nudTransport.Value;
            lblCoutTotal.Text = "Coût total : " + Outils.Montant(cout);
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

        private void cboFiltreDemande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            ChargerListe();
        }

        private void cboDemande_SelectedIndexChanged(object sender, EventArgs e)
        {
            MajCout();
        }

        private void nudCout_ValueChanged(object sender, EventArgs e)
        {
            MajCout();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouvelle();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int idDemande = Outils.Valeur(cboDemande);
            int idFournisseur = Outils.Valeur(cboFournisseur);

            if (idDemande == 0)
            {
                Outils.Alerte("Choisissez la demande d'achat concernée.");
                return;
            }
            if (idFournisseur == 0)
            {
                Outils.Alerte("Choisissez le fournisseur.");
                return;
            }
            if (nudPrix.Value <= 0)
            {
                Outils.Alerte("Le prix unitaire doit être supérieur à 0.");
                nudPrix.Focus();
                return;
            }
            if (nudDelai.Value < 1)
            {
                Outils.Alerte("Le délai doit être d'au moins 1 jour.");
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    Fournisseur f = db.Fournisseurs.FirstOrDefault(x => x.Id == idFournisseur);
                    if (f == null || !f.Actif)
                    {
                        Outils.Alerte("Ce fournisseur est inactif : on ne peut pas saisir d'offre à son nom.");
                        return;
                    }

                    if (db.Offres.Any(x => x.DemandeId == idDemande && x.FournisseurId == idFournisseur && x.Id != _id))
                    {
                        Outils.Alerte("Ce fournisseur a déjà une offre pour cette demande. Modifiez l'offre existante.");
                        return;
                    }

                    Offre o;
                    if (_id == 0)
                    {
                        o = new Offre();                     // CREATE
                        db.Offres.Add(o);
                    }
                    else
                    {
                        o = db.Offres.Find(_id);             // UPDATE
                        if (o == null)
                        {
                            Outils.Erreur("Cette offre n'existe plus.");
                            ChargerListe();
                            return;
                        }
                    }

                    o.DemandeId = idDemande;
                    o.FournisseurId = idFournisseur;
                    o.PrixUnitaire = nudPrix.Value;
                    o.DelaiJours = (int)nudDelai.Value;
                    o.Remise = nudRemise.Value;
                    o.FraisTransport = nudTransport.Value;
                    o.Score = 0;        // le score devra être recalculé avec « Comparer les offres »

                    db.SaveChanges();
                    ChargerListe(o.Id);
                }
                Outils.Info("Offre enregistrée.");
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
                    Offre o = db.Offres.Find(_id);
                    if (o == null)
                    {
                        ChargerListe();
                        return;
                    }

                    if (db.Commandes.Any(c => c.OffreRetenueId == _id))
                    {
                        Outils.Alerte("Cette offre a donné lieu à un bon de commande : elle ne peut pas être supprimée.");
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer définitivement cette offre ?"))
                        return;

                    db.Offres.Remove(o);
                    db.SaveChanges();
                }
                ChargerListe();
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Suppression impossible :\n" + Outils.Detail(ex));
            }
        }

        // ---------- Comparer les offres (score multicritère) ----------
        private void btnComparer_Click(object sender, EventArgs e)
        {
            int idDemande = Outils.Valeur(cboFiltreDemande);
            if (idDemande == 0)
            {
                Outils.Alerte("Choisissez d'abord une demande dans la liste « Demande » en haut de l'écran.");
                return;
            }

            double poidsPrix = (double)nudPoidsPrix.Value;
            double poidsDelai = (double)nudPoidsDelai.Value;
            double poidsFiab = (double)nudPoidsFiab.Value;
            if (poidsPrix + poidsDelai + poidsFiab <= 0)
            {
                Outils.Alerte("Au moins un des poids doit être supérieur à 0.");
                return;
            }

            int idMeilleure;
            string message;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    List<Offre> offres = db.Offres
                        .Include(o => o.Demande)
                        .Include(o => o.Fournisseur)
                        .Where(o => o.DemandeId == idDemande)
                        .ToList();

                    if (offres.Count == 0)
                    {
                        Outils.Info("Cette demande n'a encore reçu aucune offre.");
                        return;
                    }

                    // Les évaluations sont chargées pour que Fournisseur.CalculerNote() fonctionne (critère fiabilité)
                    List<int> idsFournisseurs = offres.Select(o => o.FournisseurId).Distinct().ToList();
                    db.Evaluations.Where(ev => idsFournisseurs.Contains(ev.FournisseurId)).ToList();

                    List<Offre> classees = Offre.ClasserOffres(offres, poidsPrix, poidsDelai, poidsFiab);
                    db.SaveChanges();   // le score est enregistré dans la base

                    idMeilleure = classees[0].Id;
                    message = "Meilleure offre : " + classees[0].Fournisseur.Nom
                              + " (score " + Math.Round(classees[0].Score, 1) + " / 100).";
                }
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Erreur lors du calcul :\n" + Outils.Detail(ex));
                return;
            }

            ChargerListe(idMeilleure);
            Outils.Info(message);
        }

        // ---------- Valider le choix et créer le bon de commande ----------
        private void btnCreerCommande_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                Outils.Alerte("Sélectionnez d'abord une offre dans la liste.");
                return;
            }

            int idAcheteur = Outils.Valeur(cboAcheteur);
            if (idAcheteur == 0)
            {
                Outils.Alerte("Choisissez l'acheteur qui crée le bon de commande.");
                return;
            }

            int idCommande;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    if (db.Commandes.Any(c => c.OffreRetenueId == _id))
                    {
                        Outils.Info("Un bon de commande existe déjà pour cette offre.");
                        return;
                    }

                    Offre o = db.Offres.Include(x => x.Demande).FirstOrDefault(x => x.Id == _id);
                    if (o == null || o.Demande == null)
                    {
                        Outils.Erreur("Offre introuvable.");
                        return;
                    }

                    if (!Outils.Confirmer("Créer un bon de commande à partir de cette offre ?\n\n"
                                          + "La demande DA-" + o.DemandeId + " passera au statut « Traitee »."))
                        return;

                    decimal prixNet = Math.Round(o.PrixUnitaire * (1 - o.Remise / 100m), 3);

                    CommandeAchat commande = new CommandeAchat();
                    commande.AcheteurId = idAcheteur;
                    commande.FournisseurId = o.FournisseurId;
                    commande.OffreRetenueId = o.Id;
                    commande.DateCommande = DateTime.Today;
                    commande.DateLivraisonPrevue = DateTime.Today.AddDays(o.DelaiJours);
                    commande.Statut = StatutCommande.Brouillon;

                    LigneCommande ligne = new LigneCommande();
                    ligne.ArticleId = o.Demande.ArticleId;
                    ligne.Quantite = o.Demande.Quantite;
                    ligne.PrixUnitaire = prixNet;
                    commande.Lignes.Add(ligne);
                    commande.RecalculerMontantTotal();

                    o.Demande.Statut = StatutDemande.Traitee;

                    db.Commandes.Add(commande);
                    db.SaveChanges();
                    idCommande = commande.Id;
                }
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Erreur lors de la création du bon de commande :\n" + Outils.Detail(ex));
                return;
            }

            Outils.Info("Bon de commande BC-" + idCommande + " créé (statut Brouillon).\n"
                        + "Vous le retrouvez dans le menu Achats > Commandes.");
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
