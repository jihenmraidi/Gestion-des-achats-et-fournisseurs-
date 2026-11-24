using System;
using System.Collections.Generic;

namespace GestionAchats.Models
{
    public class DemandeAchat
    {
        public int Id { get; set; }
        public DateTime DateDemande { get; set; } = DateTime.Today;
        public int Quantite { get; set; }
        public DateTime DateSouhaitee { get; set; }
        public StatutDemande Statut { get; set; } = StatutDemande.EnAttente;

        // Clés étrangères + liens vers les autres classes
        public int DemandeurId { get; set; }
        public Utilisateur Demandeur { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public List<Offre> Offres { get; set; } = new List<Offre>();
    }
}
