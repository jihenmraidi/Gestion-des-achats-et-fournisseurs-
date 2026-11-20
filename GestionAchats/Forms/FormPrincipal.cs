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

        private void itemFournisseurs_Click(object sender, EventArgs e)
        {
            OuvrirFenetre<FormFournisseurs>();
        }

        private void itemArticles_Click(object sender, EventArgs e)
        {
            OuvrirFenetre<FormArticles>();
        }

        private void itemQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
