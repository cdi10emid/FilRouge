using ClassAccesData;
using ClassMetier;
using Controleur;
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
    public partial class Form2 : Form
    {
        private AccesWebService objControleur;
        public Form2()
        {
            InitializeComponent();
            objControleur = new AccesWebService();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            afficheCombo();

            AfficheDataGried();
        }
        /// <summary>
        /// Méthode affichage de la DataGridView
        /// </summary>
        private void AfficheDataGried()
        {
            UseWaitCursor = true;
            try
            {
                // Récupération de la liste des offres à partir du WebService
                List<Offre> listOffre = objControleur.WebAfficheOffre();

                dataGridView1.DataSource = listOffre;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.DefaultCellStyle.BackColor = Color.Bisque;

                dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";

                dataGridView1.Columns["IdOffre"].Visible = false;
                dataGridView1.Columns["IdPoste"].Visible = false;
                dataGridView1.Columns["IdContact"].Visible = false;
                dataGridView1.Columns["IdContrat"].Visible = false;
                dataGridView1.Columns["IdRegion"].Visible = false;
                dataGridView1.Columns["Description"].Visible = false;
                dataGridView1.Columns["LienWeb"].Visible = false;

                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        public int idOffreSelectransmit { get; set; }
        private void buttonSuprimOffre_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Attention voulez-vous vraiment supprimer cette offre !", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                int idOffreSelec = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDOFFRE"].Value);
                AccesOffre accesOffre = new AccesOffre();
                if (accesOffre.SuprimOffre(idOffreSelec) == 1)
                {
                    MessageBox.Show("Offre supprimée !");
                    AfficheDataGried();
                }
                else
                {
                    MessageBox.Show("Suppression de l'offre impossible !");
                }
            }
        }

        private void buttonModifOffre_Click(object sender, EventArgs e)
        {
            Form3 frm2 = new Form3(idOffreSelectransmit);
            frm2.ShowDialog();
        }

        private void buttonmAJ_Click(object sender, EventArgs e)
        {
            AfficheDataGried();
            comboBoxContrat.Enabled = true;
            comboBoxContrat.Visible = false;
            comboBoxPoste.Enabled = true;
            comboBoxRegion.Enabled = true;
            comboBoxRegion.Visible = false;
        }
        /// <summary>
        /// Affichage des 3 combobox : poste, contrat, region
        /// </summary>
        private void afficheCombo()
        {
            UseWaitCursor = true;
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
            UseWaitCursor = false;
        }
        private void comboBoxContrat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    comboBoxPoste.ValueMember = "IDPOSTE";
                    comboBoxContrat.ValueMember = "IDCONTRAT";
                    List<Offre> listOffre = objControleur.WebAfficheOffreByIdPosteIdContrat(comboBoxPoste.SelectedValue.ToString(), comboBoxContrat.SelectedValue.ToString());

                    dataGridView1.DataSource = listOffre;
                    if (listOffre != null)
                    {
                        dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                        dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                        dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                        dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                        dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                        dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                        dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                        dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";

                        dataGridView1.Columns["IdOffre"].Visible = false;
                        dataGridView1.Columns["IdPoste"].Visible = false;
                        dataGridView1.Columns["IdContact"].Visible = false;
                        dataGridView1.Columns["IdContrat"].Visible = false;
                        dataGridView1.Columns["IdRegion"].Visible = false;
                        comboBoxRegion.Visible = true;
                        comboBoxContrat.Enabled = false;
                    }
                    if (dataGridView1.CurrentRow != null)
                    {
                        idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }

        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                if (dataGridView1.CurrentRow != null)
                {

                    comboBoxPoste.ValueMember = "IDPOSTE";
                    comboBoxContrat.ValueMember = "IDCONTRAT";
                    comboBoxRegion.ValueMember = "IDREGION";
                    List<Offre> listOffre = objControleur.WebAfficheOffreByIdPosteIdContratIdRegion(comboBoxPoste.SelectedValue.ToString(), comboBoxContrat.SelectedValue.ToString(), comboBoxRegion.SelectedValue.ToString());

                    dataGridView1.DataSource = listOffre;
                    if (listOffre != null)
                    {
                        dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                        dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                        dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                        dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                        dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                        dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                        dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                        dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";
                        dataGridView1.Columns["IdOffre"].Visible = false;
                        dataGridView1.Columns["IdPoste"].Visible = false;
                        dataGridView1.Columns["IdContact"].Visible = false;
                        dataGridView1.Columns["IdContrat"].Visible = false;
                        dataGridView1.Columns["IdRegion"].Visible = false;
                        comboBoxRegion.Enabled = false;
                    }
                    if (dataGridView1.CurrentRow != null)
                    {
                        idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
            }
        }

        private void comboBoxPoste_SelectedIndexChanged(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    
                    comboBoxPoste.ValueMember = "IDPOSTE";
                    List<Offre> listOffre = objControleur.WebAfficheOffreByIdPoste(comboBoxPoste.SelectedValue.ToString());

                    dataGridView1.DataSource = listOffre;
                    dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                    dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                    dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                    dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                    dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                    dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                    dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                    dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";
                    dataGridView1.Columns["IdOffre"].Visible = false;
                    dataGridView1.Columns["IdPoste"].Visible = false;
                    dataGridView1.Columns["IdContact"].Visible = false;
                    dataGridView1.Columns["IdContrat"].Visible = false;
                    dataGridView1.Columns["IdRegion"].Visible = false;
                    comboBoxContrat.Visible = true;
                    comboBoxPoste.Enabled = false;
                    
                    if (dataGridView1.CurrentRow != null)
                    {
                        idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }

        private void buttonDate_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                AccesOffre accesOffre = new AccesOffre();

                List<Offre> listOffre = objControleur.WebAfficheOffreByDate(dateTimePickerDateDebut.Value.ToString("yyMMdd"), dateTimePickerDateFin.Value.ToString("yyMMdd"));

                dataGridView1.DataSource = listOffre;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.DefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";

                dataGridView1.Columns["IdOffre"].Visible = false;
                dataGridView1.Columns["IdPoste"].Visible = false;
                dataGridView1.Columns["IdContact"].Visible = false;
                dataGridView1.Columns["IdContrat"].Visible = false;
                dataGridView1.Columns["IdRegion"].Visible = false;
                dataGridView1.Columns["Description"].Visible = false;
                dataGridView1.Columns["LienWeb"].Visible = false;

                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        public void chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            try
            {
                AccesOffre accesOffre = new AccesOffre();

                int nbMois = Convert.ToInt32(textBoxMois.Text);
                string DateFin = DateTime.Today.ToString("yyMMdd");
                string DateDebut = DateTime.Today.AddMonths(- nbMois).ToString("yyMMdd");
                List<Offre> listOffre = objControleur.WebAfficheOffreByDate(DateDebut, DateFin);

                dataGridView1.DataSource = listOffre;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.DefaultCellStyle.BackColor = Color.Bisque;
                dataGridView1.Columns["DateParution"].HeaderText = "Date de parution";
                dataGridView1.Columns["NomEntreprise"].HeaderText = "Nom de l'entreprise";
                dataGridView1.Columns["NomContact"].HeaderText = "Nom du contact";
                dataGridView1.Columns["TelContact"].HeaderText = "Téléphone du contact";
                dataGridView1.Columns["MailContact"].HeaderText = "Mail du contact";
                dataGridView1.Columns["TypeContrat"].HeaderText = "Type de contrat";
                dataGridView1.Columns["Nomregion"].HeaderText = "Région";
                dataGridView1.Columns["TypePoste"].HeaderText = "Type de poste";


                dataGridView1.Columns["IdOffre"].Visible = false;
                dataGridView1.Columns["IdPoste"].Visible = false;
                dataGridView1.Columns["IdContact"].Visible = false;
                dataGridView1.Columns["IdContrat"].Visible = false;
                dataGridView1.Columns["IdRegion"].Visible = false;
                dataGridView1.Columns["Description"].Visible = false;
                dataGridView1.Columns["LienWeb"].Visible = false;

                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }

        private void textBoxSemaine_KeyPress(object sender, KeyPressEventArgs e)
        {
            chiffre(e);
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
