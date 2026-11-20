namespace GestionAchats.Forms
{
    partial class FormFournisseurs
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
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblConditions = new System.Windows.Forms.Label();
            this.cboConditions = new System.Windows.Forms.ComboBox();
            this.chkActif = new System.Windows.Forms.CheckBox();
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
            this.grpListe.Text = "Liste des fournisseurs";
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
            this.grpDetails.Controls.Add(this.lblNom);
            this.grpDetails.Controls.Add(this.txtNom);
            this.grpDetails.Controls.Add(this.lblContact);
            this.grpDetails.Controls.Add(this.txtContact);
            this.grpDetails.Controls.Add(this.lblTelephone);
            this.grpDetails.Controls.Add(this.txtTelephone);
            this.grpDetails.Controls.Add(this.lblEmail);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.lblConditions);
            this.grpDetails.Controls.Add(this.cboConditions);
            this.grpDetails.Controls.Add(this.chkActif);
            this.grpDetails.Location = new System.Drawing.Point(12, 292);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(876, 160);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails";
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(15, 38);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(46, 20);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom *";
            //
            // txtNom
            //
            this.txtNom.Location = new System.Drawing.Point(140, 35);
            this.txtNom.MaxLength = 100;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(280, 27);
            this.txtNom.TabIndex = 1;
            //
            // lblContact
            //
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(15, 73);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(60, 20);
            this.lblContact.TabIndex = 2;
            this.lblContact.Text = "Contact";
            //
            // txtContact
            //
            this.txtContact.Location = new System.Drawing.Point(140, 70);
            this.txtContact.MaxLength = 100;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(280, 27);
            this.txtContact.TabIndex = 3;
            //
            // lblTelephone
            //
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(15, 108);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(79, 20);
            this.lblTelephone.TabIndex = 4;
            this.lblTelephone.Text = "Téléphone";
            //
            // txtTelephone
            //
            this.txtTelephone.Location = new System.Drawing.Point(140, 105);
            this.txtTelephone.MaxLength = 30;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(280, 27);
            this.txtTelephone.TabIndex = 5;
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(450, 38);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-mail";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(580, 35);
            this.txtEmail.MaxLength = 150;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 27);
            this.txtEmail.TabIndex = 7;
            //
            // lblConditions
            //
            this.lblConditions.AutoSize = true;
            this.lblConditions.Location = new System.Drawing.Point(450, 73);
            this.lblConditions.Name = "lblConditions";
            this.lblConditions.Size = new System.Drawing.Size(77, 20);
            this.lblConditions.TabIndex = 8;
            this.lblConditions.Text = "Paiement";
            //
            // cboConditions
            //
            this.cboConditions.Location = new System.Drawing.Point(580, 70);
            this.cboConditions.MaxLength = 100;
            this.cboConditions.Name = "cboConditions";
            this.cboConditions.Size = new System.Drawing.Size(280, 28);
            this.cboConditions.TabIndex = 9;
            //
            // chkActif
            //
            this.chkActif.AutoSize = true;
            this.chkActif.Checked = true;
            this.chkActif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActif.Location = new System.Drawing.Point(580, 107);
            this.chkActif.Name = "chkActif";
            this.chkActif.Size = new System.Drawing.Size(120, 24);
            this.chkActif.TabIndex = 10;
            this.chkActif.Text = "Fournisseur actif";
            this.chkActif.UseVisualStyleBackColor = true;
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
            // FormFournisseurs
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
            this.Name = "FormFournisseurs";
            this.Text = "Gestion des fournisseurs";
            this.Load += new System.EventHandler(this.FormFournisseurs_Load);
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
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblConditions;
        private System.Windows.Forms.ComboBox cboConditions;
        private System.Windows.Forms.CheckBox chkActif;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
