using System;

namespace GestionAchats.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public DateTime DateEvaluation { get; set; } = DateTime.Today;

        // Notes de 1 à 5
        public int NoteQualite { get; set; }
        public int NoteDelai { get; set; }
        public int NotePrix { get; set; }
        public string Commentaire { get; set; }

        // Clés étrangères + liens vers les autres classes
        public int FournisseurId { get; set; }
        public Fournisseur Fournisseur { get; set; }

        public double NoteGlobale
        {
            get { return (NoteQualite + NoteDelai + NotePrix) / 3.0; }
        }
    }
}
