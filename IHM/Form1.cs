﻿using ClassAccesData;
using ClassMetier;
using MetroFramework.Forms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        int repere = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            afficheCombo();
            afficheContact();
            repere = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AccesPoste accesPoste = new AccesPoste();
                accesPoste.ajoutPoste(comboBoxPoste.Text);
                afficheCombo();
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                AccesContrat accesContrat = new AccesContrat();
                accesContrat.ajoutContrat(comboBoxContrat.Text);

                afficheCombo();
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");

            }
        }

        /// <summary>
        /// Affichage des 3 combobox : poste, contrat, region
        /// </summary>
        private void afficheCombo()
        {
            try
            {
                AccesPoste accesPoste = new AccesPoste();
                List<Poste> ListePoste = accesPoste.listePoste();
                comboBoxPoste.DataSource = ListePoste;

                comboBoxPoste.DisplayMember = "TYPEPOSTE";
                comboBoxPoste.ValueMember = "IDPOSTE";
                comboBoxPoste.SelectedIndex = -1;



                AccesContrat accesContrat = new AccesContrat();
                List<Contrat> listeContrat = accesContrat.ListeContrat();
                comboBoxContrat.DataSource = listeContrat;
                comboBoxContrat.DisplayMember = "TYPECONTRAT";
                comboBoxContrat.ValueMember = "IDCONTRAT";
                comboBoxContrat.SelectedIndex = -1;


                AccesRegion accesRegion = new AccesRegion();
                List<ClassMetier.Region> listeRegion = accesRegion.listeRegion();
                comboBoxRegion.DataSource = listeRegion;
                comboBoxRegion.DisplayMember = "NOMREGION";
                comboBoxRegion.ValueMember = "IDREGION";
                comboBoxRegion.SelectedIndex = -1;
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");

            }



        }

        /// <summary>
        /// Affichage des textBox suivant la sélection de la combobox Nom entreprise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBoxNomEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {



                comboBoxNomEntreprise.ValueMember = "IDCONTACT";
                if (comboBoxNomEntreprise.SelectedValue != null && repere != 0)
                {
                    AccesContact accesContact2 = new AccesContact();
                    int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
                    Contact contact = accesContact2.GetContactByIdContact(value);
                    textBoxNomContact.Text = contact.NomContact;
                    textBoxTelContact.Text = Convert.ToString(contact.TelContact);
                    textBoxMailContact.Text = contact.MailContact;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");

            }

        }


        /// <summary>
        /// Méthode pour afficher les contacts
        /// </summary>
        private void afficheContact()
        {
            try
            {
                AccesContact accesContact = new AccesContact();
                List<Contact> listeContact = accesContact.ListeContact();
                comboBoxNomEntreprise.DataSource = listeContact;

                comboBoxNomEntreprise.DisplayMember = "NOMENTREPRISE";

                comboBoxNomEntreprise.ValueMember = "IDCONTACT";
                comboBoxNomEntreprise.SelectedIndex = -1;
                if (comboBoxNomEntreprise.SelectedValue != null && comboBoxNomEntreprise.SelectedIndex != -1)
                {
                    AccesContact accesContact2 = new AccesContact();
                    int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
                    Contact contact = accesContact2.GetContactByIdContact(value);
                    textBoxNomContact.Text = contact.NomContact;
                    textBoxTelContact.Text = Convert.ToString(contact.TelContact);
                    textBoxMailContact.Text = contact.MailContact;
                }
            }

            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
                this.Close();
            }
        }

        private void buttonValidOffre_Click(object sender, EventArgs e)
        {
            AccesOffre accesOffre = new AccesOffre();
            AccesContact accesContact = new AccesContact();
            try
            {
                if (comboBoxNomEntreprise.Text != "") //vérification si une entreprise a été saisie
                {
                    Contact contact = accesContact.GetContactByNomEnt(comboBoxNomEntreprise.Text);
                    if(contact.IdContact == 0)
                    {
                        accesContact.InsertContact(comboBoxNomEntreprise.Text, textBoxNomContact.Text, textBoxTelContact.Text, textBoxMailContact.Text);
                    }

                    if(comboBoxNomEntreprise.Text != "")
                    {

                        textBoxNomContact.Text = contact.NomContact;
                        textBoxTelContact.Text = Convert.ToString(contact.TelContact);
                        textBoxMailContact.Text = contact.MailContact;
                        int Idcontact = contact.IdContact;
                        if (accesOffre.InsertOffre(Convert.ToInt32(comboBoxPoste.SelectedValue.ToString()),
                                    Convert.ToInt32(comboBoxContrat.SelectedValue.ToString()),
                                    Convert.ToInt32(comboBoxRegion.SelectedValue.ToString()),
                                    Idcontact,
                                    Convert.ToString(textBoxTitre.Text),
                                    dateTimePicker1.Value,
                                    Convert.ToString(richTextBox1.Text),
                                    Convert.ToString(textBoxLienWeb.Text)) == 1)
                        {

                            MessageBox.Show("Ajout de l'offre effectuée !");
                            try
                            {

                                afficheCombo();

                                afficheContact();
                                EffaceBox();
                                repere = 1;

                            }
                            catch (SqlException)
                            {
                                MessageBox.Show("Problème de connection essayez plus tard");
                                this.Close();
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Ajout de l'offre impossible !");
                    }
                }
                //else
                //{
                //    if (accesOffre.InsertOffre(Convert.ToInt32(comboBoxPoste.SelectedValue.ToString()),
                //                 Convert.ToInt32(comboBoxContrat.SelectedValue.ToString()),
                //                 Convert.ToInt32(comboBoxRegion.SelectedValue.ToString()),
                //                 Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString()),
                //                 Convert.ToString(textBoxTitre.Text),
                //                 dateTimePicker1.Value,
                //                 Convert.ToString(richTextBox1.Text),
                //                 Convert.ToString(textBoxLienWeb.Text)) == 1)
                //    {

                //        MessageBox.Show("Ajout de l'offre effectuée !");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Ajout de l'offre impossible !");
                //    }
                //}

            }

            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");

            }
        }
        private void EffaceBox()
        {
            richTextBox1.Clear();
            textBoxTitre.Clear();
            textBoxTelContact.Clear();
            textBoxNomContact.Clear();
            textBoxMailContact.Clear();
            textBoxLienWeb.Clear();
        }

        private void buttonListOffres_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();

            f.ShowDialog();
        }
        /// <summary>
        /// Methode  pour que ne soit pris en compte que les chiffres et la touche back space
        /// </summary>
        /// <param name="e"></param>
        public void chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        /// <summary>
        /// surveillance de textBoxTelContact avec utilisation de la méthode chiffre()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void textBoxTelContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffre(e);
        }
        /// <summary>
        /// Fermeture de la form avce demande à l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((MessageBox.Show("Voulez-vous vraiment quitter la gestion des offres ?", "Attention ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
