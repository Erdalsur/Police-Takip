namespace Policem.UI.Forms
{
    partial class FrmMusteriler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridMusteriler = new System.Windows.Forms.DataGridView();
            this.menuYeniMusteri = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnYeniMusteri = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMusteriDetay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPoliceEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSil = new System.Windows.Forms.ToolStripMenuItem();
            this.btnYeniMusteri2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridPoliceler = new System.Windows.Forms.DataGridView();
            this.menuPolice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.açToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniPoliçeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poliçeyiYenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).BeginInit();
            this.menuYeniMusteri.SuspendLayout();
            this.menuMusteriDetay.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPoliceler)).BeginInit();
            this.menuPolice.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUnvan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 33);
            this.panel1.TabIndex = 0;
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUnvan.Location = new System.Drawing.Point(3, 1);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(75, 29);
            this.lblUnvan.TabIndex = 1;
            this.lblUnvan.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 417);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridMusteriler);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Müşterilerim";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridMusteriler
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMusteriler.ContextMenuStrip = this.menuYeniMusteri;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMusteriler.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMusteriler.Location = new System.Drawing.Point(3, 3);
            this.gridMusteriler.MultiSelect = false;
            this.gridMusteriler.Name = "gridMusteriler";
            this.gridMusteriler.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMusteriler.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridMusteriler.RowTemplate.ContextMenuStrip = this.menuMusteriDetay;
            this.gridMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMusteriler.Size = new System.Drawing.Size(786, 385);
            this.gridMusteriler.TabIndex = 0;
            this.gridMusteriler.TabStop = false;
            this.gridMusteriler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridMusteriler_CellDoubleClick);
            this.gridMusteriler.SelectionChanged += new System.EventHandler(this.GridMusteriler_SelectionChanged);
            // 
            // menuYeniMusteri
            // 
            this.menuYeniMusteri.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnYeniMusteri});
            this.menuYeniMusteri.Name = "contextMenuStrip1";
            this.menuYeniMusteri.Size = new System.Drawing.Size(141, 26);
            // 
            // btnYeniMusteri
            // 
            this.btnYeniMusteri.Name = "btnYeniMusteri";
            this.btnYeniMusteri.Size = new System.Drawing.Size(140, 22);
            this.btnYeniMusteri.Text = "Yeni Müşteri";
            this.btnYeniMusteri.Click += new System.EventHandler(this.BtnYeniMusteri_Click);
            // 
            // menuMusteriDetay
            // 
            this.menuMusteriDetay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAc,
            this.btnPoliceEkle,
            this.btnSil,
            this.btnYeniMusteri2});
            this.menuMusteriDetay.Name = "contextMenuStrip2";
            this.menuMusteriDetay.Size = new System.Drawing.Size(141, 92);
            // 
            // btnAc
            // 
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(140, 22);
            this.btnAc.Text = "Aç";
            this.btnAc.Click += new System.EventHandler(this.BtnAc_Click);
            // 
            // btnPoliceEkle
            // 
            this.btnPoliceEkle.Name = "btnPoliceEkle";
            this.btnPoliceEkle.Size = new System.Drawing.Size(140, 22);
            this.btnPoliceEkle.Text = "Poliçe Ekle";
            this.btnPoliceEkle.Click += new System.EventHandler(this.BtnPoliceEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(140, 22);
            this.btnSil.Text = "Sil";
            // 
            // btnYeniMusteri2
            // 
            this.btnYeniMusteri2.Name = "btnYeniMusteri2";
            this.btnYeniMusteri2.Size = new System.Drawing.Size(140, 22);
            this.btnYeniMusteri2.Text = "Yeni Müşteri";
            this.btnYeniMusteri2.Click += new System.EventHandler(this.BtnYeniMusteri_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridPoliceler);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Aktif Poliçesi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridPoliceler
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPoliceler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridPoliceler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPoliceler.Location = new System.Drawing.Point(3, 3);
            this.gridPoliceler.MultiSelect = false;
            this.gridPoliceler.Name = "gridPoliceler";
            this.gridPoliceler.ReadOnly = true;
            this.gridPoliceler.RowTemplate.ContextMenuStrip = this.menuPolice;
            this.gridPoliceler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPoliceler.Size = new System.Drawing.Size(786, 385);
            this.gridPoliceler.TabIndex = 0;
            this.gridPoliceler.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPoliceler_CellContentDoubleClick);
            this.gridPoliceler.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridPoliceler_DataBindingComplete);
            // 
            // menuPolice
            // 
            this.menuPolice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açToolStripMenuItem,
            this.yeniPoliçeToolStripMenuItem,
            this.silToolStripMenuItem,
            this.poliçeyiYenileToolStripMenuItem});
            this.menuPolice.Name = "menuPolice";
            this.menuPolice.Size = new System.Drawing.Size(181, 114);
            // 
            // açToolStripMenuItem
            // 
            this.açToolStripMenuItem.Name = "açToolStripMenuItem";
            this.açToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.açToolStripMenuItem.Text = "Aç";
            this.açToolStripMenuItem.Click += new System.EventHandler(this.AcToolStripMenuItem_Click);
            // 
            // yeniPoliçeToolStripMenuItem
            // 
            this.yeniPoliçeToolStripMenuItem.Name = "yeniPoliçeToolStripMenuItem";
            this.yeniPoliçeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.yeniPoliçeToolStripMenuItem.Text = "Yeni Poliçe";
            this.yeniPoliçeToolStripMenuItem.Click += new System.EventHandler(this.BtnPoliceEkle_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.silToolStripMenuItem.Text = "Sil";
            // 
            // poliçeyiYenileToolStripMenuItem
            // 
            this.poliçeyiYenileToolStripMenuItem.Name = "poliçeyiYenileToolStripMenuItem";
            this.poliçeyiYenileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.poliçeyiYenileToolStripMenuItem.Text = "Poliçeyi Yenile";
            this.poliçeyiYenileToolStripMenuItem.Click += new System.EventHandler(this.PoliçeyiYenileToolStripMenuItem_Click);
            // 
            // FrmMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMusteriler";
            this.Text = "Müşteriler";
            this.Load += new System.EventHandler(this.FrmMusteriler_Load);
            this.Shown += new System.EventHandler(this.FrmMusteriler_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMusteriler)).EndInit();
            this.menuYeniMusteri.ResumeLayout(false);
            this.menuMusteriDetay.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPoliceler)).EndInit();
            this.menuPolice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridMusteriler;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridPoliceler;
        private System.Windows.Forms.ContextMenuStrip menuMusteriDetay;
        private System.Windows.Forms.ToolStripMenuItem btnAc;
        private System.Windows.Forms.ToolStripMenuItem btnPoliceEkle;
        private System.Windows.Forms.ToolStripMenuItem btnSil;
        private System.Windows.Forms.ToolStripMenuItem btnYeniMusteri2;
        private System.Windows.Forms.ContextMenuStrip menuYeniMusteri;
        private System.Windows.Forms.ToolStripMenuItem btnYeniMusteri;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.ContextMenuStrip menuPolice;
        private System.Windows.Forms.ToolStripMenuItem açToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yeniPoliçeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poliçeyiYenileToolStripMenuItem;
    }
}