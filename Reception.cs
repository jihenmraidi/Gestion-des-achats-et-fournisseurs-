using System;

namespace GestionAchats.Models
{
    public class Reception
    {
        public DateTime DateReception { get; set; } = DateTime.Today;
        public int QuantiteRecue { get; set; }
        public bool Conforme { get; set; } = true;
        public string Remarque { get; set; }

        // Liens vers les autres classes
        public CommandeAchat Commande { get; set; }
    }
}
