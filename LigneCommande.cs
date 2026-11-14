namespace GestionAchats.Models
{
    public class LigneCommande
    {
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        // Liens vers les autres classes
        public CommandeAchat Commande { get; set; }
        public Article Article { get; set; }

        public decimal Montant
        {
            get { return Quantite * PrixUnitaire; }
        }
    }
}
