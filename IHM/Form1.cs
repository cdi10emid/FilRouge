using ClassAccesData;
using ClassMetier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            afficheCombo();
            afficheContact();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccesPoste accesPoste = new AccesPoste();
            accesPoste.ajoutPoste(comboBoxPoste.Text);
            afficheCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccesContrat accesContrat = new AccesContrat();
            accesContrat.ajoutContrat(comboBoxContrat.Text);

            afficheCombo();
           
           
        }
      
        /// <summary>
        /// Affichage des 3 combobox : poste, contrat, region
        /// </summary>
        private void afficheCombo()
        {
            AccesPoste accesPoste = new AccesPoste();
            List<Poste> ListePoste = accesPoste.listePoste();
            comboBoxPoste.DataSource = ListePoste;
            comboBoxPoste.DisplayMember = "TYPEPOSTE";
            comboBoxPoste.ValueMember = "IDPOSTE";

            AccesContrat accesContrat = new AccesContrat();
            List<Contrat> listeContrat = accesContrat.ListeContrat();
            comboBoxContrat.DataSource = listeContrat;
            comboBoxContrat.DisplayMember = "TYPECONTRAT";
            comboBoxContrat.ValueMember = "IDCONTRAT";

            AccesRegion accesRegion = new AccesRegion();
            List<ClassMetier.Region> listeRegion = accesRegion.listeRegion();
            comboBoxRegion.DataSource = listeRegion;
            comboBoxRegion.DisplayMember = "NOMREGION";
            comboBoxRegion.ValueMember = "IDREGION";


        }

      /// <summary>
      /// Affichage des textBox suivant la sélection de la combobox Nom entreprise
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
       
        private void comboBoxNomEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNomEntreprise.ValueMember = "IDCONTACT";
            if (comboBoxNomEntreprise.SelectedValue != null)
            {
                AccesContact accesContact2 = new AccesContact();
                int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
                Contact contact = accesContact2.GetContactByIdContact(value);
                textBoxNomContact.Text = contact.NomContact;
                textBoxTelContact.Text = Convert.ToString(contact.TelContact);
                textBoxMailContact.Text = contact.MailContact;
            }


        }

        private void buttonAjoutContact_Click(object sender, EventArgs e)
        {
            AccesContact accesContact = new AccesContact();
           

            if (accesContact.InsertContact(comboBoxNomEntreprise.Text, textBoxNomContact.Text, Convert.ToInt32(textBoxTelContact.Text), textBoxMailContact.Text) == 1)
            {
                MessageBox.Show("Ajout du nouveau contact effectué !");
            }
            else
            {
                MessageBox.Show("Ajout impossible !");
            }
            afficheCombo();
            afficheContact();
        }
        /// <summary>
        /// Méthode pour afficher les contacts
        /// </summary>
        private void afficheContact()
        {
            AccesContact accesContact = new AccesContact();
            List<Contact> listeContact = accesContact.ListeContact();
            comboBoxNomEntreprise.DataSource = listeContact;

            comboBoxNomEntreprise.DisplayMember = "NOMENTREPRISE";

            comboBoxNomEntreprise.ValueMember = "IDCONTACT";
            if (comboBoxNomEntreprise.SelectedValue != null)
            {
                AccesContact accesContact2 = new AccesContact();
                int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
                Contact contact = accesContact2.GetContactByIdContact(value);
                textBoxNomContact.Text = contact.NomContact;
                textBoxTelContact.Text = Convert.ToString(contact.TelContact);
                textBoxMailContact.Text = contact.MailContact;
            }
          
        }

        private void buttonValidOffre_Click(object sender, EventArgs e)
        {
            AccesOffre accesOffre = new AccesOffre();
           if( accesOffre.InsertOffre(Convert.ToInt32(comboBoxPoste.SelectedValue.ToString()), 
                                   Convert.ToInt32(comboBoxContrat.SelectedValue.ToString()), 
                                   Convert.ToInt32(comboBoxRegion.SelectedValue.ToString()),
                                   Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString()),
                                   Convert.ToString(textBoxTitre.Text),
                                   dateTimePicker1.Value,
                                   Convert.ToString(richTextBox1.Text),
                                   Convert.ToString(textBoxLienWeb.Text))==1)
            {

                MessageBox.Show("Ajout de l'offre effectuée !");
            }
            else
            {
                MessageBox.Show("Ajout de l'offre impossible !");
            }
        }

        private void buttonListOffres_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
           
                     f.ShowDialog(); 
        }
    }
}
