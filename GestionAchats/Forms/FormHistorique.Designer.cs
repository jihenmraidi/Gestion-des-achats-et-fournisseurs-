namespace GestionAchats.Forms
{
    partial class FormHistorique
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
            this.grpFiltres = new System.Windows.Forms.GroupBox();
            this.lblFournisseur = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.chkPeriode = new System.Windows.Forms.CheckBox();
            this.dtpDu = new System.Windows.Forms.DateTimePicker();
            this.lblAu = new System.Windows.Forms.Label();
            this.dtpAu = new System.Windows.Forms.DateTimePicker();
            this.grpHistorique = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.lblResume = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.grpFiltres.SuspendLayout();
            this.grpHistorique.SuspendLayout();
            this.SuspendLayout();
            //
            // grpFiltres
            //
            this.grpFiltres.Controls.Add(this.lblFournisseur);
            this.grpFiltres.Controls.Add(this.cboFournisseur);
            this.grpFiltres.Controls.Add(this.chkPeriode);
            this.grpFiltres.Controls.Add(this.dtpDu);
            this.grpFiltres.Controls.Add(this.lblAu);
            this.grpFiltres.Controls.Add(this.dtpAu);
            this.grpFiltres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltres.Location = new System.Drawing.Point(12, 12);
            this.grpFiltres.Name = "grpFiltres";
            this.grpFiltres.Size = new System.Drawing.Size(976, 80);
            this.grpFiltres.TabIndex = 0;
            this.grpFiltres.Text = "Filtres";
            this.grpFiltres.TabStop = false;
            //
            // lblFournisseur
            //
            this.lblFournisseur.Location = new System.Drawing.Point(15, 35);
            this.lblFournisseur.Name = "lblFournisseur";
            this.lblFournisseur.Size = new System.Drawing.Size(100, 20);
            this.lblFournisseur.TabIndex = 0;
            this.lblFournisseur.Text = "Fournisseur";
            this.lblFournisseur.AutoSize = true;
            //
            // cboFournisseur
            //
            this.cboFournisseur.Location = new System.Drawing.Point(120, 32);
            this.cboFournisseur.Name = "cboFournisseur";
            this.cboFournisseur.Size = new System.Drawing.Size(300, 28);
            this.cboFournisseur.TabIndex = 1;
            this.cboFournisseur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFournisseur.SelectedIndexChanged += new System.EventHandler(this.cboFournisseur_SelectedIndexChanged);
            //
            // chkPeriode
            //
            this.chkPeriode.Location = new System.Drawing.Point(450, 34);
            this.chkPeriode.Name = "chkPeriode";
            this.chkPeriode.Size = new System.Drawing.Size(110, 24);
            this.chkPeriode.TabIndex = 2;
            this.chkPeriode.Text = "Période du";
            this.chkPeriode.AutoSize = true;
            this.chkPeriode.UseVisualStyleBackColor = true;
            this.chkPeriode.CheckedChanged += new System.EventHandler(this.chkPeriode_CheckedChanged);
            //
            // dtpDu
            //
            this.dtpDu.Location = new System.Drawing.Point(565, 32);
            this.dtpDu.Name = "dtpDu";
            this.dtpDu.Size = new System.Drawing.Size(150, 27);
            this.dtpDu.TabIndex = 3;
            this.dtpDu.Enabled = false;
            this.dtpDu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDu.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            //
            // lblAu
            //
            this.lblAu.Location = new System.Drawing.Point(730, 35);
            this.lblAu.Name = "lblAu";
            this.lblAu.Size = new System.Drawing.Size(100, 20);
            this.lblAu.TabIndex = 4;
            this.lblAu.Text = "au";
            this.lblAu.AutoSize = true;
            //
            // dtpAu
            //
            this.dtpAu.Location = new System.Drawing.Point(765, 32);
            this.dtpAu.Name = "dtpAu";
            this.dtpAu.Size = new System.Drawing.Size(150, 27);
            this.dtpAu.TabIndex = 5;
            this.dtpAu.Enabled = false;
            this.dtpAu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAu.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            //
            // grpHistorique
            //
            this.grpHistorique.Controls.Add(this.dgv);
            this.grpHistorique.Controls.Add(this.lblResume);
            this.grpHistorique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpHistorique.Location = new System.Drawing.Point(12, 102);
            this.grpHistorique.Name = "grpHistorique";
            this.grpHistorique.Size = new System.Drawing.Size(976, 450);
            this.grpHistorique.TabIndex = 1;
            this.grpHistorique.Text = "Historique des commandes";
            this.grpHistorique.TabStop = false;
            //
            // dgv
            //
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(15, 30);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(946, 380);
            this.dgv.TabIndex = 0;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.MultiSelect = false;
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //
            // lblResume
            //
            this.lblResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResume.Location = new System.Drawing.Point(15, 420);
            this.lblResume.Name = "lblResume";
            this.lblResume.Size = new System.Drawing.Size(700, 20);
            this.lblResume.TabIndex = 1;
            this.lblResume.Text = "-";
            this.lblResume.AutoSize = true;
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(868, 566);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.TabIndex = 2;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            //
            // FormHistorique
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 612);
            this.Controls.Add(this.grpFiltres);
            this.Controls.Add(this.grpHistorique);
            this.Controls.Add(this.btnFermer);
            this.MinimumSize = new System.Drawing.Size(1018, 659);
            this.Name = "FormHistorique";
            this.Text = "Historique des commandes";
            this.Load += new System.EventHandler(this.FormHistorique_Load);
            this.grpFiltres.ResumeLayout(false);
            this.grpFiltres.PerformLayout();
            this.grpHistorique.ResumeLayout(false);
            this.grpHistorique.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltres;
        private System.Windows.Forms.Label lblFournisseur;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.CheckBox chkPeriode;
        private System.Windows.Forms.DateTimePicker dtpDu;
        private System.Windows.Forms.Label lblAu;
        private System.Windows.Forms.DateTimePicker dtpAu;
        private System.Windows.Forms.GroupBox grpHistorique;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblResume;
        private System.Windows.Forms.Button btnFermer;
    }
}
