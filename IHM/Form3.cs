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
    public partial class Form3 : Form
    {
        private int _idOffreSeelect;
        public Form3(int IdOffreSelect)
        {
            _idOffreSeelect = IdOffreSelect;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AfficheOffreSelect();
            afficheContact();
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
        int idcontactSelect;
        public void AfficheOffreSelect()
        {
            AccesOffre accesOffre = new AccesOffre();
            Offre offreSelect = new Offre();

            offreSelect = accesOffre.GetOffreByidoffre(_idOffreSeelect);
            idcontactSelect = offreSelect.IdContact;
            textBoxLienWeb.Text = offreSelect.LienWeb;
            textBoxTitre.Text = offreSelect.Titre;
            richTextBox1.Text = offreSelect.Description;
            dateTimePicker1.Value = offreSelect.DateParution;

        }
        private void afficheContact()
        {
            AccesContact accesContact = new AccesContact();
            Contact contact = accesContact.GetContactByIdContact(idcontactSelect);
            comboBoxNomEntreprise.Text = contact.NomEntreprise;
            textBoxNomContact.Text = contact.NomContact;
            textBoxTelContact.Text = Convert.ToString(contact.TelContact);
            textBoxMailContact.Text = contact.MailContact;


        }
    }
}
