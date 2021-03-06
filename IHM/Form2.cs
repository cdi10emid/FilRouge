﻿
using ClassAccesData;
using ClassMetier;
using Controleur;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form2 : Form
    {
        private HubConnection _connection;
        TaskScheduler scheduler;
        private readonly string txtadress = "user05.2isa.org";
        int iniContrat = 0;
        int initPoste = 0;
        int initregion = 0;
        public Form2()
        {
            InitializeComponent();
            scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            comboBoxPoste.Enabled = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }
        private async void ConnectHub()
        {
            string DateDebuturl = dateTimePickerDateDebut.Value.ToString("yyMMdd");
            string DateFinurl = dateTimePickerDateFin.Value.ToString("yyMMdd");
            string idposte = Convert.ToString(comboBoxPoste.SelectedValue);
            string idcontrat = Convert.ToString(comboBoxContrat.SelectedValue);
            string idregion = Convert.ToString(comboBoxRegion.SelectedValue);
            try
            {
                HubConnectionBuilder builder = new HubConnectionBuilder();
                string url = $"http://{txtadress}/chat?IdPoste={idposte}&IdContrat={idcontrat}&IdRegion={idregion}&DateDebut={DateDebuturl}&DateFin={DateFinurl}";
                builder.WithUrl(url);
                _connection = builder.Build();
                _connection.On<IList<Offre>>("SendOffreByDate", AfficheDataGried);
                _connection.On<IList<Offre>>("SendOffreById", AfficheDataGried);
                _connection.On<IList<Offre>>("SendOffreAll", AfficheDataGried);
                await _connection.StartAsync();
                comboBoxPoste.DisplayMember = "TYPEPOSTE";
                comboBoxContrat.DisplayMember = "TYPECONTRAT";
                comboBoxRegion.DisplayMember = "NOMREGION";
                comboBoxRegion.SelectedIndex = -1;
                comboBoxContrat.SelectedIndex = -1;
                comboBoxPoste.SelectedIndex = -1;
                comboBoxPoste.Enabled = true;
                comboBoxContrat.Visible = false;
                comboBoxRegion.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Méthode affichage de la DataGridView
        /// </summary>
        private void AfficheDataGried(IList<Offre> listeOffre)
        {
            Task.Factory.StartNew(() =>
            {
                dataGridView1.DataSource = listeOffre;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSalmon;
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
                    IdOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
                }

            }, CancellationToken.None, TaskCreationOptions.None, scheduler);

        }
        public int IdOffreSelectransmit { get; set; }
        private void ButtonSuprimOffre_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Attention voulez-vous vraiment supprimer cette offre !", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes))
            {
                int idOffreSelec = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDOFFRE"].Value);
                AccesOffre accesOffre = new AccesOffre();
                if (accesOffre.SuprimOffre(idOffreSelec) == 1)
                {
                    MessageBox.Show("Offre supprimée !");
                }
                else
                {
                    MessageBox.Show("Suppression de l'offre impossible !");
                }
            }
        }

        private void ButtonModifOffre_Click(object sender, EventArgs e)
        {
            Form3 frm2 = new Form3(IdOffreSelectransmit);
            frm2.ShowDialog();
        }

        private void ButtonmAJ_Click(object sender, EventArgs e)
        {
            AfficheCombo();
            ConnectHub();
            comboBoxContrat.Visible = false;
            comboBoxPoste.Enabled = true;
            comboBoxRegion.Visible = false;
        }
        /// <summary>
        /// Affichage des 3 combobox : poste, contrat, region
        /// </summary>
        private void AfficheCombo()
        {
            UseWaitCursor = true;
            try
            {
                AccesPoste accesPoste = new AccesPoste();
                List<Poste> ListePoste = accesPoste.listePoste();
                comboBoxPoste.DataSource = ListePoste;
                comboBoxPoste.ValueMember = "IDPOSTE";

                AccesContrat accesContrat = new AccesContrat();
                List<Contrat> listeContrat = accesContrat.ListeContrat();
                comboBoxContrat.DataSource = listeContrat;
                comboBoxContrat.ValueMember = "IDCONTRAT";

                AccesRegion accesRegion = new AccesRegion();
                List<ClassMetier.Region> listeRegion = accesRegion.listeRegion();
                comboBoxRegion.DataSource = listeRegion;
                comboBoxRegion.ValueMember = "IDREGION";
            }
            catch (SqlException)
            {
                MessageBox.Show("Problème de connection essayez plus tard");
            }
            UseWaitCursor = false;
        }
        private async void ComboBoxContrat_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxPoste.Enabled = false;
            comboBoxContrat.Enabled = false;
            comboBoxRegion.Visible = true;
            comboBoxPoste.ValueMember = "IDPOSTE";
            comboBoxContrat.ValueMember = "IDCONTRAT";
            comboBoxRegion.ValueMember = "IDREGION";

            string IdContrat = Convert.ToString(comboBoxContrat.SelectedValue);
            string IdRegion = Convert.ToString(comboBoxRegion.SelectedValue);

            string IdPoste = Convert.ToString(comboBoxPoste.SelectedValue);
            if (iniContrat > 0)
            {
                try
                {
                    await _connection.InvokeAsync("SendOffreById", IdPoste, IdContrat, IdRegion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            iniContrat++;
        }

        private async void ComboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPoste.ValueMember = "IDPOSTE";
            comboBoxContrat.ValueMember = "IDCONTRAT";
            comboBoxRegion.ValueMember = "IDREGION";
            string IdContrat = Convert.ToString(comboBoxContrat.SelectedValue);
            string IdRegion = Convert.ToString(comboBoxRegion.SelectedValue);
            string IdPoste = Convert.ToString(comboBoxPoste.SelectedValue);

            if (initregion > 0)
            {
                try
                {
                    await _connection.InvokeAsync("SendOffreById", IdPoste, IdContrat, IdRegion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            initregion++;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                IdOffreSelectransmit = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdOffre"].Value);
            }
        }

        private async void ComboBoxPoste_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPoste.Enabled = false;
            comboBoxContrat.Visible = true;
            comboBoxContrat.Enabled = true;
            comboBoxPoste.ValueMember = "IDPOSTE";
            comboBoxContrat.ValueMember = "IDCONTRAT";
            comboBoxRegion.ValueMember = "IDREGION";

            string IdContrat = Convert.ToString(comboBoxContrat.SelectedValue);
            string IdRegion = Convert.ToString(comboBoxRegion.SelectedValue);
            string IdPoste = Convert.ToString(comboBoxPoste.SelectedValue);

            if (initPoste > 0)
            {
                try
                {
                    await _connection.InvokeAsync("SendOffreById", IdPoste, IdContrat, IdRegion);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            initPoste++;
        }

        private async void ButtonDate_Click(object sender, EventArgs e)
        {
            string DateDebut = dateTimePickerDateDebut.Value.ToString("yyMMdd");
            string DateFin = dateTimePickerDateFin.Value.ToString("yyMMdd");
            UseWaitCursor = true;
            try
            {
                await _connection.InvokeAsync("SendOffreByDate", DateDebut, DateFin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UseWaitCursor = false;
        }
        public void Chiffre(System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            int nbMois = Convert.ToInt32(textBoxMois.Text);
            string DateFin = DateTime.Today.ToString("yyMMdd");
            string DateDebut = DateTime.Today.AddMonths(-nbMois).ToString("yyMMdd");
            UseWaitCursor = true;
            try
            {
                await _connection.InvokeAsync("SendOffreByDate", DateDebut, DateFin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UseWaitCursor = false;
        }

        private void TextBoxSemaine_KeyPress(object sender, KeyPressEventArgs e)
        {
            Chiffre(e);
        }

        private void ButtonQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            AfficheCombo();
            ConnectHub();
            comboBoxContrat.Visible = false;
            comboBoxPoste.Visible = true;
            comboBoxRegion.Visible = false;
            this.Cursor = Cursors.Default;
        }
    }
}
