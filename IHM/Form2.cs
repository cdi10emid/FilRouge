using ClassAccesData;
using ClassMetier;
using Controleur;
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
    public partial class Form2 : Form
    {
        private AccesWebService objControleur;
        public Form2()
        {
            InitializeComponent();
            objControleur = new AccesWebService() ;
        }
        private void AfficheDataGried()
        {
           
            List<Offre> listOffre = objControleur.WebAfficheOffre();
            dataGridView1.DataSource = listOffre;
            idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
            
            dataGridView1.Columns["IdOffre"].Visible =false;
            dataGridView1.Columns["IdPoste"].Visible = false;
            dataGridView1.Columns["IdContact"].Visible = false;

        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            idOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            AfficheDataGried();

        }
        public int idOffreSelectransmit { get; set; }
        private void buttonSuprimOffre_Click(object sender, EventArgs e)
        {
           int idOffreSelec = Convert.ToInt32( dataGridView1.CurrentRow.Cells["IDOFFRE"].Value);
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

        private void buttonModifOffre_Click(object sender, EventArgs e)
        {
            Form3 frm2 = new Form3(idOffreSelectransmit);
            frm2.ShowDialog();
        }
    }
}
