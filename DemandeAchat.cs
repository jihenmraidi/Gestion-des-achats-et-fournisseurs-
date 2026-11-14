using System;
using System.Collections.Generic;

namespace GestionAchats.Models
{
    public class DemandeAchat
    {
        public DateTime DateDemande { get; set; } = DateTime.Today;
        public int Quantite { get; set; }
        public DateTime DateSouhaitee { get; set; }
        public StatutDemande Statut { get; set; } = StatutDemande.EnAttente;

        // Liens vers les autres classes
        public Utilisateur Demandeur { get; set; }
        public Article Article { get; set; }
        public List<Offre> Offres { get; set; } = new List<Offre>();
    }
}
