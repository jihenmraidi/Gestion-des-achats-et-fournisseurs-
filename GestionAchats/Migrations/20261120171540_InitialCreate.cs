using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionAchats.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Designation = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Unite = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Categorie = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contact = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    ConditionsPaiement = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Actif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MotDePasse = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateEvaluation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoteQualite = table.Column<int>(type: "INTEGER", nullable: false),
                    NoteDelai = table.Column<int>(type: "INTEGER", nullable: false),
                    NotePrix = table.Column<int>(type: "INTEGER", nullable: false),
                    Commentaire = table.Column<string>(type: "TEXT", nullable: true),
                    FournisseurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateDemande = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Quantite = table.Column<int>(type: "INTEGER", nullable: false),
                    DateSouhaitee = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Statut = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    DemandeurId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Demandes_Utilisateurs_DemandeurId",
                        column: x => x.DemandeurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrixUnitaire = table.Column<decimal>(type: "TEXT", nullable: false),
                    DelaiJours = table.Column<int>(type: "INTEGER", nullable: false),
                    Remise = table.Column<decimal>(type: "TEXT", nullable: false),
                    FraisTransport = table.Column<decimal>(type: "TEXT", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    DemandeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FournisseurId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offres_Demandes_DemandeId",
                        column: x => x.DemandeId,
                        principalTable: "Demandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offres_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCommande = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateLivraisonPrevue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateLivraisonReelle = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Statut = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    MontantTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    AcheteurId = table.Column<int>(type: "INTEGER", nullable: false),
                    FournisseurId = table.Column<int>(type: "INTEGER", nullable: false),
                    OffreRetenueId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Offres_OffreRetenueId",
                        column: x => x.OffreRetenueId,
                        principalTable: "Offres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commandes_Utilisateurs_AcheteurId",
                        column: x => x.AcheteurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignesCommande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantite = table.Column<int>(type: "INTEGER", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "TEXT", nullable: false),
                    CommandeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesCommande", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignesCommande_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LignesCommande_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateReception = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuantiteRecue = table.Column<int>(type: "INTEGER", nullable: false),
                    Conforme = table.Column<bool>(type: "INTEGER", nullable: false),
                    Remarque = table.Column<string>(type: "TEXT", nullable: true),
                    CommandeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptions_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Categorie", "Designation", "Reference", "Unite" },
                values: new object[,]
                {
                    { 1, "Fournitures de bureau", "Ramette papier A4 80g", "ART-001", "Boîte" },
                    { 2, "Consommables informatiques", "Cartouche d'encre noire", "ART-002", "Pièce" },
                    { 3, "Matériel réseau", "Câble réseau RJ45 (cat. 6)", "ART-003", "Mètre" }
                });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Actif", "ConditionsPaiement", "Contact", "Email", "Nom", "Telephone" },
                values: new object[,]
                {
                    { 1, true, "30 jours", "Sami Ben Ali", "contact@tunisie-fournitures.tn", "Tunisie Fournitures", "71 123 456" },
                    { 2, true, "60 jours", "Leila Trabelsi", "ventes@sfax-industrie.tn", "Sfax Industrie", "74 234 567" },
                    { 3, true, "Comptant", "Karim Jlassi", "info@bureauplus.tn", "Bureau Plus", "70 345 678" }
                });

            migrationBuilder.InsertData(
                table: "Utilisateurs",
                columns: new[] { "Id", "Login", "MotDePasse", "Nom", "Role" },
                values: new object[] { 1, "admin", "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9", "Administrateur", "Administrateur" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Reference",
                table: "Articles",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_AcheteurId",
                table: "Commandes",
                column: "AcheteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_FournisseurId",
                table: "Commandes",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_OffreRetenueId",
                table: "Commandes",
                column: "OffreRetenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_ArticleId",
                table: "Demandes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Demandes_DemandeurId",
                table: "Demandes",
                column: "DemandeurId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_FournisseurId",
                table: "Evaluations",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_Nom",
                table: "Fournisseurs",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LignesCommande_ArticleId",
                table: "LignesCommande",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesCommande_CommandeId",
                table: "LignesCommande",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offres_DemandeId",
                table: "Offres",
                column: "DemandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offres_FournisseurId",
                table: "Offres",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_CommandeId",
                table: "Receptions",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Login",
                table: "Utilisateurs",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "LignesCommande");

            migrationBuilder.DropTable(
                name: "Receptions");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Offres");

            migrationBuilder.DropTable(
                name: "Demandes");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
