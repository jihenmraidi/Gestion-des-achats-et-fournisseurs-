namespace GestionAchats.Forms
{
    partial class FormArticles
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
            this.grpListe = new System.Windows.Forms.GroupBox();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.lblUnite = new System.Windows.Forms.Label();
            this.cboUnite = new System.Windows.Forms.ComboBox();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.grpListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // grpListe
            //
            this.grpListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListe.Controls.Add(this.lblRecherche);
            this.grpListe.Controls.Add(this.txtRecherche);
            this.grpListe.Controls.Add(this.dgv);
            this.grpListe.Location = new System.Drawing.Point(12, 12);
            this.grpListe.Name = "grpListe";
            this.grpListe.Size = new System.Drawing.Size(876, 270);
            this.grpListe.TabIndex = 0;
            this.grpListe.TabStop = false;
            this.grpListe.Text = "Liste des articles";
            //
            // lblRecherche
            //
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(15, 30);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(80, 20);
            this.lblRecherche.TabIndex = 0;
            this.lblRecherche.Text = "Rechercher";
            //
            // txtRecherche
            //
            this.txtRecherche.Location = new System.Drawing.Point(110, 27);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(300, 27);
            this.txtRecherche.TabIndex = 1;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            //
            // dgv
            //
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(15, 65);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(846, 190);
            this.dgv.TabIndex = 2;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            //
            // grpDetails
            //
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.lblReference);
            this.grpDetails.Controls.Add(this.txtReference);
            this.grpDetails.Controls.Add(this.lblDesignation);
            this.grpDetails.Controls.Add(this.txtDesignation);
            this.grpDetails.Controls.Add(this.lblUnite);
            this.grpDetails.Controls.Add(this.cboUnite);
            this.grpDetails.Controls.Add(this.lblCategorie);
            this.grpDetails.Controls.Add(this.cboCategorie);
            this.grpDetails.Location = new System.Drawing.Point(12, 292);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(876, 160);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails";
            //
            // lblReference
            //
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(15, 38);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(86, 20);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "Référence *";
            //
            // txtReference
            //
            this.txtReference.Location = new System.Drawing.Point(140, 35);
            this.txtReference.MaxLength = 30;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(280, 27);
            this.txtReference.TabIndex = 1;
            //
            // lblDesignation
            //
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(15, 73);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(97, 20);
            this.lblDesignation.TabIndex = 2;
            this.lblDesignation.Text = "Désignation *";
            //
            // txtDesignation
            //
            this.txtDesignation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesignation.Location = new System.Drawing.Point(140, 70);
            this.txtDesignation.MaxLength = 150;
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(720, 27);
            this.txtDesignation.TabIndex = 3;
            //
            // lblUnite
            //
            this.lblUnite.AutoSize = true;
            this.lblUnite.Location = new System.Drawing.Point(15, 108);
            this.lblUnite.Name = "lblUnite";
            this.lblUnite.Size = new System.Drawing.Size(48, 20);
            this.lblUnite.TabIndex = 4;
            this.lblUnite.Text = "Unité";
            //
            // cboUnite
            //
            this.cboUnite.Location = new System.Drawing.Point(140, 105);
            this.cboUnite.MaxLength = 20;
            this.cboUnite.Name = "cboUnite";
            this.cboUnite.Size = new System.Drawing.Size(280, 28);
            this.cboUnite.TabIndex = 5;
            //
            // lblCategorie
            //
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(450, 108);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(77, 20);
            this.lblCategorie.TabIndex = 6;
            this.lblCategorie.Text = "Catégorie";
            //
            // cboCategorie
            //
            this.cboCategorie.Location = new System.Drawing.Point(580, 105);
            this.cboCategorie.MaxLength = 60;
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(280, 28);
            this.cboCategorie.TabIndex = 7;
            //
            // btnNouveau
            //
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNouveau.Location = new System.Drawing.Point(12, 466);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 34);
            this.btnNouveau.TabIndex = 2;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnregistrer.Location = new System.Drawing.Point(142, 466);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 34);
            this.btnEnregistrer.TabIndex = 3;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSupprimer.Location = new System.Drawing.Point(272, 466);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 34);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(768, 466);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.TabIndex = 5;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // FormArticles
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 512);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpListe);
            this.MinimumSize = new System.Drawing.Size(918, 559);
            this.Name = "FormArticles";
            this.Text = "Gestion des articles";
            this.Load += new System.EventHandler(this.FormArticles_Load);
            this.grpListe.ResumeLayout(false);
            this.grpListe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpListe;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label lblUnite;
        private System.Windows.Forms.ComboBox cboUnite;
        private System.Windows.Forms.Label lblCategorie;
        private System.Windows.Forms.ComboBox cboCategorie;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
