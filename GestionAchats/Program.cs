using System;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Forms;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    if (db.Database.GetMigrations().Any())
                    {
                        // Mode migrations (Code First) : applique les migrations du dossier Migrations
                        db.Database.Migrate();
                    }
                    else
                    {
                        // Aucune migration créée : EF crée directement les tables à partir des classes.
                        // L'application fonctionne donc dès le premier lancement (F5).
                        db.Database.EnsureCreated();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Impossible d'initialiser la base de données :\n\n" + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormPrincipal());
        }
    }
}
