using System;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    public partial class FormArticles : Form
    {
        private int _id;            // 0 = nouvel article, sinon Id de l'article affiché
        private bool _chargement;   // évite de réagir aux changements de sélection faits par le code

        public FormArticles()
        {
            InitializeComponent();
        }

        private void FormArticles_Load(object sender, EventArgs e)
        {
            cboUnite.Items.AddRange(new object[] { "Pièce", "Boîte", "Carton", "Kg", "Litre", "Mètre" });
            ChargerCategories();
            ChargerListe();
        }

        // Propose les catégories déjà utilisées (la saisie d'une nouvelle catégorie reste possible)
        private void ChargerCategories()
        {
            string saisie = cboCategorie.Text;
            using (var db = new GestionAchatsContext())
            {
                var categories = db.Articles.AsNoTracking()
                    .Where(a => a.Categorie != null && a.Categorie != "")
                    .Select(a => a.Categorie)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();

                cboCategorie.Items.Clear();
                cboCategorie.Items.AddRange(categories.Cast<object>().ToArray());
            }
            cboCategorie.Text = saisie;
        }

        // ---------- READ : liste ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                IQueryable<Article> requete = db.Articles.AsNoTracking();
                if (filtre.Length > 0)
                    requete = requete.Where(a => a.Reference.Contains(filtre) || a.Designation.Contains(filtre));

                var liste = requete
                    .OrderBy(a => a.Reference)
                    .Select(a => new { a.Id, a.Reference, a.Designation, a.Unite, a.Categorie })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Reference"].HeaderText = "Référence";
                dgv.Columns["Designation"].HeaderText = "Désignation";
                dgv.Columns["Unite"].HeaderText = "Unité";
                dgv.Columns["Categorie"].HeaderText = "Catégorie";
                if (idSelection != 0)
                    SelectionnerLigne(idSelection);
                _chargement = false;
            }

            if (dgv.CurrentRow != null)
                Afficher((int)dgv.CurrentRow.Cells["Id"].Value);
            else
                NouvelArticle();
        }

        private void SelectionnerLigne(int id)
        {
            foreach (DataGridViewRow ligne in dgv.Rows)
            {
                if ((int)ligne.Cells["Id"].Value == id)
                {
                    dgv.CurrentCell = ligne.Cells["Reference"];
                    return;
                }
            }
        }

        private void Afficher(int id)
        {
            using (var db = new GestionAchatsContext())
            {
                Article a = db.Articles.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (a == null)
                {
                    NouvelArticle();
                    return;
                }

                _id = a.Id;
                txtReference.Text = a.Reference;
                txtDesignation.Text = a.Designation;
                cboUnite.Text = a.Unite;
                cboCategorie.Text = a.Categorie;
            }
            grpDetails.Text = "Modifier l'article";
            btnSupprimer.Enabled = true;
        }

        private void NouvelArticle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            txtReference.Clear();
            txtDesignation.Clear();
            cboUnite.Text = "";
            cboCategorie.Text = "";
            grpDetails.Text = "Nouvel article";
            btnSupprimer.Enabled = false;
            txtReference.Focus();
        }

        // ---------- Événements ----------
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_chargement || dgv.CurrentRow == null)
                return;
            Afficher((int)dgv.CurrentRow.Cells["Id"].Value);
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerListe();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            NouvelArticle();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string reference = txtReference.Text.Trim();
            string designation = txtDesignation.Text.Trim();

            if (reference.Length == 0)
            {
                MessageBox.Show("La référence est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReference.Focus();
                return;
            }
            if (designation.Length == 0)
            {
                MessageBox.Show("La désignation est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesignation.Focus();
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    if (db.Articles.Any(x => x.Reference == reference && x.Id != _id))
                    {
                        MessageBox.Show("Un article avec cette référence existe déjà.", "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtReference.Focus();
                        return;
                    }

                    Article a;
                    if (_id == 0)
                    {
                        a = new Article();          // CREATE
                        db.Articles.Add(a);
                    }
                    else
                    {
                        a = db.Articles.Find(_id);  // UPDATE
                        if (a == null)
                        {
                            MessageBox.Show("Cet article n'existe plus.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ChargerListe();
                            return;
                        }
                    }

                    a.Reference = reference;
                    a.Designation = designation;
                    a.Unite = cboUnite.Text.Trim();
                    a.Categorie = cboCategorie.Text.Trim();

                    db.SaveChanges();
                    ChargerCategories();
                    ChargerListe(a.Id);
                }
                MessageBox.Show("Article enregistré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement :\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- DELETE ----------
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_id == 0)
                return;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    Article a = db.Articles.Find(_id);
                    if (a == null)
                    {
                        ChargerListe();
                        return;
                    }

                    // Suppression bloquée si l'article est utilisé
                    bool utilise = db.Demandes.Any(d => d.ArticleId == _id)
                                || db.LignesCommande.Any(l => l.ArticleId == _id);

                    if (utilise)
                    {
                        MessageBox.Show("L'article « " + a.Designation + " » est utilisé dans des demandes d'achat ou des commandes : "
                                      + "il ne peut pas être supprimé.",
                            "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (MessageBox.Show("Supprimer définitivement l'article « " + a.Designation + " » ?",
                            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    db.Articles.Remove(a);
                    db.SaveChanges();
                }
                ChargerCategories();
                ChargerListe();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Suppression impossible :\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
