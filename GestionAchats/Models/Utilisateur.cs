using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GestionAchats.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Login { get; set; }

        // Stocker le mot de passe HASHÉ (jamais en clair) : voir HasherMotDePasse
        public string MotDePasse { get; set; }
        public Role Role { get; set; }

        public List<DemandeAchat> Demandes { get; set; } = new List<DemandeAchat>();
        public List<CommandeAchat> Commandes { get; set; } = new List<CommandeAchat>();

        public bool SeConnecter(string login, string motDePasse)
        {
            return Login == login && MotDePasse == HasherMotDePasse(motDePasse);
        }

        public static string HasherMotDePasse(string motDePasse)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] octets = sha.ComputeHash(Encoding.UTF8.GetBytes(motDePasse ?? ""));
                return BitConverter.ToString(octets).Replace("-", "").ToLower();
            }
        }
    }
}
