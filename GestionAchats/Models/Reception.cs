using System;

namespace GestionAchats.Models
{
    public class Reception
    {
        public int Id { get; set; }
        public DateTime DateReception { get; set; } = DateTime.Today;
        public int QuantiteRecue { get; set; }
        public bool Conforme { get; set; } = true;
        public string Remarque { get; set; }

        // Clés étrangères + liens vers les autres classes
        public int CommandeId { get; set; }
        public CommandeAchat Commande { get; set; }
    }
}
