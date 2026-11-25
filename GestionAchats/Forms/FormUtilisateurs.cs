using System;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Gérer les utilisateurs » (Administrateur)
    public partial class FormUtilisateurs : Form
    {
        private int _id;            // 0 = nouvel utilisateur
        private bool _chargement;   // évite de réagir aux changements de sélection faits par le code

        public FormUtilisateurs()
        {
            InitializeComponent();
        }

        private void FormUtilisateurs_Load(object sender, EventArgs e)
        {
            cboRole.DataSource = Enum.GetValues(typeof(Role));
            ChargerListe();
        }

        // ---------- READ ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                IQueryable<Utilisateur> requete = db.Utilisateurs.AsNoTracking();
                if (filtre.Length > 0)
                    requete = requete.Where(u => u.Nom.Contains(filtre) || u.Login.Contains(filtre));

                var liste = requete
                    .OrderBy(u => u.Nom)
                    .Select(u => new { u.Id, u.Nom, u.Login, u.Role })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                dgv.Columns["Role"].HeaderText = "Rôle";
                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Nom");
                _chargement = false;
            }

            int id = Outils.IdCourant(dgv);
            if (id != 0)
                Afficher(id);
            else
                Nouveau();
        }

        private void Afficher(int id)
        {
            using (var db = new GestionAchatsContext())
            {
                Utilisateur u = db.Utilisateurs.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (u == null)
                {
                    Nouveau();
                    return;
                }

                _id = u.Id;
                txtNom.Text = u.Nom;
                txtLogin.Text = u.Login;
                txtMotDePasse.Clear();
                cboRole.SelectedItem = u.Role;
            }
            grpDetails.Text = "Modifier l'utilisateur";
            btnSupprimer.Enabled = true;
        }

        private void Nouveau()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            txtNom.Clear();
            txtLogin.Clear();
            txtMotDePasse.Clear();
            cboRole.SelectedIndex = 0;
            grpDetails.Text = "Nouvel utilisateur";
            btnSupprimer.Enabled = false;
            txtNom.Focus();
        }

        // ---------- Événements ----------
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            int id = Outils.IdCourant(dgv);
            if (id != 0)
                Afficher(id);
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerListe();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouveau();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string login = txtLogin.Text.Trim();
            string mdp = txtMotDePasse.Text;

            if (nom.Length == 0)
            {
                Outils.Alerte("Le nom est obligatoire.");
                txtNom.Focus();
                return;
            }
            if (login.Length == 0)
            {
                Outils.Alerte("Le login est obligatoire.");
                txtLogin.Focus();
                return;
            }
            if (_id == 0 && mdp.Length == 0)
            {
                Outils.Alerte("Le mot de passe est obligatoire pour un nouvel utilisateur.");
                txtMotDePasse.Focus();
                return;
            }
            if (mdp.Length > 0 && mdp.Length < 4)
            {
                Outils.Alerte("Le mot de passe doit contenir au moins 4 caractères.");
                txtMotDePasse.Focus();
                return;
            }

            Role role = (Role)cboRole.SelectedItem;

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    if (db.Utilisateurs.Any(x => x.Login == login && x.Id != _id))
                    {
                        Outils.Alerte("Ce login est déjà utilisé.");
                        txtLogin.Focus();
                        return;
                    }

                    Utilisateur u;
                    if (_id == 0)
                    {
                        u = new Utilisateur();               // CREATE
                        db.Utilisateurs.Add(u);
                    }
                    else
                    {
                        u = db.Utilisateurs.Find(_id);       // UPDATE
                        if (u == null)
                        {
                            Outils.Erreur("Cet utilisateur n'existe plus.");
                            ChargerListe();
                            return;
                        }

                        // On garde toujours au moins un administrateur
                        if (u.Role == Role.Administrateur && role != Role.Administrateur
                            && db.Utilisateurs.Count(x => x.Role == Role.Administrateur) <= 1)
                        {
                            Outils.Alerte("Il doit rester au moins un administrateur.");
                            return;
                        }
                    }

                    u.Nom = nom;
                    u.Login = login;
                    u.Role = role;
                    if (mdp.Length > 0)
                        u.MotDePasse = Utilisateur.HasherMotDePasse(mdp);   // jamais en clair

                    db.SaveChanges();
                    ChargerListe(u.Id);
                }
                Outils.Info("Utilisateur enregistré.");
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Erreur lors de l'enregistrement :\n" + Outils.Detail(ex));
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
                    Utilisateur u = db.Utilisateurs.Find(_id);
                    if (u == null)
                    {
                        ChargerListe();
                        return;
                    }

                    if (db.Demandes.Any(d => d.DemandeurId == _id) || db.Commandes.Any(c => c.AcheteurId == _id))
                    {
                        Outils.Alerte("L'utilisateur « " + u.Nom + " » a des demandes d'achat ou des commandes : "
                                      + "il ne peut pas être supprimé.");
                        return;
                    }

                    if (u.Role == Role.Administrateur && db.Utilisateurs.Count(x => x.Role == Role.Administrateur) <= 1)
                    {
                        Outils.Alerte("Impossible de supprimer le dernier administrateur.");
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer définitivement l'utilisateur « " + u.Nom + " » ?"))
                        return;

                    db.Utilisateurs.Remove(u);
                    db.SaveChanges();
                }
                ChargerListe();
            }
            catch (DbUpdateException ex)
            {
                Outils.Erreur("Suppression impossible :\n" + Outils.Detail(ex));
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
