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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            //
            // menuGestion
            //
            this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFournisseurs,
            this.itemArticles,
            this.toolStripSeparator1,
            this.itemQuitter});
            this.menuGestion.Name = "menuGestion";
            this.menuGestion.Size = new System.Drawing.Size(75, 24);
            this.menuGestion.Text = "&Gestion";
            //
            // itemFournisseurs
            //
            this.itemFournisseurs.Name = "itemFournisseurs";
            this.itemFournisseurs.Size = new System.Drawing.Size(180, 26);
            this.itemFournisseurs.Text = "&Fournisseurs";
            this.itemFournisseurs.Click += new System.EventHandler(this.itemFournisseurs_Click);
            //
            // itemArticles
            //
            this.itemArticles.Name = "itemArticles";
            this.itemArticles.Size = new System.Drawing.Size(180, 26);
            this.itemArticles.Text = "&Articles";
            this.itemArticles.Click += new System.EventHandler(this.itemArticles_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            //
            // itemQuitter
            //
            this.itemQuitter.Name = "itemQuitter";
            this.itemQuitter.Size = new System.Drawing.Size(180, 26);
            this.itemQuitter.Text = "&Quitter";
            this.itemQuitter.Click += new System.EventHandler(this.itemQuitter_Click);
            //
            // FormPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem itemQuitter;
    }
}
