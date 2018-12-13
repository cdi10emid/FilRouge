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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSuprimOffre = new System.Windows.Forms.Button();
            this.buttonModifOffre = new System.Windows.Forms.Button();
            this.buttonmAJ = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.19824F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.80176F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1764, 797);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 5);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1756, 676);
            this.dataGridView1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dataGridView1, "Liste des offres");
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Controls.Add(this.buttonSuprimOffre);
            this.flowLayoutPanel1.Controls.Add(this.buttonModifOffre);
            this.flowLayoutPanel1.Controls.Add(this.buttonmAJ);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 691);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1756, 101);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonSuprimOffre
            // 
            this.buttonSuprimOffre.Image = global::IHM.Properties.Resources.Symbol_Delete;
            this.buttonSuprimOffre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuprimOffre.Location = new System.Drawing.Point(4, 5);
            this.buttonSuprimOffre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSuprimOffre.Name = "buttonSuprimOffre";
            this.buttonSuprimOffre.Size = new System.Drawing.Size(374, 35);
            this.buttonSuprimOffre.TabIndex = 0;
            this.buttonSuprimOffre.Text = "Supprimer l\'offre sélectionnée";
            this.toolTip1.SetToolTip(this.buttonSuprimOffre, "Supprimer l\'offre sélectionnée");
            this.buttonSuprimOffre.UseVisualStyleBackColor = true;
            this.buttonSuprimOffre.Click += new System.EventHandler(this.buttonSuprimOffre_Click);
            // 
            // buttonModifOffre
            // 
            this.buttonModifOffre.Image = global::IHM.Properties.Resources.Symbol_Check;
            this.buttonModifOffre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModifOffre.Location = new System.Drawing.Point(386, 5);
            this.buttonModifOffre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonModifOffre.Name = "buttonModifOffre";
            this.buttonModifOffre.Size = new System.Drawing.Size(314, 35);
            this.buttonModifOffre.TabIndex = 1;
            this.buttonModifOffre.Text = "Modifier l\'offre sélectionnée";
            this.toolTip1.SetToolTip(this.buttonModifOffre, "Modifier l\'offre sélectionnée");
            this.buttonModifOffre.UseVisualStyleBackColor = true;
            this.buttonModifOffre.Click += new System.EventHandler(this.buttonModifOffre_Click);
            // 
            // buttonmAJ
            // 
            this.buttonmAJ.Image = global::IHM.Properties.Resources.Symbol_Refresh;
            this.buttonmAJ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonmAJ.Location = new System.Drawing.Point(708, 5);
            this.buttonmAJ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonmAJ.Name = "buttonmAJ";
            this.buttonmAJ.Size = new System.Drawing.Size(314, 35);
            this.buttonmAJ.TabIndex = 2;
            this.buttonmAJ.Text = "Mise à jour de la liste";
            this.toolTip1.SetToolTip(this.buttonmAJ, "Recharge la liste après une modification");
            this.buttonmAJ.UseVisualStyleBackColor = true;
            this.buttonmAJ.Click += new System.EventHandler(this.buttonmAJ_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1764, 797);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Liste des offres";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonSuprimOffre;
        private System.Windows.Forms.Button buttonModifOffre;
        private System.Windows.Forms.Button buttonmAJ;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}