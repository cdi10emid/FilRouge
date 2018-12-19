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
            objControleur = new AccesWebService() ;
         

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                afficheCombo();
                AfficheDataGried();

            }

            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
                this.Close();
            }
        }

        /// <summary>
        /// Méthode affichage de la DataGridView
        /// </summary>
        private void AfficheDataGried()
        {
           
            List<Offre> listOffre = objControleur.WebAfficheOffre();

            dataGridView1.DataSource = listOffre;
           
            
            dataGridView1.Columns["IdOffre"].Visible =false;
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
    

     
        public int idOffreSelectransmit { get; set; }
        private void buttonSuprimOffre_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("Attention voulez-vous vraiment supprimer cette offre !", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
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
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
            }


        }
    

      

      

        private void comboBoxPoste_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                comboBoxPoste.ValueMember = "IDPOSTE";
                List<Offre> listOffre = objControleur.WebAfficheOffreByIdPoste(comboBoxPoste.SelectedValue.ToString());

                dataGridView1.DataSource = listOffre;

                dataGridView1.Columns["IdOffre"].Visible = false;
                dataGridView1.Columns["IdPoste"].Visible = false;
                dataGridView1.Columns["IdContact"].Visible = false;
                dataGridView1.Columns["IdContrat"].Visible = false;
                dataGridView1.Columns["IdRegion"].Visible = false;
                comboBoxContrat.Visible = true;
                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }


        }

        private void comboBoxContrat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {

                comboBoxPoste.ValueMember = "IDPOSTE";
                comboBoxContrat.ValueMember = "IDCONTRAT";
                List<Offre> listOffre = objControleur.WebAfficheOffreByIdPosteIdContrat(comboBoxPoste.SelectedValue.ToString(), comboBoxContrat.SelectedValue.ToString());

                dataGridView1.DataSource = listOffre;
                if (listOffre != null)
                {
                    dataGridView1.Columns["IdOffre"].Visible = false;
                    dataGridView1.Columns["IdPoste"].Visible = false;
                    dataGridView1.Columns["IdContact"].Visible = false;
                    dataGridView1.Columns["IdContrat"].Visible = false;
                    dataGridView1.Columns["IdRegion"].Visible = false;
                    comboBoxRegion.Visible = true;
                }


                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }
        }

        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
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
                    dataGridView1.Columns["IdOffre"].Visible = false;
                    dataGridView1.Columns["IdPoste"].Visible = false;
                    dataGridView1.Columns["IdContact"].Visible = false;
                    dataGridView1.Columns["IdContrat"].Visible = false;
                    dataGridView1.Columns["IdRegion"].Visible = false;

                }


                if (dataGridView1.CurrentRow != null)
                {
                    idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }
            }
        }
    }
}
