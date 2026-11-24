using System;
using System.IO;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Data
{
    public class GestionAchatsContext : DbContext
    {
        // quelle classe représente quelle table de la base de données
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<DemandeAchat> Demandes { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<CommandeAchat> Commandes { get; set; }
        public DbSet<LigneCommande> LignesCommande { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        
        public static string CheminBase
        {
            get { return Path.Combine(TrouverDossierProjet(), "GestionAchats.db"); }
        }

        private static string TrouverDossierProjet()
        {
            DirectoryInfo dossier = new DirectoryInfo(AppContext.BaseDirectory);
            while (dossier != null)
            {
                if (dossier.GetFiles("*.csproj").Length > 0)
                    return dossier.FullName;
                dossier = dossier.Parent;
            }
            return AppContext.BaseDirectory; 
        }
        // type de base de données : SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=" + CheminBase);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // ---------- Utilisateur ----------
            mb.Entity<Utilisateur>(e =>
            {
                e.Property(u => u.Nom).IsRequired().HasMaxLength(100);
                e.Property(u => u.Login).IsRequired().HasMaxLength(50);
                e.HasIndex(u => u.Login).IsUnique();
                e.Property(u => u.MotDePasse).IsRequired();
                e.Property(u => u.Role).HasConversion<string>().HasMaxLength(30); // texte lisible dans la base

                e.HasMany(u => u.Demandes).WithOne(d => d.Demandeur)
                    .HasForeignKey(d => d.DemandeurId).OnDelete(DeleteBehavior.Restrict);
                e.HasMany(u => u.Commandes).WithOne(c => c.Acheteur)
                    .HasForeignKey(c => c.AcheteurId).OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Article ----------
            mb.Entity<Article>(e =>
            {
                e.Property(a => a.Reference).IsRequired().HasMaxLength(30);
                e.HasIndex(a => a.Reference).IsUnique();
                e.Property(a => a.Designation).IsRequired().HasMaxLength(150);
                e.Property(a => a.Unite).HasMaxLength(20);
                e.Property(a => a.Categorie).HasMaxLength(60);
            });

            // ---------- Fournisseur ----------
            mb.Entity<Fournisseur>(e =>
            {
                //définir la structure des colonnes dans la table des fournisseurs
                e.Property(f => f.Nom).IsRequired().HasMaxLength(100);
                e.HasIndex(f => f.Nom).IsUnique();
                e.Property(f => f.Contact).HasMaxLength(100);
                e.Property(f => f.Telephone).HasMaxLength(30);
                e.Property(f => f.Email).HasMaxLength(150);
                e.Property(f => f.ConditionsPaiement).HasMaxLength(100);

                // On ne supprime pas un fournisseur qui a des offres ou des commandes
                e.HasMany(f => f.Offres).WithOne(o => o.Fournisseur)
                    .HasForeignKey(o => o.FournisseurId).OnDelete(DeleteBehavior.Restrict);
                e.HasMany(f => f.Commandes).WithOne(c => c.Fournisseur)
                    .HasForeignKey(c => c.FournisseurId).OnDelete(DeleteBehavior.Restrict);
                // Les évaluations n'ont pas de sens sans le fournisseur : suppression en cascade
                e.HasMany(f => f.Evaluations).WithOne(ev => ev.Fournisseur)
                    .HasForeignKey(ev => ev.FournisseurId).OnDelete(DeleteBehavior.Cascade);
            });

            // ---------- DemandeAchat ----------
            mb.Entity<DemandeAchat>(e =>
            {
                e.Property(d => d.Statut).HasConversion<string>().HasMaxLength(30);
                e.HasOne(d => d.Article).WithMany()
                    .HasForeignKey(d => d.ArticleId).OnDelete(DeleteBehavior.Restrict);
                e.HasMany(d => d.Offres).WithOne(o => o.Demande)
                    .HasForeignKey(o => o.DemandeId).OnDelete(DeleteBehavior.Cascade);
            });

            // ---------- CommandeAchat ----------
            mb.Entity<CommandeAchat>(e =>
            {
                e.Property(c => c.Statut).HasConversion<string>().HasMaxLength(30);
                // Offre 1 -> 0..1 CommandeAchat : OffreRetenueId est facultatif
                e.HasOne(c => c.OffreRetenue).WithMany()
                    .HasForeignKey(c => c.OffreRetenueId).OnDelete(DeleteBehavior.Restrict);
                e.HasMany(c => c.Lignes).WithOne(l => l.Commande)
                    .HasForeignKey(l => l.CommandeId).OnDelete(DeleteBehavior.Cascade);
                e.HasMany(c => c.Receptions).WithOne(r => r.Commande)
                    .HasForeignKey(r => r.CommandeId).OnDelete(DeleteBehavior.Cascade);
            });

            // ---------- LigneCommande ----------
            mb.Entity<LigneCommande>(e =>
            {
                e.Ignore(l => l.Montant); // propriété calculée : pas de colonne
                e.HasOne(l => l.Article).WithMany()
                    .HasForeignKey(l => l.ArticleId).OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Evaluation ----------
            mb.Entity<Evaluation>(e =>
            {
                e.Ignore(ev => ev.NoteGlobale); // propriété calculée : pas de colonne
            });

            // ---------- Données initiales ----------
            mb.Entity<Utilisateur>().HasData(new Utilisateur
            {
                Id = 1,
                Nom = "Administrateur",
                Login = "admin",
                // SHA-256 de "admin123" (même algorithme que Utilisateur.HasherMotDePasse)
                MotDePasse = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9",
                Role = Role.Administrateur
            });

            mb.Entity<Fournisseur>().HasData(
                new Fournisseur { Id = 1, Nom = "Tunisie Fournitures", Contact = "Sami Ben Ali", Telephone = "71 123 456", Email = "contact@tunisie-fournitures.tn", ConditionsPaiement = "30 jours", Actif = true },
                new Fournisseur { Id = 2, Nom = "Sfax Industrie", Contact = "Leila Trabelsi", Telephone = "74 234 567", Email = "ventes@sfax-industrie.tn", ConditionsPaiement = "60 jours", Actif = true },
                new Fournisseur { Id = 3, Nom = "Bureau Plus", Contact = "Karim Jlassi", Telephone = "70 345 678", Email = "info@bureauplus.tn", ConditionsPaiement = "Comptant", Actif = true });

            mb.Entity<Article>().HasData(
                new Article { Id = 1, Reference = "ART-001", Designation = "Ramette papier A4 80g", Unite = "Boîte", Categorie = "Fournitures de bureau" },
                new Article { Id = 2, Reference = "ART-002", Designation = "Cartouche d'encre noire", Unite = "Pièce", Categorie = "Consommables informatiques" },
                new Article { Id = 3, Reference = "ART-003", Designation = "Câble réseau RJ45 (cat. 6)", Unite = "Mètre", Categorie = "Matériel réseau" });
        }
    }
}
