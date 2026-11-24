namespace GestionAchats.Forms
{
    partial class FormCommandes
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
            this.chkRetard = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.lblAcheteur = new System.Windows.Forms.Label();
            this.cboAcheteur = new System.Windows.Forms.ComboBox();
            this.lblDateCommande = new System.Windows.Forms.Label();
            this.dtpCommande = new System.Windows.Forms.DateTimePicker();
            this.lblDatePrevue = new System.Windows.Forms.Label();
            this.dtpPrevue = new System.Windows.Forms.DateTimePicker();
            this.lblStatut = new System.Windows.Forms.Label();
            this.cboStatut = new System.Windows.Forms.ComboBox();
            this.chkLivree = new System.Windows.Forms.CheckBox();
            this.dtpReelle = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblLignes = new System.Windows.Forms.Label();
            this.dgvLignes = new System.Windows.Forms.DataGridView();
            this.lblArticleLigne = new System.Windows.Forms.Label();
            this.cboArticleLigne = new System.Windows.Forms.ComboBox();
            this.lblQteLigne = new System.Windows.Forms.Label();
            this.nudQteLigne = new System.Windows.Forms.NumericUpDown();
            this.lblPrixLigne = new System.Windows.Forms.Label();
            this.nudPrixLigne = new System.Windows.Forms.NumericUpDown();
            this.btnAjouterLigne = new System.Windows.Forms.Button();
            this.btnRetirerLigne = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQteLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixLigne)).BeginInit();
            this.grpListe.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // grpListe
            //
            this.grpListe.Controls.Add(this.lblRecherche);
            this.grpListe.Controls.Add(this.txtRecherche);
            this.grpListe.Controls.Add(this.chkRetard);
            this.grpListe.Controls.Add(this.dgv);
            this.grpListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListe.Location = new System.Drawing.Point(12, 12);
            this.grpListe.Name = "grpListe";
            this.grpListe.Size = new System.Drawing.Size(976, 230);
            this.grpListe.TabIndex = 0;
            this.grpListe.Text = "Liste des commandes";
            this.grpListe.TabStop = false;
            //
            // lblRecherche
            //
            this.lblRecherche.Location = new System.Drawing.Point(15, 30);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(100, 20);
            this.lblRecherche.TabIndex = 0;
            this.lblRecherche.Text = "Fournisseur";
            this.lblRecherche.AutoSize = true;
            //
            // txtRecherche
            //
            this.txtRecherche.Location = new System.Drawing.Point(110, 27);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(250, 27);
            this.txtRecherche.TabIndex = 1;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            //
            // chkRetard
            //
            this.chkRetard.Location = new System.Drawing.Point(390, 29);
            this.chkRetard.Name = "chkRetard";
            this.chkRetard.Size = new System.Drawing.Size(200, 24);
            this.chkRetard.TabIndex = 2;
            this.chkRetard.Text = "Seulement les commandes en retard";
            this.chkRetard.AutoSize = true;
            this.chkRetard.UseVisualStyleBackColor = true;
            this.chkRetard.CheckedChanged += new System.EventHandler(this.chkRetard_CheckedChanged);
            //
            // dgv
            //
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(15, 65);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(946, 150);
            this.dgv.TabIndex = 3;
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
            this.grpDetails.Controls.Add(this.lblAcheteur);
            this.grpDetails.Controls.Add(this.cboAcheteur);
            this.grpDetails.Controls.Add(this.lblDateCommande);
            this.grpDetails.Controls.Add(this.dtpCommande);
            this.grpDetails.Controls.Add(this.lblDatePrevue);
            this.grpDetails.Controls.Add(this.dtpPrevue);
            this.grpDetails.Controls.Add(this.lblStatut);
            this.grpDetails.Controls.Add(this.cboStatut);
            this.grpDetails.Controls.Add(this.chkLivree);
            this.grpDetails.Controls.Add(this.dtpReelle);
            this.grpDetails.Controls.Add(this.lblTotal);
            this.grpDetails.Controls.Add(this.lblLignes);
            this.grpDetails.Controls.Add(this.dgvLignes);
            this.grpDetails.Controls.Add(this.lblArticleLigne);
            this.grpDetails.Controls.Add(this.cboArticleLigne);
            this.grpDetails.Controls.Add(this.lblQteLigne);
            this.grpDetails.Controls.Add(this.nudQteLigne);
            this.grpDetails.Controls.Add(this.lblPrixLigne);
            this.grpDetails.Controls.Add(this.nudPrixLigne);
            this.grpDetails.Controls.Add(this.btnAjouterLigne);
            this.grpDetails.Controls.Add(this.btnRetirerLigne);
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Location = new System.Drawing.Point(12, 252);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(976, 380);
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
            this.cboFournisseur.Size = new System.Drawing.Size(280, 28);
            this.cboFournisseur.TabIndex = 1;
            this.cboFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblAcheteur
            //
            this.lblAcheteur.Location = new System.Drawing.Point(470, 35);
            this.lblAcheteur.Name = "lblAcheteur";
            this.lblAcheteur.Size = new System.Drawing.Size(100, 20);
            this.lblAcheteur.TabIndex = 2;
            this.lblAcheteur.Text = "Acheteur *";
            this.lblAcheteur.AutoSize = true;
            //
            // cboAcheteur
            //
            this.cboAcheteur.Location = new System.Drawing.Point(590, 32);
            this.cboAcheteur.Name = "cboAcheteur";
            this.cboAcheteur.Size = new System.Drawing.Size(280, 28);
            this.cboAcheteur.TabIndex = 3;
            this.cboAcheteur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblDateCommande
            //
            this.lblDateCommande.Location = new System.Drawing.Point(15, 70);
            this.lblDateCommande.Name = "lblDateCommande";
            this.lblDateCommande.Size = new System.Drawing.Size(100, 20);
            this.lblDateCommande.TabIndex = 4;
            this.lblDateCommande.Text = "Date commande";
            this.lblDateCommande.AutoSize = true;
            //
            // dtpCommande
            //
            this.dtpCommande.Location = new System.Drawing.Point(140, 67);
            this.dtpCommande.Name = "dtpCommande";
            this.dtpCommande.Size = new System.Drawing.Size(160, 27);
            this.dtpCommande.TabIndex = 5;
            this.dtpCommande.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblDatePrevue
            //
            this.lblDatePrevue.Location = new System.Drawing.Point(330, 70);
            this.lblDatePrevue.Name = "lblDatePrevue";
            this.lblDatePrevue.Size = new System.Drawing.Size(100, 20);
            this.lblDatePrevue.TabIndex = 6;
            this.lblDatePrevue.Text = "Livraison prévue";
            this.lblDatePrevue.AutoSize = true;
            //
            // dtpPrevue
            //
            this.dtpPrevue.Location = new System.Drawing.Point(455, 67);
            this.dtpPrevue.Name = "dtpPrevue";
            this.dtpPrevue.Size = new System.Drawing.Size(160, 27);
            this.dtpPrevue.TabIndex = 7;
            this.dtpPrevue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblStatut
            //
            this.lblStatut.Location = new System.Drawing.Point(650, 70);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(100, 20);
            this.lblStatut.TabIndex = 8;
            this.lblStatut.Text = "Statut";
            this.lblStatut.AutoSize = true;
            //
            // cboStatut
            //
            this.cboStatut.Location = new System.Drawing.Point(710, 67);
            this.cboStatut.Name = "cboStatut";
            this.cboStatut.Size = new System.Drawing.Size(200, 28);
            this.cboStatut.TabIndex = 9;
            this.cboStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // chkLivree
            //
            this.chkLivree.Location = new System.Drawing.Point(15, 107);
            this.chkLivree.Name = "chkLivree";
            this.chkLivree.Size = new System.Drawing.Size(120, 24);
            this.chkLivree.TabIndex = 10;
            this.chkLivree.Text = "Livrée le";
            this.chkLivree.AutoSize = true;
            this.chkLivree.UseVisualStyleBackColor = true;
            this.chkLivree.CheckedChanged += new System.EventHandler(this.chkLivree_CheckedChanged);
            //
            // dtpReelle
            //
            this.dtpReelle.Location = new System.Drawing.Point(140, 102);
            this.dtpReelle.Name = "dtpReelle";
            this.dtpReelle.Size = new System.Drawing.Size(160, 27);
            this.dtpReelle.TabIndex = 11;
            this.dtpReelle.Enabled = false;
            this.dtpReelle.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblTotal
            //
            this.lblTotal.Location = new System.Drawing.Point(470, 105);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(300, 20);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Montant total : 0,000 DT";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.AutoSize = true;
            //
            // lblLignes
            //
            this.lblLignes.Location = new System.Drawing.Point(15, 145);
            this.lblLignes.Name = "lblLignes";
            this.lblLignes.Size = new System.Drawing.Size(100, 20);
            this.lblLignes.TabIndex = 13;
            this.lblLignes.Text = "Lignes de la commande";
            this.lblLignes.AutoSize = true;
            //
            // dgvLignes
            //
            this.dgvLignes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLignes.Location = new System.Drawing.Point(15, 170);
            this.dgvLignes.Name = "dgvLignes";
            this.dgvLignes.Size = new System.Drawing.Size(946, 105);
            this.dgvLignes.TabIndex = 14;
            this.dgvLignes.AllowUserToAddRows = false;
            this.dgvLignes.AllowUserToDeleteRows = false;
            this.dgvLignes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLignes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLignes.MultiSelect = false;
            this.dgvLignes.ReadOnly = true;
            this.dgvLignes.RowHeadersVisible = false;
            this.dgvLignes.RowHeadersWidth = 51;
            this.dgvLignes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //
            // lblArticleLigne
            //
            this.lblArticleLigne.Location = new System.Drawing.Point(15, 292);
            this.lblArticleLigne.Name = "lblArticleLigne";
            this.lblArticleLigne.Size = new System.Drawing.Size(100, 20);
            this.lblArticleLigne.TabIndex = 15;
            this.lblArticleLigne.Text = "Article";
            this.lblArticleLigne.AutoSize = true;
            //
            // cboArticleLigne
            //
            this.cboArticleLigne.Location = new System.Drawing.Point(80, 289);
            this.cboArticleLigne.Name = "cboArticleLigne";
            this.cboArticleLigne.Size = new System.Drawing.Size(330, 28);
            this.cboArticleLigne.TabIndex = 16;
            this.cboArticleLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblQteLigne
            //
            this.lblQteLigne.Location = new System.Drawing.Point(430, 292);
            this.lblQteLigne.Name = "lblQteLigne";
            this.lblQteLigne.Size = new System.Drawing.Size(100, 20);
            this.lblQteLigne.TabIndex = 17;
            this.lblQteLigne.Text = "Qté";
            this.lblQteLigne.AutoSize = true;
            //
            // nudQteLigne
            //
            this.nudQteLigne.Location = new System.Drawing.Point(470, 289);
            this.nudQteLigne.Name = "nudQteLigne";
            this.nudQteLigne.Size = new System.Drawing.Size(90, 27);
            this.nudQteLigne.TabIndex = 18;
            this.nudQteLigne.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudQteLigne.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.nudQteLigne.Value = new decimal(new int[] {1, 0, 0, 0});
            //
            // lblPrixLigne
            //
            this.lblPrixLigne.Location = new System.Drawing.Point(580, 292);
            this.lblPrixLigne.Name = "lblPrixLigne";
            this.lblPrixLigne.Size = new System.Drawing.Size(100, 20);
            this.lblPrixLigne.TabIndex = 19;
            this.lblPrixLigne.Text = "Prix unit.";
            this.lblPrixLigne.AutoSize = true;
            //
            // nudPrixLigne
            //
            this.nudPrixLigne.Location = new System.Drawing.Point(660, 289);
            this.nudPrixLigne.Name = "nudPrixLigne";
            this.nudPrixLigne.Size = new System.Drawing.Size(130, 27);
            this.nudPrixLigne.TabIndex = 20;
            this.nudPrixLigne.DecimalPlaces = 3;
            this.nudPrixLigne.Maximum = new decimal(new int[] {100000000, 0, 0, 0});
            //
            // btnAjouterLigne
            //
            this.btnAjouterLigne.Location = new System.Drawing.Point(810, 286);
            this.btnAjouterLigne.Name = "btnAjouterLigne";
            this.btnAjouterLigne.Size = new System.Drawing.Size(150, 34);
            this.btnAjouterLigne.TabIndex = 21;
            this.btnAjouterLigne.Text = "Ajouter la ligne";
            this.btnAjouterLigne.UseVisualStyleBackColor = true;
            this.btnAjouterLigne.Click += new System.EventHandler(this.btnAjouterLigne_Click);
            //
            // btnRetirerLigne
            //
            this.btnRetirerLigne.Location = new System.Drawing.Point(15, 330);
            this.btnRetirerLigne.Name = "btnRetirerLigne";
            this.btnRetirerLigne.Size = new System.Drawing.Size(180, 34);
            this.btnRetirerLigne.TabIndex = 22;
            this.btnRetirerLigne.Text = "Retirer la ligne";
            this.btnRetirerLigne.UseVisualStyleBackColor = true;
            this.btnRetirerLigne.Click += new System.EventHandler(this.btnRetirerLigne_Click);
            //
            // btnNouveau
            //
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNouveau.Location = new System.Drawing.Point(12, 646);
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
            this.btnEnregistrer.Location = new System.Drawing.Point(142, 646);
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
            this.btnSupprimer.Location = new System.Drawing.Point(272, 646);
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
            this.btnFermer.Location = new System.Drawing.Point(868, 646);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.TabIndex = 5;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // FormCommandes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.grpListe);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(1018, 747);
            this.Name = "FormCommandes";
            this.Text = "Bons de commande et suivi des commandes";
            this.Load += new System.EventHandler(this.FormCommandes_Load);
            this.grpListe.ResumeLayout(false);
            this.grpListe.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLignes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQteLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrixLigne)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpListe;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.CheckBox chkRetard;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.Label lblAcheteur;
        private System.Windows.Forms.ComboBox cboAcheteur;
        private System.Windows.Forms.Label lblDateCommande;
        private System.Windows.Forms.DateTimePicker dtpCommande;
        private System.Windows.Forms.Label lblDatePrevue;
        private System.Windows.Forms.DateTimePicker dtpPrevue;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cboStatut;
        private System.Windows.Forms.CheckBox chkLivree;
        private System.Windows.Forms.DateTimePicker dtpReelle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblLignes;
        private System.Windows.Forms.DataGridView dgvLignes;
        private System.Windows.Forms.Label lblArticleLigne;
        private System.Windows.Forms.ComboBox cboArticleLigne;
        private System.Windows.Forms.Label lblQteLigne;
        private System.Windows.Forms.NumericUpDown nudQteLigne;
        private System.Windows.Forms.Label lblPrixLigne;
        private System.Windows.Forms.NumericUpDown nudPrixLigne;
        private System.Windows.Forms.Button btnAjouterLigne;
        private System.Windows.Forms.Button btnRetirerLigne;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
