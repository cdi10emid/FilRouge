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
        /// <summary>
        /// Affichage de l'offre sélectionnée
        /// </summary>
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
            textBoxNomEntreprise.Text = contact.NomEntreprise;
            textBoxNomContact.Text = contact.NomContact;
            textBoxTelContact.Text = contact.TelContact;
            textBoxMailContact.Text = contact.MailContact;


        }

        private void buttonValidOffre_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show(" Voulez-vous vraiment modifier cette offre !", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                AccesOffre accesOffre = new AccesOffre();
                if (accesOffre.UpdatetOffre(_idOffreSeelect,
                                         Convert.ToInt32(comboBoxPoste.SelectedValue.ToString()),
                                         Convert.ToInt32(comboBoxContrat.SelectedValue.ToString()),
                                        Convert.ToInt32(comboBoxRegion.SelectedValue.ToString()),
                                        idcontactSelect,
                                        Convert.ToString(textBoxTitre.Text),
                                        dateTimePicker1.Value,
                                        Convert.ToString(richTextBox1.Text),
                                        Convert.ToString(textBoxLienWeb.Text),
                                        textBoxNomContact.Text,
                                        textBoxTelContact.Text,
                                        textBoxMailContact.Text) == 2)
                {
                    MessageBox.Show("Offre mise à jour !");
                    

                }
                else
                {
                    MessageBox.Show("Mise à jour de l'offre impossible !");
                }
            }
            else
            {
                AfficheOffreSelect();
                afficheContact();
                afficheCombo();
            }
          

        }
        /// <summary>
        /// méthode de vérification si l'utilisateur saisi bien des chiffres
        /// </summary>
        /// <param name="e"></param>
        public void chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxTelContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffre(e);
        }

       
    }
}
