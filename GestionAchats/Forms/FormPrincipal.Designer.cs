namespace GestionAchats.Forms
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFournisseurs = new System.Windows.Forms.ToolStripMenuItem();
            this.itemArticles = new System.Windows.Forms.ToolStripMenuItem();
            this.itemUtilisateurs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAchats = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDemandes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemOffres = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCommandes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemReceptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSuivi = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEvaluations = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHistorique = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTableauBord = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestion,
            this.menuAchats,
            this.menuSuivi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            //
            // menuGestion
            //
            this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFournisseurs,
            this.itemArticles,
            this.itemUtilisateurs,
            this.toolStripSeparator1,
            this.itemQuitter});
            this.menuGestion.Name = "menuGestion";
            this.menuGestion.Size = new System.Drawing.Size(75, 24);
            this.menuGestion.Text = "&Gestion";
            //
            // menuAchats
            //
            this.menuAchats.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDemandes,
            this.itemOffres,
            this.itemCommandes,
            this.itemReceptions});
            this.menuAchats.Name = "menuAchats";
            this.menuAchats.Size = new System.Drawing.Size(75, 24);
            this.menuAchats.Text = "&Achats";
            //
            // menuSuivi
            //
            this.menuSuivi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEvaluations,
            this.itemHistorique,
            this.itemTableauBord});
            this.menuSuivi.Name = "menuSuivi";
            this.menuSuivi.Size = new System.Drawing.Size(75, 24);
            this.menuSuivi.Text = "&Suivi";
            //
            // itemFournisseurs
            //
            this.itemFournisseurs.Name = "itemFournisseurs";
            this.itemFournisseurs.Size = new System.Drawing.Size(200, 26);
            this.itemFournisseurs.Text = "&Fournisseurs";
            this.itemFournisseurs.Click += new System.EventHandler(this.itemFournisseurs_Click);
            //
            // itemArticles
            //
            this.itemArticles.Name = "itemArticles";
            this.itemArticles.Size = new System.Drawing.Size(200, 26);
            this.itemArticles.Text = "&Articles";
            this.itemArticles.Click += new System.EventHandler(this.itemArticles_Click);
            //
            // itemUtilisateurs
            //
            this.itemUtilisateurs.Name = "itemUtilisateurs";
            this.itemUtilisateurs.Size = new System.Drawing.Size(200, 26);
            this.itemUtilisateurs.Text = "&Utilisateurs";
            this.itemUtilisateurs.Click += new System.EventHandler(this.itemUtilisateurs_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            //
            // itemQuitter
            //
            this.itemQuitter.Name = "itemQuitter";
            this.itemQuitter.Size = new System.Drawing.Size(200, 26);
            this.itemQuitter.Text = "&Quitter";
            this.itemQuitter.Click += new System.EventHandler(this.itemQuitter_Click);
            //
            // itemDemandes
            //
            this.itemDemandes.Name = "itemDemandes";
            this.itemDemandes.Size = new System.Drawing.Size(200, 26);
            this.itemDemandes.Text = "&Demandes d'achat";
            this.itemDemandes.Click += new System.EventHandler(this.itemDemandes_Click);
            //
            // itemOffres
            //
            this.itemOffres.Name = "itemOffres";
            this.itemOffres.Size = new System.Drawing.Size(200, 26);
            this.itemOffres.Text = "&Offres";
            this.itemOffres.Click += new System.EventHandler(this.itemOffres_Click);
            //
            // itemCommandes
            //
            this.itemCommandes.Name = "itemCommandes";
            this.itemCommandes.Size = new System.Drawing.Size(200, 26);
            this.itemCommandes.Text = "&Commandes";
            this.itemCommandes.Click += new System.EventHandler(this.itemCommandes_Click);
            //
            // itemReceptions
            //
            this.itemReceptions.Name = "itemReceptions";
            this.itemReceptions.Size = new System.Drawing.Size(200, 26);
            this.itemReceptions.Text = "&Réceptions";
            this.itemReceptions.Click += new System.EventHandler(this.itemReceptions_Click);
            //
            // itemEvaluations
            //
            this.itemEvaluations.Name = "itemEvaluations";
            this.itemEvaluations.Size = new System.Drawing.Size(200, 26);
            this.itemEvaluations.Text = "&Évaluations";
            this.itemEvaluations.Click += new System.EventHandler(this.itemEvaluations_Click);
            //
            // itemHistorique
            //
            this.itemHistorique.Name = "itemHistorique";
            this.itemHistorique.Size = new System.Drawing.Size(200, 26);
            this.itemHistorique.Text = "&Historique";
            this.itemHistorique.Click += new System.EventHandler(this.itemHistorique_Click);
            //
            // itemTableauBord
            //
            this.itemTableauBord.Name = "itemTableauBord";
            this.itemTableauBord.Size = new System.Drawing.Size(200, 26);
            this.itemTableauBord.Text = "&Tableau de bord";
            this.itemTableauBord.Click += new System.EventHandler(this.itemTableauBord_Click);
            //
            // FormPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des achats et fournisseurs";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuGestion;
        private System.Windows.Forms.ToolStripMenuItem itemFournisseurs;
        private System.Windows.Forms.ToolStripMenuItem itemArticles;
        private System.Windows.Forms.ToolStripMenuItem itemUtilisateurs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemQuitter;
        private System.Windows.Forms.ToolStripMenuItem menuAchats;
        private System.Windows.Forms.ToolStripMenuItem itemDemandes;
        private System.Windows.Forms.ToolStripMenuItem itemOffres;
        private System.Windows.Forms.ToolStripMenuItem itemCommandes;
        private System.Windows.Forms.ToolStripMenuItem itemReceptions;
        private System.Windows.Forms.ToolStripMenuItem menuSuivi;
        private System.Windows.Forms.ToolStripMenuItem itemEvaluations;
        private System.Windows.Forms.ToolStripMenuItem itemHistorique;
        private System.Windows.Forms.ToolStripMenuItem itemTableauBord;
    }
}
