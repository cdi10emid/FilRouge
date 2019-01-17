namespace IHM
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSuprimOffre = new System.Windows.Forms.Button();
            this.buttonModifOffre = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPoste = new System.Windows.Forms.ComboBox();
            this.comboBoxContrat = new System.Windows.Forms.ComboBox();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.buttonmAJ = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDateDebut = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateFin = new System.Windows.Forms.DateTimePicker();
            this.buttonDate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMois = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.76846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.23154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1387, 899);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(1, 120);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1, 2, 4, 1);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1382, 678);
            this.dataGridView1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dataGridView1, "Liste des offres");
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.buttonModifOffre_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.buttonSuprimOffre);
            this.flowLayoutPanel2.Controls.Add(this.buttonModifOffre);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.buttonQuitter);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 802);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1381, 94);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // buttonSuprimOffre
            // 
            this.buttonSuprimOffre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSuprimOffre.Image = global::IHM.Properties.Resources.Symbol_Delete;
            this.buttonSuprimOffre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuprimOffre.Location = new System.Drawing.Point(4, 5);
            this.buttonSuprimOffre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSuprimOffre.Name = "buttonSuprimOffre";
            this.buttonSuprimOffre.Size = new System.Drawing.Size(416, 33);
            this.buttonSuprimOffre.TabIndex = 0;
            this.buttonSuprimOffre.Text = "Supprimer l\'offre sélectionnée";
            this.toolTip1.SetToolTip(this.buttonSuprimOffre, "Supprimer l\'offre sélectionnée");
            this.buttonSuprimOffre.UseVisualStyleBackColor = true;
            this.buttonSuprimOffre.Click += new System.EventHandler(this.buttonSuprimOffre_Click);
            // 
            // buttonModifOffre
            // 
            this.buttonModifOffre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonModifOffre.Image = global::IHM.Properties.Resources.Symbol_Check;
            this.buttonModifOffre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModifOffre.Location = new System.Drawing.Point(428, 5);
            this.buttonModifOffre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonModifOffre.Name = "buttonModifOffre";
            this.buttonModifOffre.Size = new System.Drawing.Size(416, 33);
            this.buttonModifOffre.TabIndex = 1;
            this.buttonModifOffre.Text = "Modifier l\'offre sélectionnée";
            this.toolTip1.SetToolTip(this.buttonModifOffre, "Modifier l\'offre sélectionnée");
            this.buttonModifOffre.UseVisualStyleBackColor = true;
            this.buttonModifOffre.Click += new System.EventHandler(this.buttonModifOffre_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(851, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 33);
            this.label5.TabIndex = 6;
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonQuitter.Image = global::IHM.Properties.Resources.Symbol_Delete;
            this.buttonQuitter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonQuitter.Location = new System.Drawing.Point(957, 5);
            this.buttonQuitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(416, 33);
            this.buttonQuitter.TabIndex = 5;
            this.buttonQuitter.Text = "Quitter";
            this.toolTip1.SetToolTip(this.buttonQuitter, "Validation de l\'offre");
            this.buttonQuitter.UseVisualStyleBackColor = false;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxPoste);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxContrat);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxRegion);
            this.flowLayoutPanel1.Controls.Add(this.buttonmAJ);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerDateDebut);
            this.flowLayoutPanel1.Controls.Add(this.dateTimePickerDateFin);
            this.flowLayoutPanel1.Controls.Add(this.buttonDate);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.textBoxMois);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1381, 112);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtres des offres";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPoste
            // 
            this.comboBoxPoste.FormattingEnabled = true;
            this.comboBoxPoste.Location = new System.Drawing.Point(425, 3);
            this.comboBoxPoste.Name = "comboBoxPoste";
            this.comboBoxPoste.Size = new System.Drawing.Size(201, 27);
            this.comboBoxPoste.TabIndex = 3;
            this.comboBoxPoste.SelectedIndexChanged += new System.EventHandler(this.comboBoxPoste_SelectedIndexChanged);
            // 
            // comboBoxContrat
            // 
            this.comboBoxContrat.FormattingEnabled = true;
            this.comboBoxContrat.Location = new System.Drawing.Point(632, 3);
            this.comboBoxContrat.Name = "comboBoxContrat";
            this.comboBoxContrat.Size = new System.Drawing.Size(199, 27);
            this.comboBoxContrat.TabIndex = 5;
            this.comboBoxContrat.Visible = false;
            this.comboBoxContrat.SelectedIndexChanged += new System.EventHandler(this.comboBoxContrat_SelectedIndexChanged);
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(837, 3);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(199, 27);
            this.comboBoxRegion.TabIndex = 4;
            this.comboBoxRegion.Visible = false;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
            // 
            // buttonmAJ
            // 
            this.buttonmAJ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonmAJ.Image = global::IHM.Properties.Resources.Symbol_Delete;
            this.buttonmAJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonmAJ.Location = new System.Drawing.Point(1040, 2);
            this.buttonmAJ.Margin = new System.Windows.Forms.Padding(1, 2, 4, 1);
            this.buttonmAJ.Name = "buttonmAJ";
            this.buttonmAJ.Size = new System.Drawing.Size(331, 29);
            this.buttonmAJ.TabIndex = 2;
            this.buttonmAJ.Text = "Annulation des filtres";
            this.toolTip1.SetToolTip(this.buttonmAJ, "Recharge la liste après une modification");
            this.buttonmAJ.UseVisualStyleBackColor = true;
            this.buttonmAJ.Click += new System.EventHandler(this.buttonmAJ_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filtres par dates de parution";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePickerDateDebut
            // 
            this.dateTimePickerDateDebut.Location = new System.Drawing.Point(425, 36);
            this.dateTimePickerDateDebut.Name = "dateTimePickerDateDebut";
            this.dateTimePickerDateDebut.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDateDebut.TabIndex = 7;
            // 
            // dateTimePickerDateFin
            // 
            this.dateTimePickerDateFin.Location = new System.Drawing.Point(631, 36);
            this.dateTimePickerDateFin.Name = "dateTimePickerDateFin";
            this.dateTimePickerDateFin.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerDateFin.TabIndex = 8;
            // 
            // buttonDate
            // 
            this.buttonDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDate.Image = global::IHM.Properties.Resources.Symbol_Check;
            this.buttonDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDate.Location = new System.Drawing.Point(835, 35);
            this.buttonDate.Margin = new System.Windows.Forms.Padding(1, 2, 4, 1);
            this.buttonDate.Name = "buttonDate";
            this.buttonDate.Size = new System.Drawing.Size(349, 29);
            this.buttonDate.TabIndex = 9;
            this.buttonDate.Text = "Sélectionner les offres par date";
            this.toolTip1.SetToolTip(this.buttonDate, "Recharge la liste après une modification");
            this.buttonDate.UseVisualStyleBackColor = true;
            this.buttonDate.Click += new System.EventHandler(this.buttonDate_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(417, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sélectionner  les offres des";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMois
            // 
            this.textBoxMois.Location = new System.Drawing.Point(426, 69);
            this.textBoxMois.MaxLength = 2;
            this.textBoxMois.Name = "textBoxMois";
            this.textBoxMois.Size = new System.Drawing.Size(44, 26);
            this.textBoxMois.TabIndex = 11;
            this.textBoxMois.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.textBoxMois, "Nombre de mois limité à 99");
            this.textBoxMois.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSemaine_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Location = new System.Drawing.Point(476, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 33);
            this.label4.TabIndex = 12;
            this.label4.Text = " derniers mois";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Image = global::IHM.Properties.Resources.Symbol_Check;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(835, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 2, 4, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(349, 27);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sélectionner";
            this.toolTip1.SetToolTip(this.button1, "Recharge la liste après une modification");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1387, 899);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Liste des offres";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSuprimOffre;
        private System.Windows.Forms.Button buttonModifOffre;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBoxPoste;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.ComboBox comboBoxContrat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateDebut;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateFin;
        private System.Windows.Forms.Button buttonDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMois;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonmAJ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonQuitter;
    }
}