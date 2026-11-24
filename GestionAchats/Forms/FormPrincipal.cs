using System;
using System.Windows.Forms;

namespace GestionAchats.Forms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Ouvre une fenêtre fille ; si elle est déjà ouverte, on la remet simplement au premier plan
        private void OuvrirFenetre<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T)
                {
                    f.Activate();
                    return;
                }
            }

            T fenetre = new T();
            fenetre.MdiParent = this;
            fenetre.Show();
        }

        // ----- Menu Gestion -----
        private void itemFournisseurs_Click(object sender, EventArgs e) { OuvrirFenetre<FormFournisseurs>(); }
        private void itemArticles_Click(object sender, EventArgs e) { OuvrirFenetre<FormArticles>(); }
        private void itemUtilisateurs_Click(object sender, EventArgs e) { OuvrirFenetre<FormUtilisateurs>(); }
        private void itemQuitter_Click(object sender, EventArgs e) { Close(); }

        // ----- Menu Achats -----
        private void itemDemandes_Click(object sender, EventArgs e) { OuvrirFenetre<FormDemandes>(); }
        private void itemOffres_Click(object sender, EventArgs e) { OuvrirFenetre<FormOffres>(); }
        private void itemCommandes_Click(object sender, EventArgs e) { OuvrirFenetre<FormCommandes>(); }
        private void itemReceptions_Click(object sender, EventArgs e) { OuvrirFenetre<FormReceptions>(); }

        // ----- Menu Suivi -----
        private void itemEvaluations_Click(object sender, EventArgs e) { OuvrirFenetre<FormEvaluations>(); }
        private void itemHistorique_Click(object sender, EventArgs e) { OuvrirFenetre<FormHistorique>(); }
        private void itemTableauBord_Click(object sender, EventArgs e) { OuvrirFenetre<FormTableauBord>(); }
    }
}
