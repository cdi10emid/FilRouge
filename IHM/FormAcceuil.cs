using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class FormAcceuil : Form
    {
        public FormAcceuil()
        {
            InitializeComponent();
        }

        private void FormAcceuil_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            try
            {
                labelPrenom.Text = UserPrincipal.Current.GivenName;
                labelNom.Text = UserPrincipal.Current.Surname;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection au serveur impossible !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Form1 f = new Form1();

            f.ShowDialog();
            UseWaitCursor = false;
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAcceuil_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}