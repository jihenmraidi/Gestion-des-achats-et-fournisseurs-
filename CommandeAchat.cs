using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionAchats.Models
{
    public class CommandeAchat
    {
        public DateTime DateCommande { get; set; } = DateTime.Today;
        public DateTime DateLivraisonPrevue { get; set; }
        public DateTime? DateLivraisonReelle { get; set; }
        public StatutCommande Statut { get; set; } = StatutCommande.Brouillon;
        public decimal MontantTotal { get; set; }

        // Liens vers les autres classes
        public Utilisateur Acheteur { get; set; }
        public Fournisseur Fournisseur { get; set; }
        public Offre OffreRetenue { get; set; }
        public List<LigneCommande> Lignes { get; set; } = new List<LigneCommande>();
        public List<Reception> Receptions { get; set; } = new List<Reception>();

        public void RecalculerMontantTotal()
        {
            MontantTotal = Lignes.Sum(l => l.Montant);
        }

        public bool EstEnRetard()
        {
            if (Statut == StatutCommande.Annulee)
                return false;

            // Commande déjà livrée : en retard si elle est arrivée après la date prévue
            if (DateLivraisonReelle.HasValue)
                return DateLivraisonReelle.Value.Date > DateLivraisonPrevue.Date;

            // Pas encore livrée : en retard si la date prévue est dépassée
            return DateTime.Today > DateLivraisonPrevue.Date;
        }
    }
}
