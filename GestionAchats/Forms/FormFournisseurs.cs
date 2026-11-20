using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    public partial class FormFournisseurs : Form
    {
        private int _id;            // 0 = nouveau fournisseur, sinon Id du fournisseur affiché
        private bool _chargement;   // évite de réagir aux changements de sélection faits par le code

        public FormFournisseurs()
        {
            InitializeComponent();
        }

        private void FormFournisseurs_Load(object sender, EventArgs e)
        {
            cboConditions.Items.AddRange(new object[] { "Comptant", "À la commande", "30 jours", "60 jours", "90 jours" });
            ChargerListe();
        }

        // ---------- READ : liste ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                IQueryable<Fournisseur> requete = db.Fournisseurs.AsNoTracking();
                if (filtre.Length > 0)
                    requete = requete.Where(f => f.Nom.Contains(filtre) || f.Contact.Contains(filtre));

                var liste = requete
                    .OrderBy(f => f.Nom)
                    .Select(f => new { f.Id, f.Nom, f.Contact, f.Telephone, f.Email, f.ConditionsPaiement, f.Actif })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Telephone"].HeaderText = "Téléphone";
                dgv.Columns["ConditionsPaiement"].HeaderText = "Conditions de paiement";
                if (idSelection != 0)
                    SelectionnerLigne(idSelection);
                _chargement = false;
            }

            if (dgv.CurrentRow != null)
                Afficher((int)dgv.CurrentRow.Cells["Id"].Value);
            else
                NouveauFournisseur();
        }

        private void SelectionnerLigne(int id)
        {
            foreach (DataGridViewRow ligne in dgv.Rows)
            {
                if ((int)ligne.Cells["Id"].Value == id)
                {
                    dgv.CurrentCell = ligne.Cells["Nom"];
                    return;
                }
            }
        }

        private void Afficher(int id)
        {
            using (var db = new GestionAchatsContext())
            {
                Fournisseur f = db.Fournisseurs.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (f == null)
                {
                    NouveauFournisseur();
                    return;
                }

                _id = f.Id;
                txtNom.Text = f.Nom;
                txtContact.Text = f.Contact;
                txtTelephone.Text = f.Telephone;
                txtEmail.Text = f.Email;
                cboConditions.Text = f.ConditionsPaiement;
                chkActif.Checked = f.Actif;
            }
            grpDetails.Text = "Modifier le fournisseur";
            btnSupprimer.Enabled = true;
        }

        private void NouveauFournisseur()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            txtNom.Clear();
            txtContact.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            cboConditions.Text = "";
            chkActif.Checked = true;
            grpDetails.Text = "Nouveau fournisseur";
            btnSupprimer.Enabled = false;
            txtNom.Focus();
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
            NouveauFournisseur();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tel = txtTelephone.Text.Trim();

            if (nom.Length == 0)
            {
                MessageBox.Show("Le nom du fournisseur est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return;
            }
            if (email.Length > 0 && !EmailValide(email))
            {
                MessageBox.Show("L'adresse e-mail n'est pas valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (tel.Length > 0 && !Regex.IsMatch(tel, @"^[0-9+\-\s().]{6,30}$"))
            {
                MessageBox.Show("Le numéro de téléphone n'est pas valide.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    if (db.Fournisseurs.Any(x => x.Nom == nom && x.Id != _id))
                    {
                        MessageBox.Show("Un fournisseur portant ce nom existe déjà.", "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNom.Focus();
                        return;
                    }

                    Fournisseur f;
                    if (_id == 0)
                    {
                        f = new Fournisseur();          // CREATE
                        db.Fournisseurs.Add(f);
                    }
                    else
                    {
                        f = db.Fournisseurs.Find(_id);  // UPDATE
                        if (f == null)
                        {
                            MessageBox.Show("Ce fournisseur n'existe plus.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ChargerListe();
                            return;
                        }
                    }

                    f.Nom = nom;
                    f.Contact = txtContact.Text.Trim();
                    f.Telephone = tel;
                    f.Email = email;
                    f.ConditionsPaiement = cboConditions.Text.Trim();
                    f.Actif = chkActif.Checked;

                    db.SaveChanges();
                    ChargerListe(f.Id);
                }
                MessageBox.Show("Fournisseur enregistré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Fournisseur f = db.Fournisseurs.Find(_id);
                    if (f == null)
                    {
                        ChargerListe();
                        return;
                    }

                    // Suppression bloquée si le fournisseur est utilisé
                    bool utilise = db.Offres.Any(o => o.FournisseurId == _id)
                                || db.Commandes.Any(c => c.FournisseurId == _id);

                    if (utilise)
                    {
                        string message = "Le fournisseur « " + f.Nom + " » a des offres ou des commandes : "
                                       + "il ne peut pas être supprimé.";
                        if (f.Actif)
                        {
                            message += "\n\nVoulez-vous le désactiver à la place ?";
                            if (MessageBox.Show(message, "Suppression impossible", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                f.Actif = false;
                                db.SaveChanges();
                                ChargerListe(f.Id);
                            }
                        }
                        else
                        {
                            MessageBox.Show(message + "\n\nIl est déjà désactivé.", "Suppression impossible",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
                    }

                    if (MessageBox.Show("Supprimer définitivement le fournisseur « " + f.Nom + " » ?",
                            "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    db.Fournisseurs.Remove(f);
                    db.SaveChanges();
                }
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

        private static bool EmailValide(string email)
        {
            try
            {
                MailAddress adresse = new MailAddress(email);
                return adresse.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
