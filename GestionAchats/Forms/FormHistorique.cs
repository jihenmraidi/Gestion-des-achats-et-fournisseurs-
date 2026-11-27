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
    // Cas d'utilisation : « Consulter l'historique » (Acheteur, Responsable achats) - lecture seule
    public partial class FormHistorique : Form
    {
        private bool _chargement;

        public FormHistorique()
        {
            InitializeComponent();
        }

        private void FormHistorique_Load(object sender, EventArgs e)
        {
            _chargement = true;
            using (var db = new GestionAchatsContext())
            {
                var fournisseurs = db.Fournisseurs.AsNoTracking().OrderBy(f => f.Nom)
                    .Select(f => new { f.Id, f.Nom }).ToList();

                List<Choix> choix = new List<Choix>();
                choix.Add(new Choix(0, "(Tous les fournisseurs)"));
                choix.AddRange(fournisseurs.Select(f => new Choix(f.Id, f.Nom)));
                Outils.Remplir(cboFournisseur, choix);
            }
            dtpDu.Value = DateTime.Today.AddMonths(-6);
            dtpAu.Value = DateTime.Today;
            _chargement = false;

            Charger();
        }

        private void Charger()
        {
            int idFournisseur = Outils.Valeur(cboFournisseur);
            bool periode = chkPeriode.Checked;
            DateTime du = dtpDu.Value.Date;
            DateTime au = dtpAu.Value.Date;

            using (var db = new GestionAchatsContext())
            {
                IQueryable<CommandeAchat> requete = db.Commandes.AsNoTracking();
                if (idFournisseur != 0)
                    requete = requete.Where(c => c.FournisseurId == idFournisseur);

                List<CommandeAchat> commandes = requete
                    .Include(c => c.Fournisseur)
                    .Include(c => c.Lignes)
                    .Include(c => c.Receptions)
                    .ToList();

                List<CommandeAchat> filtrees = commandes
                    .Where(c => !periode || (c.DateCommande.Date >= du && c.DateCommande.Date <= au))
                    .OrderByDescending(c => c.DateCommande).ThenByDescending(c => c.Id)
                    .ToList();

                var liste = filtrees
                    .Select(c => new
                    {
                        N = "BC-" + c.Id,
                        Fournisseur = c.Fournisseur.Nom,
                        c.DateCommande,
                        c.Statut,
                        QteCommandee = c.Lignes.Sum(l => l.Quantite),
                        QteRecue = c.Receptions.Sum(r => r.QuantiteRecue),
                        NbReceptions = c.Receptions.Count,
                        NonConformes = c.Receptions.Count(r => !r.Conforme),
                        c.DateLivraisonPrevue,
                        c.DateLivraisonReelle,
                        c.MontantTotal,
                        EnRetard = c.EstEnRetard() ? "Oui" : "Non"
                    })
                    .ToList();

                dgv.DataSource = liste;
                dgv.Columns["N"].HeaderText = "N°";
                Outils.FormatDate(dgv, "DateCommande", "Date commande");
                dgv.Columns["QteCommandee"].HeaderText = "Qté commandée";
                dgv.Columns["QteRecue"].HeaderText = "Qté reçue";
                dgv.Columns["NbReceptions"].HeaderText = "Réceptions";
                dgv.Columns["NonConformes"].HeaderText = "Non conformes";
                Outils.FormatDate(dgv, "DateLivraisonPrevue", "Livraison prévue");
                Outils.FormatDate(dgv, "DateLivraisonReelle", "Livraison réelle");
                Outils.FormatMontant(dgv, "MontantTotal", "Montant");
                dgv.Columns["EnRetard"].HeaderText = "En retard";

                foreach (DataGridViewRow ligne in dgv.Rows)
                {
                    if ((string)ligne.Cells["EnRetard"].Value == "Oui")
                        ligne.DefaultCellStyle.ForeColor = Color.Firebrick;
                }

                decimal total = filtrees.Where(c => c.Statut != StatutCommande.Annulee).Sum(c => c.MontantTotal);
                int retards = filtrees.Count(c => c.EstEnRetard());
                lblResume.Text = filtrees.Count + " commande(s)  |  montant total (hors annulées) : "
                                 + Outils.Montant(total) + "  |  en retard : " + retards;
            }
        }

        private void cboFournisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            Charger();
        }

        private void chkPeriode_CheckedChanged(object sender, EventArgs e)
        {
            dtpDu.Enabled = chkPeriode.Checked;
            dtpAu.Enabled = chkPeriode.Checked;
            if (_chargement)
                return;
            Charger();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (_chargement || !chkPeriode.Checked)
                return;
            Charger();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
