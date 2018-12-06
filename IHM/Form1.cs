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
            AccesPoste accesPoste = new AccesPoste();
            List<Poste> ListePoste = accesPoste.listePoste();
            comboBoxPoste.DataSource = ListePoste;
            comboBoxPoste.DisplayMember = "TYPEPOSTE";
            comboBoxPoste.ValueMember ="IDPOSTE";

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
    }
}
