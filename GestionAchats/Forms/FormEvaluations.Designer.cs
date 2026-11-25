namespace GestionAchats.Forms
{
    partial class FormEvaluations
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
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.lblMoyenne = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblQualite = new System.Windows.Forms.Label();
            this.nudQualite = new System.Windows.Forms.NumericUpDown();
            this.lblDelai = new System.Windows.Forms.Label();
            this.nudDelai = new System.Windows.Forms.NumericUpDown();
            this.lblPrix = new System.Windows.Forms.Label();
            this.nudPrix = new System.Windows.Forms.NumericUpDown();
            this.lblNoteGlobale = new System.Windows.Forms.Label();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.txtCommentaire = new System.Windows.Forms.TextBox();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrix)).BeginInit();
            this.grpListe.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // grpListe
            //
            this.grpListe.Controls.Add(this.lblRecherche);
            this.grpListe.Controls.Add(this.txtRecherche);
            this.grpListe.Controls.Add(this.dgv);
            this.grpListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListe.Location = new System.Drawing.Point(12, 12);
            this.grpListe.Name = "grpListe";
            this.grpListe.Size = new System.Drawing.Size(876, 250);
            this.grpListe.TabIndex = 0;
            this.grpListe.Text = "Liste des évaluations";
            this.grpListe.TabStop = false;
            //
            // lblRecherche
            //
            this.lblRecherche.Location = new System.Drawing.Point(15, 30);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(80, 20);
            this.lblRecherche.TabIndex = 0;
            this.lblRecherche.Text = "Rechercher";
            this.lblRecherche.AutoSize = true;
            //
            // txtRecherche
            //
            this.txtRecherche.Location = new System.Drawing.Point(140, 27);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(300, 27);
            this.txtRecherche.TabIndex = 1;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            //
            // dgv
            //
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(15, 65);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(846, 170);
            this.dgv.TabIndex = 2;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.MultiSelect = false;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            //
            // grpDetails
            //
            this.grpDetails.Controls.Add(this.lblFournisseur);
            this.grpDetails.Controls.Add(this.cboFournisseur);
            this.grpDetails.Controls.Add(this.lblMoyenne);
            this.grpDetails.Controls.Add(this.lblDate);
            this.grpDetails.Controls.Add(this.dtpDate);
            this.grpDetails.Controls.Add(this.lblQualite);
            this.grpDetails.Controls.Add(this.nudQualite);
            this.grpDetails.Controls.Add(this.lblDelai);
            this.grpDetails.Controls.Add(this.nudDelai);
            this.grpDetails.Controls.Add(this.lblPrix);
            this.grpDetails.Controls.Add(this.nudPrix);
            this.grpDetails.Controls.Add(this.lblNoteGlobale);
            this.grpDetails.Controls.Add(this.lblCommentaire);
            this.grpDetails.Controls.Add(this.txtCommentaire);
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Location = new System.Drawing.Point(12, 272);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(876, 190);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.Text = "Détails";
            this.grpDetails.TabStop = false;
            //
            // lblFournisseur
            //
            this.lblFournisseur.Location = new System.Drawing.Point(15, 35);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(100, 20);
            this.lblFournisseur.TabIndex = 0;
            this.lblFournisseur.Text = "Fournisseur *";
            this.lblFournisseur.AutoSize = true;
            //
            // cboFournisseur
            //
            this.cboFournisseur.Location = new System.Drawing.Point(140, 32);
            this.cboFournisseur.Name = "cboFournisseur";
            this.cboFournisseur.Size = new System.Drawing.Size(300, 28);
            this.cboFournisseur.TabIndex = 1;
            this.cboFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFournisseur.SelectedIndexChanged += new System.EventHandler(this.cboFournisseur_SelectedIndexChanged);
            //
            // lblMoyenne
            //
            this.lblMoyenne.Location = new System.Drawing.Point(470, 35);
            this.lblMoyenne.Name = "lblMoyenne";
            this.lblMoyenne.Size = new System.Drawing.Size(380, 20);
            this.lblMoyenne.TabIndex = 2;
            this.lblMoyenne.Text = "Note moyenne : -";
            this.lblMoyenne.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoyenne.AutoSize = true;
            //
            // lblDate
            //
            this.lblDate.Location = new System.Drawing.Point(15, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 20);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date";
            this.lblDate.AutoSize = true;
            //
            // dtpDate
            //
            this.dtpDate.Location = new System.Drawing.Point(140, 67);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(160, 27);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblQualite
            //
            this.lblQualite.Location = new System.Drawing.Point(15, 105);
            this.lblQualite.Name = "lblQualite";
            this.lblQualite.Size = new System.Drawing.Size(100, 20);
            this.lblQualite.TabIndex = 5;
            this.lblQualite.Text = "Qualité (1-5)";
            this.lblQualite.AutoSize = true;
            //
            // nudQualite
            //
            this.nudQualite.Location = new System.Drawing.Point(140, 102);
            this.nudQualite.Name = "nudQualite";
            this.nudQualite.Size = new System.Drawing.Size(70, 27);
            this.nudQualite.TabIndex = 6;
            this.nudQualite.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudQualite.Maximum = new decimal(new int[] {5, 0, 0, 0});
            this.nudQualite.Value = new decimal(new int[] {3, 0, 0, 0});
            this.nudQualite.ValueChanged += new System.EventHandler(this.nudNote_ValueChanged);
            //
            // lblDelai
            //
            this.lblDelai.Location = new System.Drawing.Point(250, 105);
            this.lblDelai.Name = "lblDelai";
            this.lblDelai.Size = new System.Drawing.Size(100, 20);
            this.lblDelai.TabIndex = 7;
            this.lblDelai.Text = "Délai (1-5)";
            this.lblDelai.AutoSize = true;
            //
            // nudDelai
            //
            this.nudDelai.Location = new System.Drawing.Point(350, 102);
            this.nudDelai.Name = "nudDelai";
            this.nudDelai.Size = new System.Drawing.Size(70, 27);
            this.nudDelai.TabIndex = 8;
            this.nudDelai.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudDelai.Maximum = new decimal(new int[] {5, 0, 0, 0});
            this.nudDelai.Value = new decimal(new int[] {3, 0, 0, 0});
            this.nudDelai.ValueChanged += new System.EventHandler(this.nudNote_ValueChanged);
            //
            // lblPrix
            //
            this.lblPrix.Location = new System.Drawing.Point(460, 105);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPrix.TabIndex = 9;
            this.lblPrix.Text = "Prix (1-5)";
            this.lblPrix.AutoSize = true;
            //
            // nudPrix
            //
            this.nudPrix.Location = new System.Drawing.Point(550, 102);
            this.nudPrix.Name = "nudPrix";
            this.nudPrix.Size = new System.Drawing.Size(70, 27);
            this.nudPrix.TabIndex = 10;
            this.nudPrix.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudPrix.Maximum = new decimal(new int[] {5, 0, 0, 0});
            this.nudPrix.Value = new decimal(new int[] {3, 0, 0, 0});
            this.nudPrix.ValueChanged += new System.EventHandler(this.nudNote_ValueChanged);
            //
            // lblNoteGlobale
            //
            this.lblNoteGlobale.Location = new System.Drawing.Point(660, 105);
            this.lblNoteGlobale.Name = "lblNoteGlobale";
            this.lblNoteGlobale.Size = new System.Drawing.Size(190, 20);
            this.lblNoteGlobale.TabIndex = 11;
            this.lblNoteGlobale.Text = "Note globale : 3,00";
            this.lblNoteGlobale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNoteGlobale.AutoSize = true;
            //
            // lblCommentaire
            //
            this.lblCommentaire.Location = new System.Drawing.Point(15, 142);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(100, 20);
            this.lblCommentaire.TabIndex = 12;
            this.lblCommentaire.Text = "Commentaire";
            this.lblCommentaire.AutoSize = true;
            //
            // txtCommentaire
            //
            this.txtCommentaire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommentaire.Location = new System.Drawing.Point(140, 139);
            this.txtCommentaire.Name = "txtCommentaire";
            this.txtCommentaire.Size = new System.Drawing.Size(720, 27);
            this.txtCommentaire.TabIndex = 13;
            this.txtCommentaire.MaxLength = 250;
            //
            // btnNouveau
            //
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNouveau.Location = new System.Drawing.Point(12, 476);
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
            this.btnEnregistrer.Location = new System.Drawing.Point(142, 476);
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
            this.btnSupprimer.Location = new System.Drawing.Point(272, 476);
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
            this.btnFermer.Location = new System.Drawing.Point(768, 476);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.TabIndex = 5;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // FormEvaluations
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.grpListe);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(918, 587);
            this.Name = "FormEvaluations";
            this.Text = "Évaluation des fournisseurs";
            this.Load += new System.EventHandler(this.FormEvaluations_Load);
            this.grpListe.ResumeLayout(false);
            this.grpListe.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQualite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrix)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpListe;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.Label lblMoyenne;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblQualite;
        private System.Windows.Forms.NumericUpDown nudQualite;
        private System.Windows.Forms.Label lblDelai;
        private System.Windows.Forms.NumericUpDown nudDelai;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.NumericUpDown nudPrix;
        private System.Windows.Forms.Label lblNoteGlobale;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.TextBox txtCommentaire;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
