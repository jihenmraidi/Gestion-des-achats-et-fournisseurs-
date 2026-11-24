namespace GestionAchats.Forms
{
    partial class FormDemandes
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
            this.lblDemandeur = new System.Windows.Forms.Label();
            this.cboDemandeur = new System.Windows.Forms.ComboBox();
            this.lblArticle = new System.Windows.Forms.Label();
            this.cboArticle = new System.Windows.Forms.ComboBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.nudQuantite = new System.Windows.Forms.NumericUpDown();
            this.lblDateDemande = new System.Windows.Forms.Label();
            this.dtpDemande = new System.Windows.Forms.DateTimePicker();
            this.lblDateSouhaitee = new System.Windows.Forms.Label();
            this.dtpSouhaitee = new System.Windows.Forms.DateTimePicker();
            this.lblStatut = new System.Windows.Forms.Label();
            this.cboStatut = new System.Windows.Forms.ComboBox();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).BeginInit();
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
            this.grpListe.Size = new System.Drawing.Size(876, 270);
            this.grpListe.TabIndex = 0;
            this.grpListe.Text = "Liste des demandes d'achat";
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
            this.dgv.Size = new System.Drawing.Size(846, 190);
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
            this.grpDetails.Controls.Add(this.lblDemandeur);
            this.grpDetails.Controls.Add(this.cboDemandeur);
            this.grpDetails.Controls.Add(this.lblArticle);
            this.grpDetails.Controls.Add(this.cboArticle);
            this.grpDetails.Controls.Add(this.lblQuantite);
            this.grpDetails.Controls.Add(this.nudQuantite);
            this.grpDetails.Controls.Add(this.lblDateDemande);
            this.grpDetails.Controls.Add(this.dtpDemande);
            this.grpDetails.Controls.Add(this.lblDateSouhaitee);
            this.grpDetails.Controls.Add(this.dtpSouhaitee);
            this.grpDetails.Controls.Add(this.lblStatut);
            this.grpDetails.Controls.Add(this.cboStatut);
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Location = new System.Drawing.Point(12, 292);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(876, 160);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.Text = "Détails";
            this.grpDetails.TabStop = false;
            //
            // lblDemandeur
            //
            this.lblDemandeur.Location = new System.Drawing.Point(15, 38);
            this.lblDemandeur.Name = "lblDemandeur";
            this.lblDemandeur.Size = new System.Drawing.Size(100, 20);
            this.lblDemandeur.TabIndex = 0;
            this.lblDemandeur.Text = "Demandeur *";
            this.lblDemandeur.AutoSize = true;
            //
            // cboDemandeur
            //
            this.cboDemandeur.Location = new System.Drawing.Point(140, 35);
            this.cboDemandeur.Name = "cboDemandeur";
            this.cboDemandeur.Size = new System.Drawing.Size(280, 28);
            this.cboDemandeur.TabIndex = 1;
            this.cboDemandeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblArticle
            //
            this.lblArticle.Location = new System.Drawing.Point(15, 73);
            this.lblArticle.Name = "lblArticle";
            this.lblArticle.Size = new System.Drawing.Size(100, 20);
            this.lblArticle.TabIndex = 2;
            this.lblArticle.Text = "Article *";
            this.lblArticle.AutoSize = true;
            //
            // cboArticle
            //
            this.cboArticle.Location = new System.Drawing.Point(140, 70);
            this.cboArticle.Name = "cboArticle";
            this.cboArticle.Size = new System.Drawing.Size(280, 28);
            this.cboArticle.TabIndex = 3;
            this.cboArticle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblQuantite
            //
            this.lblQuantite.Location = new System.Drawing.Point(15, 108);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(100, 20);
            this.lblQuantite.TabIndex = 4;
            this.lblQuantite.Text = "Quantité *";
            this.lblQuantite.AutoSize = true;
            //
            // nudQuantite
            //
            this.nudQuantite.Location = new System.Drawing.Point(140, 105);
            this.nudQuantite.Name = "nudQuantite";
            this.nudQuantite.Size = new System.Drawing.Size(120, 27);
            this.nudQuantite.TabIndex = 5;
            this.nudQuantite.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudQuantite.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.nudQuantite.Value = new decimal(new int[] {1, 0, 0, 0});
            //
            // lblDateDemande
            //
            this.lblDateDemande.Location = new System.Drawing.Point(450, 38);
            this.lblDateDemande.Name = "lblDateDemande";
            this.lblDateDemande.Size = new System.Drawing.Size(100, 20);
            this.lblDateDemande.TabIndex = 6;
            this.lblDateDemande.Text = "Date de demande";
            this.lblDateDemande.AutoSize = true;
            //
            // dtpDemande
            //
            this.dtpDemande.Location = new System.Drawing.Point(600, 35);
            this.dtpDemande.Name = "dtpDemande";
            this.dtpDemande.Size = new System.Drawing.Size(200, 27);
            this.dtpDemande.TabIndex = 7;
            this.dtpDemande.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblDateSouhaitee
            //
            this.lblDateSouhaitee.Location = new System.Drawing.Point(450, 73);
            this.lblDateSouhaitee.Name = "lblDateSouhaitee";
            this.lblDateSouhaitee.Size = new System.Drawing.Size(100, 20);
            this.lblDateSouhaitee.TabIndex = 8;
            this.lblDateSouhaitee.Text = "Date souhaitée";
            this.lblDateSouhaitee.AutoSize = true;
            //
            // dtpSouhaitee
            //
            this.dtpSouhaitee.Location = new System.Drawing.Point(600, 70);
            this.dtpSouhaitee.Name = "dtpSouhaitee";
            this.dtpSouhaitee.Size = new System.Drawing.Size(200, 27);
            this.dtpSouhaitee.TabIndex = 9;
            this.dtpSouhaitee.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblStatut
            //
            this.lblStatut.Location = new System.Drawing.Point(450, 108);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(100, 20);
            this.lblStatut.TabIndex = 10;
            this.lblStatut.Text = "Statut";
            this.lblStatut.AutoSize = true;
            //
            // cboStatut
            //
            this.cboStatut.Location = new System.Drawing.Point(600, 105);
            this.cboStatut.Name = "cboStatut";
            this.cboStatut.Size = new System.Drawing.Size(200, 28);
            this.cboStatut.TabIndex = 11;
            this.cboStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // FormDemandes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 512);
            this.Controls.Add(this.grpListe);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(918, 559);
            this.Name = "FormDemandes";
            this.Text = "Demandes d'achat";
            this.Load += new System.EventHandler(this.FormDemandes_Load);
            this.grpListe.ResumeLayout(false);
            this.grpListe.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantite)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpListe;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblDemandeur;
        private System.Windows.Forms.ComboBox cboDemandeur;
        private System.Windows.Forms.Label lblArticle;
        private System.Windows.Forms.ComboBox cboArticle;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.NumericUpDown nudQuantite;
        private System.Windows.Forms.Label lblDateDemande;
        private System.Windows.Forms.DateTimePicker dtpDemande;
        private System.Windows.Forms.Label lblDateSouhaitee;
        private System.Windows.Forms.DateTimePicker dtpSouhaitee;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.ComboBox cboStatut;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
