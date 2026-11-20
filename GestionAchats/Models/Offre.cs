using System.Collections.Generic;
using System.Linq;

namespace GestionAchats.Models
{
    public class Offre
    {
        public int Id { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int DelaiJours { get; set; }

        // Remise en pourcentage (ex : 5 pour 5 %)
        public decimal Remise { get; set; }
        public decimal FraisTransport { get; set; }
        public double Score { get; set; }

        // Clés étrangères + liens vers les autres classes
        public int DemandeId { get; set; }
        public DemandeAchat Demande { get; set; }
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }

        // Coût total = prix net x quantité demandée + transport
        public decimal CalculerCoutTotal()
        {
            int quantite = Demande != null ? Demande.Quantite : 0;
            decimal prixNet = PrixUnitaire * (1 - Remise / 100m);
            return prixNet * quantite + FraisTransport;
        }

        // Score multicritère sur 100 : chaque critère est normalisé par rapport à la meilleure offre
        // (coût le plus bas, délai le plus court) et la fiabilité vient de la note du fournisseur (/5).
        public double CalculerScore(decimal coutMin, int delaiMin,
                                    double poidsPrix, double poidsDelai, double poidsFiabilite)
        {
            double somme = poidsPrix + poidsDelai + poidsFiabilite;
            if (somme <= 0)
                return 0;

            decimal cout = CalculerCoutTotal();
            double scorePrix = cout > 0 ? (double)(coutMin / cout) : 0;
            double scoreDelai = DelaiJours > 0 ? (double)delaiMin / DelaiJours : 0;
            double scoreFiabilite = Fournisseur != null ? Fournisseur.CalculerNote() / 5.0 : 0;

            Score = 100 * (poidsPrix * scorePrix + poidsDelai * scoreDelai + poidsFiabilite * scoreFiabilite) / somme;
            return Score;
        }

        // Calcule le score de toutes les offres d'une même demande et les renvoie classées (meilleure en premier)
        public static List<Offre> ClasserOffres(List<Offre> offres,
                                                double poidsPrix, double poidsDelai, double poidsFiabilite)
        {
            if (offres == null || offres.Count == 0)
                return new List<Offre>();

            decimal coutMin = offres.Select(o => o.CalculerCoutTotal()).Where(c => c > 0).DefaultIfEmpty(1m).Min();
            int delaiMin = offres.Select(o => o.DelaiJours).Where(d => d > 0).DefaultIfEmpty(1).Min();

            foreach (Offre o in offres)
                o.CalculerScore(coutMin, delaiMin, poidsPrix, poidsDelai, poidsFiabilite);

            return offres.OrderByDescending(o => o.Score).ToList();
        }
    }
}
