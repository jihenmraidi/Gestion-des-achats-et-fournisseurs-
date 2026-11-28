namespace GestionAchats.Forms
{
    partial class FormReceptions
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
            this.lblCommande = new System.Windows.Forms.Label();
            this.cboCommande = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblDateReception = new System.Windows.Forms.Label();
            this.dtpReception = new System.Windows.Forms.DateTimePicker();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.nudQuantite = new System.Windows.Forms.NumericUpDown();
            this.chkConforme = new System.Windows.Forms.CheckBox();
            this.lblRemarque = new System.Windows.Forms.Label();
            this.txtRemarque = new System.Windows.Forms.TextBox();
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
            this.grpListe.Size = new System.Drawing.Size(876, 250);
            this.grpListe.TabIndex = 0;
            this.grpListe.Text = "Liste des réceptions";
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
            this.grpDetails.Controls.Add(this.lblCommande);
            this.grpDetails.Controls.Add(this.cboCommande);
            this.grpDetails.Controls.Add(this.lblInfo);
            this.grpDetails.Controls.Add(this.lblDateReception);
            this.grpDetails.Controls.Add(this.dtpReception);
            this.grpDetails.Controls.Add(this.lblQuantite);
            this.grpDetails.Controls.Add(this.nudQuantite);
            this.grpDetails.Controls.Add(this.chkConforme);
            this.grpDetails.Controls.Add(this.lblRemarque);
            this.grpDetails.Controls.Add(this.txtRemarque);
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Location = new System.Drawing.Point(12, 272);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(876, 185);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.Text = "Détails";
            this.grpDetails.TabStop = false;
            //
            // lblCommande
            //
            this.lblCommande.Location = new System.Drawing.Point(15, 35);
            this.lblCommande.Name = "lblCommande";
            this.lblCommande.Size = new System.Drawing.Size(100, 20);
            this.lblCommande.TabIndex = 0;
            this.lblCommande.Text = "Commande *";
            this.lblCommande.AutoSize = true;
            //
            // cboCommande
            //
            this.cboCommande.Location = new System.Drawing.Point(140, 32);
            this.cboCommande.Name = "cboCommande";
            this.cboCommande.Size = new System.Drawing.Size(520, 28);
            this.cboCommande.TabIndex = 1;
            this.cboCommande.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCommande.SelectedIndexChanged += new System.EventHandler(this.cboCommande_SelectedIndexChanged);
            //
            // lblInfo
            //
            this.lblInfo.Location = new System.Drawing.Point(140, 68);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(600, 20);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Commandé : 0   |   Déjà reçu : 0   |   Reste : 0";
            this.lblInfo.AutoSize = true;
            //
            // lblDateReception
            //
            this.lblDateReception.Location = new System.Drawing.Point(15, 103);
            this.lblDateReception.Name = "lblDateReception";
            this.lblDateReception.Size = new System.Drawing.Size(100, 20);
            this.lblDateReception.TabIndex = 3;
            this.lblDateReception.Text = "Date réception";
            this.lblDateReception.AutoSize = true;
            //
            // dtpReception
            //
            this.dtpReception.Location = new System.Drawing.Point(140, 100);
            this.dtpReception.Name = "dtpReception";
            this.dtpReception.Size = new System.Drawing.Size(160, 27);
            this.dtpReception.TabIndex = 4;
            this.dtpReception.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            //
            // lblQuantite
            //
            this.lblQuantite.Location = new System.Drawing.Point(340, 103);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(100, 20);
            this.lblQuantite.TabIndex = 5;
            this.lblQuantite.Text = "Quantité reçue *";
            this.lblQuantite.AutoSize = true;
            //
            // nudQuantite
            //
            this.nudQuantite.Location = new System.Drawing.Point(470, 100);
            this.nudQuantite.Name = "nudQuantite";
            this.nudQuantite.Size = new System.Drawing.Size(110, 27);
            this.nudQuantite.TabIndex = 6;
            this.nudQuantite.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudQuantite.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.nudQuantite.Value = new decimal(new int[] {1, 0, 0, 0});
            //
            // chkConforme
            //
            this.chkConforme.Location = new System.Drawing.Point(610, 102);
            this.chkConforme.Name = "chkConforme";
            this.chkConforme.Size = new System.Drawing.Size(120, 24);
            this.chkConforme.TabIndex = 7;
            this.chkConforme.Text = "Conforme";
            this.chkConforme.Checked = true;
            this.chkConforme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConforme.AutoSize = true;
            this.chkConforme.UseVisualStyleBackColor = true;
            //
            // lblRemarque
            //
            this.lblRemarque.Location = new System.Drawing.Point(15, 138);
            this.lblRemarque.Name = "lblRemarque";
            this.lblRemarque.Size = new System.Drawing.Size(100, 20);
            this.lblRemarque.TabIndex = 8;
            this.lblRemarque.Text = "Remarque";
            this.lblRemarque.AutoSize = true;
            //
            // txtRemarque
            //
            this.txtRemarque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarque.Location = new System.Drawing.Point(140, 135);
            this.txtRemarque.Name = "txtRemarque";
            this.txtRemarque.Size = new System.Drawing.Size(720, 27);
            this.txtRemarque.TabIndex = 9;
            this.txtRemarque.MaxLength = 250;
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
            // FormReceptions
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.grpListe);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(918, 577);
            this.Name = "FormReceptions";
            this.Text = "Réception des commandes";
            this.Load += new System.EventHandler(this.FormReceptions_Load);
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
        private System.Windows.Forms.Label lblCommande;
        private System.Windows.Forms.ComboBox cboCommande;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblDateReception;
        private System.Windows.Forms.DateTimePicker dtpReception;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.NumericUpDown nudQuantite;
        private System.Windows.Forms.CheckBox chkConforme;
        private System.Windows.Forms.Label lblRemarque;
        private System.Windows.Forms.TextBox txtRemarque;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
