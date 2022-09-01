namespace Policem.UI.Forms
{
    partial class FrmSigortaci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSigortaci));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTemsilciTelefon = new DevExpress.XtraEditors.LabelControl();
            this.lblTemsilciAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblHasarTelefonu = new DevExpress.XtraEditors.LabelControl();
            this.lblUnvan = new DevExpress.XtraEditors.LabelControl();
            this.lblFirmaKod = new DevExpress.XtraEditors.LabelControl();
            this.txtTemsilciTel = new DevExpress.XtraEditors.TextEdit();
            this.txtTemsilci = new DevExpress.XtraEditors.TextEdit();
            this.txtHasarTel = new DevExpress.XtraEditors.TextEdit();
            this.txtUnvan = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtFirmaKod = new DevExpress.XtraEditors.ButtonEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gcSigortacilar = new DevExpress.XtraGrid.GridControl();
            this.gvSigortacilar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSigortacilar = new System.Windows.Forms.DataGridView();
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPoliceEkle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPoliçeleri = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSil = new System.Windows.Forms.ToolStripMenuItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemsilciTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemsilci.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasarTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaKod.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSigortacilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSigortacilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSigortacilar)).BeginInit();
            this.gridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(838, 450);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTemsilciTelefon);
            this.panel1.Controls.Add(this.lblTemsilciAdi);
            this.panel1.Controls.Add(this.lblHasarTelefonu);
            this.panel1.Controls.Add(this.lblUnvan);
            this.panel1.Controls.Add(this.lblFirmaKod);
            this.panel1.Controls.Add(this.txtTemsilciTel);
            this.panel1.Controls.Add(this.txtTemsilci);
            this.panel1.Controls.Add(this.txtHasarTel);
            this.panel1.Controls.Add(this.txtUnvan);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.txtFirmaKod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 450);
            this.panel1.TabIndex = 0;
            // 
            // lblTemsilciTelefon
            // 
            this.lblTemsilciTelefon.Location = new System.Drawing.Point(12, 122);
            this.lblTemsilciTelefon.Name = "lblTemsilciTelefon";
            this.lblTemsilciTelefon.Size = new System.Drawing.Size(75, 13);
            this.lblTemsilciTelefon.TabIndex = 80;
            this.lblTemsilciTelefon.Text = "Temsilci Telefon";
            // 
            // lblTemsilciAdi
            // 
            this.lblTemsilciAdi.Location = new System.Drawing.Point(33, 96);
            this.lblTemsilciAdi.Name = "lblTemsilciAdi";
            this.lblTemsilciAdi.Size = new System.Drawing.Size(54, 13);
            this.lblTemsilciAdi.TabIndex = 79;
            this.lblTemsilciAdi.Text = "Temsilci Adı";
            // 
            // lblHasarTelefonu
            // 
            this.lblHasarTelefonu.Location = new System.Drawing.Point(14, 70);
            this.lblHasarTelefonu.Name = "lblHasarTelefonu";
            this.lblHasarTelefonu.Size = new System.Drawing.Size(73, 13);
            this.lblHasarTelefonu.TabIndex = 78;
            this.lblHasarTelefonu.Text = "Hasar Telefonu";
            // 
            // lblUnvan
            // 
            this.lblUnvan.Location = new System.Drawing.Point(25, 44);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(62, 13);
            this.lblUnvan.TabIndex = 77;
            this.lblUnvan.Text = "Firma Ünvanı";
            // 
            // lblFirmaKod
            // 
            this.lblFirmaKod.Location = new System.Drawing.Point(34, 18);
            this.lblFirmaKod.Name = "lblFirmaKod";
            this.lblFirmaKod.Size = new System.Drawing.Size(53, 13);
            this.lblFirmaKod.TabIndex = 76;
            this.lblFirmaKod.Text = "Firma Kodu";
            // 
            // txtTemsilciTel
            // 
            this.txtTemsilciTel.Location = new System.Drawing.Point(94, 119);
            this.txtTemsilciTel.Name = "txtTemsilciTel";
            this.txtTemsilciTel.Size = new System.Drawing.Size(224, 20);
            this.txtTemsilciTel.TabIndex = 50;
            // 
            // txtTemsilci
            // 
            this.txtTemsilci.Location = new System.Drawing.Point(94, 93);
            this.txtTemsilci.Name = "txtTemsilci";
            this.txtTemsilci.Size = new System.Drawing.Size(224, 20);
            this.txtTemsilci.TabIndex = 40;
            // 
            // txtHasarTel
            // 
            this.txtHasarTel.Location = new System.Drawing.Point(94, 67);
            this.txtHasarTel.Name = "txtHasarTel";
            this.txtHasarTel.Size = new System.Drawing.Size(224, 20);
            this.txtHasarTel.TabIndex = 30;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(94, 41);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(224, 20);
            this.txtUnvan.TabIndex = 20;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(180, 163);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(112, 41);
            this.simpleButton2.TabIndex = 70;
            this.simpleButton2.Text = "İptal";
            this.simpleButton2.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackgroundImage = global::Policem.UI.Properties.Resources.Save_32x32;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(27, 163);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(122, 41);
            this.simpleButton1.TabIndex = 60;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // txtFirmaKod
            // 
            this.txtFirmaKod.Location = new System.Drawing.Point(94, 15);
            this.txtFirmaKod.Name = "txtFirmaKod";
            this.txtFirmaKod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtFirmaKod.Size = new System.Drawing.Size(142, 20);
            this.txtFirmaKod.TabIndex = 10;
            this.txtFirmaKod.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.TxtFirmaKod_ButtonClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gcSigortacilar);
            this.panel2.Controls.Add(this.gridSigortacilar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 450);
            this.panel2.TabIndex = 0;
            // 
            // gcSigortacilar
            // 
            this.gcSigortacilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSigortacilar.Location = new System.Drawing.Point(0, 0);
            this.gcSigortacilar.MainView = this.gvSigortacilar;
            this.gcSigortacilar.Name = "gcSigortacilar";
            this.gcSigortacilar.Size = new System.Drawing.Size(504, 450);
            this.gcSigortacilar.TabIndex = 102;
            this.gcSigortacilar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSigortacilar});
            // 
            // gvSigortacilar
            // 
            this.gvSigortacilar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvSigortacilar.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSigortacilar.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvSigortacilar.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvSigortacilar.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvSigortacilar.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvSigortacilar.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gvSigortacilar.Appearance.OddRow.Options.UseBackColor = true;
            this.gvSigortacilar.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvSigortacilar.Appearance.Row.Options.UseFont = true;
            this.gvSigortacilar.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvSigortacilar.Appearance.ViewCaption.Options.UseFont = true;
            this.gvSigortacilar.GridControl = this.gcSigortacilar;
            this.gvSigortacilar.Name = "gvSigortacilar";
            this.gvSigortacilar.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvSigortacilar.OptionsBehavior.Editable = false;
            this.gvSigortacilar.OptionsBehavior.ReadOnly = true;
            this.gvSigortacilar.OptionsCustomization.AllowGroup = false;
            this.gvSigortacilar.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gvSigortacilar.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gvSigortacilar.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gvSigortacilar.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvSigortacilar.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvSigortacilar.OptionsView.ColumnAutoWidth = false;
            this.gvSigortacilar.OptionsView.EnableAppearanceEvenRow = true;
            this.gvSigortacilar.OptionsView.ShowGroupPanel = false;
            this.gvSigortacilar.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridView1_RowClick);
            // 
            // gridSigortacilar
            // 
            this.gridSigortacilar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridSigortacilar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridSigortacilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSigortacilar.Location = new System.Drawing.Point(25, 332);
            this.gridSigortacilar.MultiSelect = false;
            this.gridSigortacilar.Name = "gridSigortacilar";
            this.gridSigortacilar.ReadOnly = true;
            this.gridSigortacilar.RowTemplate.ContextMenuStrip = this.gridMenu;
            this.gridSigortacilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSigortacilar.Size = new System.Drawing.Size(442, 86);
            this.gridSigortacilar.TabIndex = 101;
            this.gridSigortacilar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridSigortacilar_CellDoubleClick);
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPoliceEkle,
            this.btnPoliçeleri,
            this.btnSil});
            this.gridMenu.Name = "contextMenuStrip1";
            this.gridMenu.Size = new System.Drawing.Size(157, 70);
            this.gridMenu.Text = "Menu";
            // 
            // btnPoliceEkle
            // 
            this.btnPoliceEkle.Name = "btnPoliceEkle";
            this.btnPoliceEkle.Size = new System.Drawing.Size(156, 22);
            this.btnPoliceEkle.Text = "Poliçe Ekle";
            this.btnPoliceEkle.Click += new System.EventHandler(this.BtnPoliceEkle_Click);
            // 
            // btnPoliçeleri
            // 
            this.btnPoliçeleri.Name = "btnPoliçeleri";
            this.btnPoliçeleri.Size = new System.Drawing.Size(156, 22);
            this.btnPoliçeleri.Text = "Alınan Poliçeler";
            this.btnPoliçeleri.Click += new System.EventHandler(this.BtnPoliceleri_Click);
            // 
            // btnSil
            // 
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(156, 22);
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // FrmSigortaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSigortaci";
            this.Text = "Sigortacılar";
            this.Load += new System.EventHandler(this.FrmSigortaci_Load);
            this.Shown += new System.EventHandler(this.FrmSigortaci_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemsilciTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemsilci.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHasarTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnvan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirmaKod.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSigortacilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSigortacilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSigortacilar)).EndInit();
            this.gridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem btnPoliceEkle;
        private System.Windows.Forms.ToolStripMenuItem btnPoliçeleri;
        private System.Windows.Forms.ToolStripMenuItem btnSil;
        private DevExpress.XtraEditors.ButtonEdit txtFirmaKod;
        private DevExpress.XtraGrid.GridControl gcSigortacilar;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSigortacilar;
        private System.Windows.Forms.DataGridView gridSigortacilar;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtUnvan;
        private DevExpress.XtraEditors.TextEdit txtTemsilciTel;
        private DevExpress.XtraEditors.TextEdit txtTemsilci;
        private DevExpress.XtraEditors.TextEdit txtHasarTel;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LabelControl lblTemsilciTelefon;
        private DevExpress.XtraEditors.LabelControl lblTemsilciAdi;
        private DevExpress.XtraEditors.LabelControl lblHasarTelefonu;
        private DevExpress.XtraEditors.LabelControl lblUnvan;
        private DevExpress.XtraEditors.LabelControl lblFirmaKod;
    }
}