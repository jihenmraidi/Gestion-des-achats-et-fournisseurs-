namespace GestionAchats.Forms
{
    partial class FormOffres
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
            this.lblFiltre = new System.Windows.Forms.Label();
            this.cboFiltreDemande = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblDemande = new System.Windows.Forms.Label();
            this.cboDemande = new System.Windows.Forms.ComboBox();
            this.lblCoutTotal = new System.Windows.Forms.Label();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.lblTransport = new System.Windows.Forms.Label();
            this.nudTransport = new System.Windows.Forms.NumericUpDown();
            this.lblPrix = new System.Windows.Forms.Label();
            this.nudPrix = new System.Windows.Forms.NumericUpDown();
            this.lblDelai = new System.Windows.Forms.Label();
            this.nudDelai = new System.Windows.Forms.NumericUpDown();
            this.lblRemise = new System.Windows.Forms.Label();
            this.nudRemise = new System.Windows.Forms.NumericUpDown();
            this.grpComparaison = new System.Windows.Forms.GroupBox();
            this.lblPoidsPrix = new System.Windows.Forms.Label();
            this.nudPoidsPrix = new System.Windows.Forms.NumericUpDown();
            this.lblPoidsDelai = new System.Windows.Forms.Label();
            this.nudPoidsDelai = new System.Windows.Forms.NumericUpDown();
            this.lblPoidsFiab = new System.Windows.Forms.Label();
            this.nudPoidsFiab = new System.Windows.Forms.NumericUpDown();
            this.btnComparer = new System.Windows.Forms.Button();
            this.lblAcheteur = new System.Windows.Forms.Label();
            this.cboAcheteur = new System.Windows.Forms.ComboBox();
            this.btnCreerCommande = new System.Windows.Forms.Button();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsDelai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsFiab)).BeginInit();
            this.grpListe.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.grpComparaison.SuspendLayout();
            this.SuspendLayout();
            //
            // grpListe
            //
            this.grpListe.Controls.Add(this.lblFiltre);
            this.grpListe.Controls.Add(this.cboFiltreDemande);
            this.grpListe.Controls.Add(this.dgv);
            this.grpListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpListe.Location = new System.Drawing.Point(12, 12);
            this.grpListe.Name = "grpListe";
            this.grpListe.Size = new System.Drawing.Size(976, 250);
            this.grpListe.TabIndex = 0;
            this.grpListe.Text = "Liste des offres";
            this.grpListe.TabStop = false;
            //
            // lblFiltre
            //
            this.lblFiltre.Location = new System.Drawing.Point(15, 30);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(100, 20);
            this.lblFiltre.TabIndex = 0;
            this.lblFiltre.Text = "Demande";
            this.lblFiltre.AutoSize = true;
            //
            // cboFiltreDemande
            //
            this.cboFiltreDemande.Location = new System.Drawing.Point(110, 27);
            this.cboFiltreDemande.Name = "cboFiltreDemande";
            this.cboFiltreDemande.Size = new System.Drawing.Size(600, 28);
            this.cboFiltreDemande.TabIndex = 1;
            this.cboFiltreDemande.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltreDemande.SelectedIndexChanged += new System.EventHandler(this.cboFiltreDemande_SelectedIndexChanged);
            //
            // dgv
            //
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(15, 65);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(946, 170);
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
            this.grpDetails.Controls.Add(this.lblDemande);
            this.grpDetails.Controls.Add(this.cboDemande);
            this.grpDetails.Controls.Add(this.lblCoutTotal);
            this.grpDetails.Controls.Add(this.lblFournisseur);
            this.grpDetails.Controls.Add(this.cboFournisseur);
            this.grpDetails.Controls.Add(this.lblTransport);
            this.grpDetails.Controls.Add(this.nudTransport);
            this.grpDetails.Controls.Add(this.lblPrix);
            this.grpDetails.Controls.Add(this.nudPrix);
            this.grpDetails.Controls.Add(this.lblDelai);
            this.grpDetails.Controls.Add(this.nudDelai);
            this.grpDetails.Controls.Add(this.lblRemise);
            this.grpDetails.Controls.Add(this.nudRemise);
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Location = new System.Drawing.Point(12, 272);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(976, 150);
            this.grpDetails.TabIndex = 1;
            this.grpDetails.Text = "Détails de l'offre";
            this.grpDetails.TabStop = false;
            //
            // lblDemande
            //
            this.lblDemande.Location = new System.Drawing.Point(15, 35);
            this.lblDemande.Name = "lblDemande";
            this.lblDemande.Size = new System.Drawing.Size(100, 20);
            this.lblDemande.TabIndex = 0;
            this.lblDemande.Text = "Demande *";
            this.lblDemande.AutoSize = true;
            //
            // cboDemande
            //
            this.cboDemande.Location = new System.Drawing.Point(140, 32);
            this.cboDemande.Name = "cboDemande";
            this.cboDemande.Size = new System.Drawing.Size(520, 28);
            this.cboDemande.TabIndex = 1;
            this.cboDemande.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDemande.SelectedIndexChanged += new System.EventHandler(this.cboDemande_SelectedIndexChanged);
            //
            // lblCoutTotal
            //
            this.lblCoutTotal.Location = new System.Drawing.Point(690, 35);
            this.lblCoutTotal.Name = "lblCoutTotal";
            this.lblCoutTotal.Size = new System.Drawing.Size(200, 20);
            this.lblCoutTotal.TabIndex = 2;
            this.lblCoutTotal.Text = "Coût total : 0,000 DT";
            this.lblCoutTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCoutTotal.AutoSize = true;
            //
            // lblFournisseur
            //
            this.lblFournisseur.Location = new System.Drawing.Point(15, 70);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(100, 20);
            this.lblFournisseur.TabIndex = 3;
            this.lblFournisseur.Text = "Fournisseur *";
            this.lblFournisseur.AutoSize = true;
            //
            // cboFournisseur
            //
            this.cboFournisseur.Location = new System.Drawing.Point(140, 67);
            this.cboFournisseur.Name = "cboFournisseur";
            this.cboFournisseur.Size = new System.Drawing.Size(300, 28);
            this.cboFournisseur.TabIndex = 4;
            this.cboFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // lblTransport
            //
            this.lblTransport.Location = new System.Drawing.Point(470, 70);
            this.lblTransport.Name = "lblTransport";
            this.lblTransport.Size = new System.Drawing.Size(100, 20);
            this.lblTransport.TabIndex = 5;
            this.lblTransport.Text = "Frais de transport";
            this.lblTransport.AutoSize = true;
            //
            // nudTransport
            //
            this.nudTransport.Location = new System.Drawing.Point(620, 67);
            this.nudTransport.Name = "nudTransport";
            this.nudTransport.Size = new System.Drawing.Size(140, 27);
            this.nudTransport.TabIndex = 6;
            this.nudTransport.DecimalPlaces = 3;
            this.nudTransport.Maximum = new decimal(new int[] {100000000, 0, 0, 0});
            this.nudTransport.ValueChanged += new System.EventHandler(this.nudCout_ValueChanged);
            //
            // lblPrix
            //
            this.lblPrix.Location = new System.Drawing.Point(15, 105);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPrix.TabIndex = 7;
            this.lblPrix.Text = "Prix unitaire *";
            this.lblPrix.AutoSize = true;
            //
            // nudPrix
            //
            this.nudPrix.Location = new System.Drawing.Point(140, 102);
            this.nudPrix.Name = "nudPrix";
            this.nudPrix.Size = new System.Drawing.Size(140, 27);
            this.nudPrix.TabIndex = 8;
            this.nudPrix.DecimalPlaces = 3;
            this.nudPrix.Maximum = new decimal(new int[] {100000000, 0, 0, 0});
            this.nudPrix.ValueChanged += new System.EventHandler(this.nudCout_ValueChanged);
            //
            // lblDelai
            //
            this.lblDelai.Location = new System.Drawing.Point(320, 105);
            this.lblDelai.Name = "lblDelai";
            this.lblDelai.Size = new System.Drawing.Size(100, 20);
            this.lblDelai.TabIndex = 9;
            this.lblDelai.Text = "Délai (jours) *";
            this.lblDelai.AutoSize = true;
            //
            // nudDelai
            //
            this.nudDelai.Location = new System.Drawing.Point(440, 102);
            this.nudDelai.Name = "nudDelai";
            this.nudDelai.Size = new System.Drawing.Size(100, 27);
            this.nudDelai.TabIndex = 10;
            this.nudDelai.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nudDelai.Maximum = new decimal(new int[] {3650, 0, 0, 0});
            this.nudDelai.Value = new decimal(new int[] {7, 0, 0, 0});
            //
            // lblRemise
            //
            this.lblRemise.Location = new System.Drawing.Point(570, 105);
            this.lblRemise.Name = "lblRemise";
            this.lblRemise.Size = new System.Drawing.Size(100, 20);
            this.lblRemise.TabIndex = 11;
            this.lblRemise.Text = "Remise (%)";
            this.lblRemise.AutoSize = true;
            //
            // nudRemise
            //
            this.nudRemise.Location = new System.Drawing.Point(670, 102);
            this.nudRemise.Name = "nudRemise";
            this.nudRemise.Size = new System.Drawing.Size(100, 27);
            this.nudRemise.TabIndex = 12;
            this.nudRemise.DecimalPlaces = 2;
            this.nudRemise.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.nudRemise.ValueChanged += new System.EventHandler(this.nudCout_ValueChanged);
            //
            // grpComparaison
            //
            this.grpComparaison.Controls.Add(this.lblPoidsPrix);
            this.grpComparaison.Controls.Add(this.nudPoidsPrix);
            this.grpComparaison.Controls.Add(this.lblPoidsDelai);
            this.grpComparaison.Controls.Add(this.nudPoidsDelai);
            this.grpComparaison.Controls.Add(this.lblPoidsFiab);
            this.grpComparaison.Controls.Add(this.nudPoidsFiab);
            this.grpComparaison.Controls.Add(this.btnComparer);
            this.grpComparaison.Controls.Add(this.lblAcheteur);
            this.grpComparaison.Controls.Add(this.cboAcheteur);
            this.grpComparaison.Controls.Add(this.btnCreerCommande);
            this.grpComparaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpComparaison.Location = new System.Drawing.Point(12, 432);
            this.grpComparaison.Name = "grpComparaison";
            this.grpComparaison.Size = new System.Drawing.Size(976, 110);
            this.grpComparaison.TabIndex = 2;
            this.grpComparaison.Text = "Comparaison et validation (offres de la demande choisie en haut)";
            this.grpComparaison.TabStop = false;
            //
            // lblPoidsPrix
            //
            this.lblPoidsPrix.Location = new System.Drawing.Point(15, 35);
            this.lblPoidsPrix.Name = "lblPoidsPrix";
            this.lblPoidsPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPoidsPrix.TabIndex = 0;
            this.lblPoidsPrix.Text = "Poids prix";
            this.lblPoidsPrix.AutoSize = true;
            //
            // nudPoidsPrix
            //
            this.nudPoidsPrix.Location = new System.Drawing.Point(100, 32);
            this.nudPoidsPrix.Name = "nudPoidsPrix";
            this.nudPoidsPrix.Size = new System.Drawing.Size(70, 27);
            this.nudPoidsPrix.TabIndex = 1;
            this.nudPoidsPrix.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.nudPoidsPrix.Value = new decimal(new int[] {50, 0, 0, 0});
            //
            // lblPoidsDelai
            //
            this.lblPoidsDelai.Location = new System.Drawing.Point(190, 35);
            this.lblPoidsDelai.Name = "lblPoidsDelai";
            this.lblPoidsDelai.Size = new System.Drawing.Size(100, 20);
            this.lblPoidsDelai.TabIndex = 2;
            this.lblPoidsDelai.Text = "Poids délai";
            this.lblPoidsDelai.AutoSize = true;
            //
            // nudPoidsDelai
            //
            this.nudPoidsDelai.Location = new System.Drawing.Point(285, 32);
            this.nudPoidsDelai.Name = "nudPoidsDelai";
            this.nudPoidsDelai.Size = new System.Drawing.Size(70, 27);
            this.nudPoidsDelai.TabIndex = 3;
            this.nudPoidsDelai.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.nudPoidsDelai.Value = new decimal(new int[] {30, 0, 0, 0});
            //
            // lblPoidsFiab
            //
            this.lblPoidsFiab.Location = new System.Drawing.Point(375, 35);
            this.lblPoidsFiab.Name = "lblPoidsFiab";
            this.lblPoidsFiab.Size = new System.Drawing.Size(100, 20);
            this.lblPoidsFiab.TabIndex = 4;
            this.lblPoidsFiab.Text = "Poids fiabilité";
            this.lblPoidsFiab.AutoSize = true;
            //
            // nudPoidsFiab
            //
            this.nudPoidsFiab.Location = new System.Drawing.Point(485, 32);
            this.nudPoidsFiab.Name = "nudPoidsFiab";
            this.nudPoidsFiab.Size = new System.Drawing.Size(70, 27);
            this.nudPoidsFiab.TabIndex = 5;
            this.nudPoidsFiab.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.nudPoidsFiab.Value = new decimal(new int[] {20, 0, 0, 0});
            //
            // btnComparer
            //
            this.btnComparer.Location = new System.Drawing.Point(590, 28);
            this.btnComparer.Name = "btnComparer";
            this.btnComparer.Size = new System.Drawing.Size(220, 34);
            this.btnComparer.TabIndex = 6;
            this.btnComparer.Text = "Comparer les offres";
            this.btnComparer.UseVisualStyleBackColor = true;
            this.btnComparer.Click += new System.EventHandler(this.btnComparer_Click);
            //
            // lblAcheteur
            //
            this.lblAcheteur.Location = new System.Drawing.Point(15, 75);
            this.lblAcheteur.Name = "lblAcheteur";
            this.lblAcheteur.Size = new System.Drawing.Size(100, 20);
            this.lblAcheteur.TabIndex = 7;
            this.lblAcheteur.Text = "Acheteur";
            this.lblAcheteur.AutoSize = true;
            //
            // cboAcheteur
            //
            this.cboAcheteur.Location = new System.Drawing.Point(100, 72);
            this.cboAcheteur.Name = "cboAcheteur";
            this.cboAcheteur.Size = new System.Drawing.Size(255, 28);
            this.cboAcheteur.TabIndex = 8;
            this.cboAcheteur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //
            // btnCreerCommande
            //
            this.btnCreerCommande.Location = new System.Drawing.Point(375, 68);
            this.btnCreerCommande.Name = "btnCreerCommande";
            this.btnCreerCommande.Size = new System.Drawing.Size(435, 34);
            this.btnCreerCommande.TabIndex = 9;
            this.btnCreerCommande.Text = "Valider l'offre sélectionnée et créer le bon de commande";
            this.btnCreerCommande.UseVisualStyleBackColor = true;
            this.btnCreerCommande.Click += new System.EventHandler(this.btnCreerCommande_Click);
            //
            // btnNouveau
            //
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNouveau.Location = new System.Drawing.Point(12, 556);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 34);
            this.btnNouveau.TabIndex = 3;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            //
            // btnEnregistrer
            //
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnregistrer.Location = new System.Drawing.Point(142, 556);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 34);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSupprimer.Location = new System.Drawing.Point(272, 556);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 34);
            this.btnSupprimer.TabIndex = 5;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(868, 556);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.TabIndex = 6;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // FormOffres
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.grpListe);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpComparaison);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(1018, 657);
            this.Name = "FormOffres";
            this.Text = "Offres des fournisseurs";
            this.Load += new System.EventHandler(this.FormOffres_Load);
            this.grpListe.ResumeLayout(false);
            this.grpListe.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpComparaison.ResumeLayout(false);
            this.grpComparaison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRemise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsDelai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPoidsFiab)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpListe;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.ComboBox cboFiltreDemande;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblDemande;
        private System.Windows.Forms.ComboBox cboDemande;
        private System.Windows.Forms.Label lblCoutTotal;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.Label lblTransport;
        private System.Windows.Forms.NumericUpDown nudTransport;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.NumericUpDown nudPrix;
        private System.Windows.Forms.Label lblDelai;
        private System.Windows.Forms.NumericUpDown nudDelai;
        private System.Windows.Forms.Label lblRemise;
        private System.Windows.Forms.NumericUpDown nudRemise;
        private System.Windows.Forms.GroupBox grpComparaison;
        private System.Windows.Forms.Label lblPoidsPrix;
        private System.Windows.Forms.NumericUpDown nudPoidsPrix;
        private System.Windows.Forms.Label lblPoidsDelai;
        private System.Windows.Forms.NumericUpDown nudPoidsDelai;
        private System.Windows.Forms.Label lblPoidsFiab;
        private System.Windows.Forms.NumericUpDown nudPoidsFiab;
        private System.Windows.Forms.Button btnComparer;
        private System.Windows.Forms.Label lblAcheteur;
        private System.Windows.Forms.ComboBox cboAcheteur;
        private System.Windows.Forms.Button btnCreerCommande;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnFermer;
    }
}
