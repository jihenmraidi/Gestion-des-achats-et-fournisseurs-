using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Enregistrer une réception » (Magasinier)
    public partial class FormReceptions : Form
    {
        private int _id;            // 0 = nouvelle réception
        private bool _chargement;

        public FormReceptions()
        {
            InitializeComponent();
        }

        private void FormReceptions_Load(object sender, EventArgs e)
        {
            _chargement = true;
            ChargerCommandes();
            _chargement = false;
            ChargerListe();
        }

        // Commandes sur lesquelles une réception a un sens (ni brouillon, ni annulée)
        private void ChargerCommandes()
        {
            using (var db = new GestionAchatsContext())
            {
                var commandes = db.Commandes.AsNoTracking()
                    .Select(c => new { c.Id, Fournisseur = c.Fournisseur.Nom, c.Statut })
                    .ToList();

                List<Choix> choix = commandes
                    .Where(c => c.Statut != StatutCommande.Brouillon && c.Statut != StatutCommande.Annulee)
                    .OrderByDescending(c => c.Id)
                    .Select(c => new Choix(c.Id, "BC-" + c.Id + " | " + c.Fournisseur + " | " + c.Statut))
                    .ToList();

                Outils.Remplir(cboCommande, choix);
            }
        }

        // ---------- READ ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                var brutes = db.Receptions.AsNoTracking()
                    .Select(r => new
                    {
                        r.Id,
                        r.CommandeId,
                        Fournisseur = r.Commande.Fournisseur.Nom,
                        r.DateReception,
                        r.QuantiteRecue,
                        r.Conforme,
                        r.Remarque
                    })
                    .OrderByDescending(r => r.Id)
                    .ToList();

                var liste = brutes
                    .Where(r => Outils.Contient(r.Fournisseur, filtre) || Outils.Contient("BC-" + r.CommandeId, filtre))
                    .Select(r => new
                    {
                        r.Id,
                        Commande = "BC-" + r.CommandeId,
                        r.Fournisseur,
                        r.DateReception,
                        r.QuantiteRecue,
                        r.Conforme,
                        r.Remarque
                    })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                Outils.FormatDate(dgv, "DateReception", "Date de réception");
                dgv.Columns["QuantiteRecue"].HeaderText = "Quantité reçue";
                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Commande");
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
                Reception r = db.Receptions.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (r == null)
                {
                    Nouvelle();
                    return;
                }

                _id = r.Id;
                Outils.Choisir(cboCommande, r.CommandeId);
                Outils.FixerDate(dtpReception, r.DateReception);
                Outils.Fixer(nudQuantite, r.QuantiteRecue);
                chkConforme.Checked = r.Conforme;
                txtRemarque.Text = r.Remarque;
            }
            cboCommande.Enabled = false;    // on ne change pas la commande d'une réception existante
            grpDetails.Text = "Modifier la réception";
            btnSupprimer.Enabled = true;
            MajInfo();
        }

        private void Nouvelle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            cboCommande.Enabled = true;
            cboCommande.SelectedIndex = cboCommande.Items.Count > 0 ? 0 : -1;
            dtpReception.Value = DateTime.Today;
            Outils.Fixer(nudQuantite, 1);
            chkConforme.Checked = true;
            txtRemarque.Clear();
            grpDetails.Text = "Nouvelle réception";
            btnSupprimer.Enabled = false;
            MajInfo();
        }

        // Affiche : quantité commandée, déjà reçue, reste à recevoir
        private void MajInfo()
        {
            int idCommande = Outils.Valeur(cboCommande);
            if (idCommande == 0)
            {
                lblInfo.Text = "Commandé : 0   |   Déjà reçu : 0   |   Reste : 0";
                return;
            }

            using (var db = new GestionAchatsContext())
            {
                int commande = db.LignesCommande.Where(l => l.CommandeId == idCommande)
                    .Select(l => l.Quantite).ToList().Sum();
                int recu = db.Receptions.Where(r => r.CommandeId == idCommande)
                    .Select(r => r.QuantiteRecue).ToList().Sum();
                lblInfo.Text = "Commandé : " + commande + "   |   Déjà reçu : " + recu
                               + "   |   Reste : " + Math.Max(0, commande - recu);
            }
        }

        // Met à jour le statut de la commande d'après les réceptions enregistrées
        private static void RecalculerStatut(GestionAchatsContext db, int idCommande)
        {
            CommandeAchat c = db.Commandes.FirstOrDefault(x => x.Id == idCommande);
            if (c == null)
                return;
            if (c.Statut == StatutCommande.Annulee || c.Statut == StatutCommande.Cloturee || c.Statut == StatutCommande.Brouillon)
                return;

            int commande = db.LignesCommande.Where(l => l.CommandeId == idCommande)
                .Select(l => l.Quantite).ToList().Sum();
            List<Reception> receptions = db.Receptions.Where(r => r.CommandeId == idCommande).ToList();
            int recu = receptions.Sum(r => r.QuantiteRecue);

            if (receptions.Count == 0)
            {
                if (c.Statut == StatutCommande.Livree || c.Statut == StatutCommande.PartiellementLivree)
                    c.Statut = StatutCommande.Confirmee;
                c.DateLivraisonReelle = null;
            }
            else if (commande > 0 && recu >= commande)
            {
                c.Statut = StatutCommande.Livree;
                c.DateLivraisonReelle = receptions.Max(r => r.DateReception).Date;
            }
            else
            {
                c.Statut = StatutCommande.PartiellementLivree;
                c.DateLivraisonReelle = null;
            }
            db.SaveChanges();
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

        private void cboCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            MajInfo();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouvelle();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int idCommande = Outils.Valeur(cboCommande);
            if (idCommande == 0)
            {
                Outils.Alerte("Choisissez la commande concernée.");
                return;
            }
            if (nudQuantite.Value < 1)
            {
                Outils.Alerte("La quantité reçue doit être au moins 1.");
                return;
            }

            string message = null;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    CommandeAchat cmd = db.Commandes.FirstOrDefault(x => x.Id == idCommande);
                    if (cmd == null)
                    {
                        Outils.Erreur("Cette commande n'existe plus.");
                        return;
                    }
                    if (_id == 0 && (cmd.Statut == StatutCommande.Cloturee || cmd.Statut == StatutCommande.Annulee
                                     || cmd.Statut == StatutCommande.Brouillon))
                    {
                        Outils.Alerte("On ne peut pas enregistrer de réception sur une commande au statut « " + cmd.Statut + " ».");
                        return;
                    }
                    if (dtpReception.Value.Date < cmd.DateCommande.Date)
                    {
                        Outils.Alerte("La date de réception ne peut pas être avant la date de la commande.");
                        return;
                    }

                    // Alerte si on reçoit plus que ce qui a été commandé
                    int commande = db.LignesCommande.Where(l => l.CommandeId == idCommande)
                        .Select(l => l.Quantite).ToList().Sum();
                    int dejaRecu = db.Receptions.Where(r => r.CommandeId == idCommande && r.Id != _id)
                        .Select(r => r.QuantiteRecue).ToList().Sum();
                    if (dejaRecu + (int)nudQuantite.Value > commande)
                    {
                        if (!Outils.Confirmer("La quantité totale reçue (" + (dejaRecu + (int)nudQuantite.Value)
                                              + ") dépasse la quantité commandée (" + commande + ").\nContinuer ?"))
                            return;
                    }

                    Reception rec;
                    if (_id == 0)
                    {
                        rec = new Reception();                     // CREATE
                        db.Receptions.Add(rec);
                    }
                    else
                    {
                        rec = db.Receptions.Find(_id);             // UPDATE
                        if (rec == null)
                        {
                            Outils.Erreur("Cette réception n'existe plus.");
                            ChargerListe();
                            return;
                        }
                    }

                    rec.CommandeId = idCommande;
                    rec.DateReception = dtpReception.Value.Date;
                    rec.QuantiteRecue = (int)nudQuantite.Value;
                    rec.Conforme = chkConforme.Checked;
                    rec.Remarque = txtRemarque.Text.Trim();
                    db.SaveChanges();

                    StatutCommande avant = cmd.Statut;
                    RecalculerStatut(db, idCommande);
                    if (cmd.Statut != avant)
                        message = "La commande BC-" + idCommande + " est maintenant au statut « " + cmd.Statut + " ».";

                    ChargerListe(rec.Id);
                }
                Outils.Info("Réception enregistrée." + (message != null ? "\n" + message : ""));
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
                    Reception r = db.Receptions.Find(_id);
                    if (r == null)
                    {
                        ChargerListe();
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer cette réception ? Le statut de la commande sera recalculé."))
                        return;

                    int idCommande = r.CommandeId;
                    db.Receptions.Remove(r);
                    db.SaveChanges();
                    RecalculerStatut(db, idCommande);
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
