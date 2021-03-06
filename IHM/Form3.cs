﻿using ClassAccesData;
using ClassMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form3 : Form
    {
        public static System.Windows.Forms.Cursor WaitCursor { get; }
        private int _idOffreSeelect;
        /// <summary>
        /// Constructeur de la form3 avec récupération de l'offre sélectionnée dans la DataGridView de la form 2
        /// </summary>
        /// <param name="IdOffreSelect"></param>
        public Form3(int IdOffreSelect)
        {
            _idOffreSeelect = IdOffreSelect;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
        }   
        /// <summary>
        /// Affichage des 3 combobox : poste, contrat, region
        /// </summary>
        private void AfficheCombo()
        {
            UseWaitCursor = true;
            try
            {
                AccesOffre accesOffre = new AccesOffre();
                Offre offreSelect = new Offre();

                offreSelect = accesOffre.GetOffreByidoffre(_idOffreSeelect);
                AccesPoste accesPoste = new AccesPoste();
                List<Poste> ListePoste = accesPoste.listePoste();
                comboBoxPoste.DataSource = ListePoste;
                comboBoxPoste.DisplayMember = "TYPEPOSTE";
                comboBoxPoste.ValueMember = "IDPOSTE";
                comboBoxPoste.SelectedValue = offreSelect.IdPoste;

                AccesContrat accesContrat = new AccesContrat();
                List<Contrat> listeContrat = accesContrat.ListeContrat();
                comboBoxContrat.DataSource = listeContrat;
                comboBoxContrat.DisplayMember = "TYPECONTRAT";
                comboBoxContrat.ValueMember = "IDCONTRAT";
                comboBoxContrat.SelectedValue = offreSelect.IdContrat;

                AccesRegion accesRegion = new AccesRegion();
                List<ClassMetier.Region> listeRegion = accesRegion.listeRegion();
                comboBoxRegion.DataSource = listeRegion;
                comboBoxRegion.DisplayMember = "NOMREGION";
                comboBoxRegion.ValueMember = "IDREGION";
                comboBoxRegion.SelectedValue = offreSelect.IdRegion;
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        int idcontactSelect;
        /// <summary>
        /// Affichage de l'offre sélectionnée
        /// </summary>
        public void AfficheOffreSelect()
        {
            UseWaitCursor = true;
            try
            {
                AccesOffre accesOffre = new AccesOffre();
                Offre offreSelect = new Offre();
                offreSelect = accesOffre.GetOffreByidoffre(_idOffreSeelect);
                idcontactSelect = offreSelect.IdContact;
                textBoxLienWeb.Text = offreSelect.LienWeb;
                if(textBoxLienWeb.Text== "")
                {
                    pictureBox2.Visible = false;
                }
                textBoxTitre.Text = offreSelect.Titre;
                richTextBox1.Text = offreSelect.Description;
                dateTimePicker1.Value = Convert.ToDateTime(offreSelect.DateParution);
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        /// <summary>
        /// Méthode pour afficher le contact
        /// </summary>
        private void AfficheContact()
        {
            UseWaitCursor = true;
            try
            {
                AccesContact accesContact = new AccesContact();
                Contact contact = accesContact.GetContactByIdContact(idcontactSelect);
                textBoxNomEntreprise.Text = contact.NomEntreprise;
                textBoxNomContact.Text = contact.NomContact;
                textBoxTelContact.Text = contact.TelContact;
                textBoxMailContact.Text = contact.MailContact;
                if (textBoxMailContact.Text == "")
                {
                    pictureBox3.Visible = false;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;

        }
        /// <summary>
        /// méthode de vérification si l'utilisateur saisi bien des chiffres
        /// </summary>
        /// <param name="e"></param>
        public void Chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void TextBoxTelContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chiffre(e);
        }

        private void ButtonValidOffre_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                AccesOffre accesOffre = new AccesOffre();
                int retour = accesOffre.UpdatetOffre(_idOffreSeelect, Convert.ToInt32(comboBoxPoste.SelectedValue.ToString()),
                                         Convert.ToInt32(comboBoxContrat.SelectedValue.ToString()), Convert.ToInt32(comboBoxRegion.SelectedValue.ToString()),
                                         idcontactSelect, textBoxTitre.Text, dateTimePicker1.Value, richTextBox1.Text, textBoxLienWeb.Text,
                                         textBoxNomContact.Text, textBoxTelContact.Text, textBoxMailContact.Text);
                if (retour > 1)
                {
                    MessageBox.Show("Mise à jour de l'offre effectuée !");
                }
                else
                {
                    MessageBox.Show("Mise à jour l'offre impossible !");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        private void ButtonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBoxLienWeb.Text);
        }
        private void Form3_Shown(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            AfficheOffreSelect();
            AfficheContact();
            AfficheCombo();
            this.Cursor = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"mailto:{textBoxMailContact.Text}");
        }
    }
}
