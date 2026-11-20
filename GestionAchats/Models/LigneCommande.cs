namespace GestionAchats.Models
{
    public class LigneCommande
    {
        public int Id { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        // Clés étrangères + liens vers les autres classes
        public int CommandeId { get; set; }
        public CommandeAchat Commande { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public decimal Montant
        {
            get { return Quantite * PrixUnitaire; }
        }
    }
}
