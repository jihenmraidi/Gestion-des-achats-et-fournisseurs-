using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation 
    public partial class FormTableauBord : Form
    {
        public FormTableauBord()
        {
            InitializeComponent();
        }

        private void FormTableauBord_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void Actualiser()
        {
            using (var db = new GestionAchatsContext())
            {
                int fournisseursActifs = db.Fournisseurs.Count(f => f.Actif);
                int demandesEnAttente = db.Demandes.Count(d => d.Statut == StatutDemande.EnAttente);

                // Les montants (decimal) sont additionnés en mémoire 
                List<CommandeAchat> commandes = db.Commandes.AsNoTracking().ToList();
                List<CommandeAchat> actives = commandes.Where(c => c.Statut != StatutCommande.Annulee).ToList();

                int enCours = commandes.Count(c => c.Statut == StatutCommande.Envoyee
                                                   || c.Statut == StatutCommande.Confirmee
                                                   || c.Statut == StatutCommande.PartiellementLivree);
                int enRetard = actives.Count(c => !c.DateLivraisonReelle.HasValue && c.EstEnRetard());

                List<CommandeAchat> livrees = actives.Where(c => c.DateLivraisonReelle.HasValue).ToList();
                string aTemps = "-";
                if (livrees.Count > 0)
                {
                    double pct = 100.0 * livrees.Count(c => !c.EstEnRetard()) / livrees.Count;
                    aTemps = pct.ToString("0") + " %";
                }

                decimal montant = actives.Sum(c => c.MontantTotal);

                lblKpi1.Text = fournisseursActifs.ToString();
                lblKpi2.Text = demandesEnAttente.ToString();
                lblKpi3.Text = enCours.ToString();
                lblKpi4.Text = enRetard.ToString();
                lblKpi5.Text = aTemps;
                lblKpi6.Text = montant.ToString("N0");

                // Classement des fournisseurs
                List<Fournisseur> fournisseurs = db.Fournisseurs.AsNoTracking()
                    .Include(f => f.Evaluations)
                    .Include(f => f.Commandes)
                    .ToList();

                var classement = fournisseurs
                    .Select(f => new
                    {
                        Fournisseur = f.Nom,
                        Actif = f.Actif ? "Oui" : "Non",
                        Note = Math.Round(f.CalculerNote(), 2),
                        NbEvaluations = f.Evaluations.Count,
                        NbCommandes = f.Commandes.Count(c => c.Statut != StatutCommande.Annulee),
                        NbRetards = f.Commandes.Count(c => c.Statut != StatutCommande.Annulee && c.EstEnRetard()),
                        Montant = f.Commandes.Where(c => c.Statut != StatutCommande.Annulee).Sum(c => c.MontantTotal)
                    })
                    .OrderByDescending(x => x.Note).ThenByDescending(x => x.NbCommandes)
                    .ToList();

                dgv.DataSource = classement;
                dgv.Columns["Note"].HeaderText = "Note moyenne /5";
                dgv.Columns["NbEvaluations"].HeaderText = "Évaluations";
                dgv.Columns["NbCommandes"].HeaderText = "Commandes";
                dgv.Columns["NbRetards"].HeaderText = "Retards";
                Outils.FormatMontant(dgv, "Montant", "Montant commandé");
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
