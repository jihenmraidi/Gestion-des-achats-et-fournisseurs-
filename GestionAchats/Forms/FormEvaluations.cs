using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestionAchats.Data;
using GestionAchats.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAchats.Forms
{
    // Cas d'utilisation : « Évaluer un fournisseur » (Responsable achats)
    public partial class FormEvaluations : Form
    {
        private int _id;            // 0 = nouvelle évaluation
        private bool _chargement;

        public FormEvaluations()
        {
            InitializeComponent();
        }

        private void FormEvaluations_Load(object sender, EventArgs e)
        {
            _chargement = true;
            using (var db = new GestionAchatsContext())
            {
                var fournisseurs = db.Fournisseurs.AsNoTracking().OrderBy(f => f.Nom)
                    .Select(f => new { f.Id, f.Nom }).ToList();
                Outils.Remplir(cboFournisseur, fournisseurs.Select(f => new Choix(f.Id, f.Nom)).ToList());
            }
            _chargement = false;
            ChargerListe();
        }

        // ---------- READ ----------
        private void ChargerListe(int idSelection = 0)
        {
            string filtre = txtRecherche.Text.Trim();

            using (var db = new GestionAchatsContext())
            {
                List<Evaluation> evaluations = db.Evaluations.AsNoTracking().Include(ev => ev.Fournisseur).ToList();

                // NoteGlobale est une propriété calculée : on la calcule en mémoire
                var liste = evaluations
                    .Where(ev => Outils.Contient(ev.Fournisseur.Nom, filtre))
                    .OrderByDescending(ev => ev.DateEvaluation).ThenByDescending(ev => ev.Id)
                    .Select(ev => new
                    {
                        ev.Id,
                        Fournisseur = ev.Fournisseur.Nom,
                        ev.DateEvaluation,
                        ev.NoteQualite,
                        ev.NoteDelai,
                        ev.NotePrix,
                        NoteGlobale = Math.Round(ev.NoteGlobale, 2),
                        ev.Commentaire
                    })
                    .ToList();

                _chargement = true;
                dgv.DataSource = liste;
                dgv.Columns["Id"].Visible = false;
                Outils.FormatDate(dgv, "DateEvaluation", "Date");
                dgv.Columns["NoteQualite"].HeaderText = "Qualité";
                dgv.Columns["NoteDelai"].HeaderText = "Délai";
                dgv.Columns["NotePrix"].HeaderText = "Prix";
                dgv.Columns["NoteGlobale"].HeaderText = "Note globale";
                if (idSelection != 0)
                    Outils.SelectionnerLigne(dgv, idSelection, "Fournisseur");
                _chargement = false;
            }

            int id = Outils.IdCourant(dgv);
            if (id != 0)
                Afficher(id);
            else
                Nouvelle();
        }

        private void Afficher(int id)
        {
            using (var db = new GestionAchatsContext())
            {
                Evaluation ev = db.Evaluations.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (ev == null)
                {
                    Nouvelle();
                    return;
                }

                _id = ev.Id;
                Outils.Choisir(cboFournisseur, ev.FournisseurId);
                Outils.FixerDate(dtpDate, ev.DateEvaluation);
                Outils.Fixer(nudQualite, ev.NoteQualite);
                Outils.Fixer(nudDelai, ev.NoteDelai);
                Outils.Fixer(nudPrix, ev.NotePrix);
                txtCommentaire.Text = ev.Commentaire;
            }
            grpDetails.Text = "Modifier l'évaluation";
            btnSupprimer.Enabled = true;
            MajNoteGlobale();
            MajMoyenne();
        }

        private void Nouvelle()
        {
            _chargement = true;
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            _chargement = false;

            _id = 0;
            cboFournisseur.SelectedIndex = cboFournisseur.Items.Count > 0 ? 0 : -1;
            dtpDate.Value = DateTime.Today;
            Outils.Fixer(nudQualite, 3);
            Outils.Fixer(nudDelai, 3);
            Outils.Fixer(nudPrix, 3);
            txtCommentaire.Clear();
            grpDetails.Text = "Nouvelle évaluation";
            btnSupprimer.Enabled = false;
            MajNoteGlobale();
            MajMoyenne();
        }

        // Même formule que Evaluation.NoteGlobale
        private void MajNoteGlobale()
        {
            decimal note = (nudQualite.Value + nudDelai.Value + nudPrix.Value) / 3m;
            lblNoteGlobale.Text = "Note globale : " + note.ToString("0.00");
        }

        // Note moyenne du fournisseur choisi (même calcul que Fournisseur.CalculerNote)
        private void MajMoyenne()
        {
            int idFournisseur = Outils.Valeur(cboFournisseur);
            if (idFournisseur == 0)
            {
                lblMoyenne.Text = "Note moyenne : -";
                return;
            }

            using (var db = new GestionAchatsContext())
            {
                List<Evaluation> evaluations = db.Evaluations.AsNoTracking()
                    .Where(ev => ev.FournisseurId == idFournisseur).ToList();

                if (evaluations.Count == 0)
                    lblMoyenne.Text = "Note moyenne : aucune évaluation";
                else
                    lblMoyenne.Text = "Note moyenne : " + evaluations.Average(ev => ev.NoteGlobale).ToString("0.00")
                                      + " / 5 (" + evaluations.Count + " évaluation(s))";
            }
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

        private void cboFournisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chargement)
                return;
            MajMoyenne();
        }

        private void nudNote_ValueChanged(object sender, EventArgs e)
        {
            MajNoteGlobale();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            Nouvelle();
        }

        // ---------- CREATE / UPDATE ----------
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            int idFournisseur = Outils.Valeur(cboFournisseur);
            if (idFournisseur == 0)
            {
                Outils.Alerte("Choisissez le fournisseur à évaluer.");
                return;
            }

            try
            {
                using (var db = new GestionAchatsContext())
                {
                    Evaluation ev;
                    if (_id == 0)
                    {
                        ev = new Evaluation();                   // CREATE
                        db.Evaluations.Add(ev);
                    }
                    else
                    {
                        ev = db.Evaluations.Find(_id);           // UPDATE
                        if (ev == null)
                        {
                            Outils.Erreur("Cette évaluation n'existe plus.");
                            ChargerListe();
                            return;
                        }
                    }

                    ev.FournisseurId = idFournisseur;
                    ev.DateEvaluation = dtpDate.Value.Date;
                    ev.NoteQualite = (int)nudQualite.Value;
                    ev.NoteDelai = (int)nudDelai.Value;
                    ev.NotePrix = (int)nudPrix.Value;
                    ev.Commentaire = txtCommentaire.Text.Trim();

                    db.SaveChanges();
                    ChargerListe(ev.Id);
                }
                Outils.Info("Évaluation enregistrée.");
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
                    Evaluation ev = db.Evaluations.Find(_id);
                    if (ev == null)
                    {
                        ChargerListe();
                        return;
                    }

                    if (!Outils.Confirmer("Supprimer définitivement cette évaluation ?"))
                        return;

                    db.Evaluations.Remove(ev);
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
