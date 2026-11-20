using System.Collections.Generic;
using System.Linq;

namespace GestionAchats.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Contact { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ConditionsPaiement { get; set; }
        public bool Actif { get; set; } = true;

        public List<Offre> Offres { get; set; } = new List<Offre>();
        public List<CommandeAchat> Commandes { get; set; } = new List<CommandeAchat>();
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        // Note moyenne sur 5 (0 si aucune évaluation)
        public double CalculerNote()
        {
            if (Evaluations == null || Evaluations.Count == 0)
                return 0;
            return Evaluations.Average(e => e.NoteGlobale);
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
