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

            AccesContact accesContact = new AccesContact();
            List<Contact> listeContact = accesContact.ListeContact();
            comboBoxNomEntreprise.DataSource = listeContact;
            
            comboBoxNomEntreprise.DisplayMember = "NOMENTREPRISE";
            comboBoxNomEntreprise.ValueMember = "IDCONTACT";

            int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
            Contact contact = accesContact.GetContactByIdContact(value);
            textBoxNomContact.Text = contact.NomContact;
            textBoxTelContact.Text =Convert.ToString( contact.TelContact);
            textBoxMailContact.Text = contact.MailContact;

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void comboBoxNomEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesContact accesContact = new AccesContact();
            comboBoxNomEntreprise.ValueMember = "IDCONTACT";

            int value = Convert.ToInt32(comboBoxNomEntreprise.SelectedValue.ToString());
            Contact contact = accesContact.GetContactByIdContact(value);
            textBoxNomContact.Text = contact.NomContact;
            textBoxTelContact.Text = Convert.ToString(contact.TelContact);
            textBoxMailContact.Text = contact.MailContact;


        }
    }
}
