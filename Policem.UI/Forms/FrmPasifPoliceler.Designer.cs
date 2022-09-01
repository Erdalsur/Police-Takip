namespace Policem.UI.Forms
{
    partial class FrmPasifPoliceler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPasifPoliceler));
            this.leftPanel = new DevExpress.XtraEditors.PanelControl();
            this.CmbYenilendimi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnExcell = new DevExpress.XtraEditors.SimpleButton();
            this.CmbRaporTip = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbRaporSure = new DevExpress.XtraEditors.LookUpEdit();
            this.gcPasifPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gvPasifPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryYenilendi = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.ımageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbYenilendimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPasifPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPasifPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryYenilendi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.CmbYenilendimi);
            this.leftPanel.Controls.Add(this.labelControl3);
            this.leftPanel.Controls.Add(this.btnExcell);
            this.leftPanel.Controls.Add(this.CmbRaporTip);
            this.leftPanel.Controls.Add(this.labelControl2);
            this.leftPanel.Controls.Add(this.labelControl1);
            this.leftPanel.Controls.Add(this.CmbRaporSure);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(239, 450);
            this.leftPanel.TabIndex = 5;
            // 
            // CmbYenilendimi
            // 
            this.CmbYenilendimi.Location = new System.Drawing.Point(1, 117);
            this.CmbYenilendimi.Name = "CmbYenilendimi";
            this.CmbYenilendimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbYenilendimi.Size = new System.Drawing.Size(237, 20);
            this.CmbYenilendimi.TabIndex = 8;
            this.CmbYenilendimi.EditValueChanged += new System.EventHandler(this.CmbRaporSure_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(2, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(88, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Yenilenme Durumu";
            // 
            // btnExcell
            // 
            this.btnExcell.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExcell.ImageOptions.Image = global::Policem.UI.Properties.Resources.Excel_32x32;
            this.btnExcell.Location = new System.Drawing.Point(2, 406);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(235, 42);
            this.btnExcell.TabIndex = 6;
            this.btnExcell.Text = "Excell Aktar";
            this.btnExcell.Click += new System.EventHandler(this.btnExcell_Click);
            // 
            // CmbRaporTip
            // 
            this.CmbRaporTip.Location = new System.Drawing.Point(1, 67);
            this.CmbRaporTip.Name = "CmbRaporTip";
            this.CmbRaporTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbRaporTip.Size = new System.Drawing.Size(237, 20);
            this.CmbRaporTip.TabIndex = 4;
            this.CmbRaporTip.EditValueChanged += new System.EventHandler(this.CmbRaporSure_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(2, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Rapor Tipi";
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Poliçe Bitim Süresi";
            // 
            // CmbRaporSure
            // 
            this.CmbRaporSure.Location = new System.Drawing.Point(2, 18);
            this.CmbRaporSure.Name = "CmbRaporSure";
            this.CmbRaporSure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbRaporSure.Size = new System.Drawing.Size(237, 20);
            this.CmbRaporSure.TabIndex = 1;
            this.CmbRaporSure.EditValueChanged += new System.EventHandler(this.CmbRaporSure_EditValueChanged);
            // 
            // gcPasifPoliceler
            // 
            this.gcPasifPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPasifPoliceler.Location = new System.Drawing.Point(239, 0);
            this.gcPasifPoliceler.MainView = this.gvPasifPoliceler;
            this.gcPasifPoliceler.Name = "gcPasifPoliceler";
            this.gcPasifPoliceler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryYenilendi});
            this.gcPasifPoliceler.Size = new System.Drawing.Size(561, 450);
            this.gcPasifPoliceler.TabIndex = 106;
            this.gcPasifPoliceler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPasifPoliceler});
            // 
            // gvPasifPoliceler
            // 
            this.gvPasifPoliceler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPasifPoliceler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPasifPoliceler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPasifPoliceler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPasifPoliceler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvPasifPoliceler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvPasifPoliceler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gvPasifPoliceler.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPasifPoliceler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPasifPoliceler.Appearance.Row.Options.UseFont = true;
            this.gvPasifPoliceler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPasifPoliceler.Appearance.ViewCaption.Options.UseFont = true;
            this.gvPasifPoliceler.GridControl = this.gcPasifPoliceler;
            this.gvPasifPoliceler.Name = "gvPasifPoliceler";
            this.gvPasifPoliceler.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvPasifPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvPasifPoliceler.OptionsBehavior.Editable = false;
            this.gvPasifPoliceler.OptionsBehavior.ReadOnly = true;
            this.gvPasifPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gvPasifPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gvPasifPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gvPasifPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvPasifPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvPasifPoliceler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gvPasifPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gvPasifPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPasifPoliceler.OptionsView.ShowGroupPanel = false;
            this.gvPasifPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewPoliceler_RowClick);
            this.gvPasifPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridViewPoliceler_RowCellStyle);
            this.gvPasifPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPoliceler_FocusedRowChanged);
            // 
            // repositoryYenilendi
            // 
            this.repositoryYenilendi.AutoHeight = false;
            this.repositoryYenilendi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryYenilendi.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Yenilendi", 1, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("YENİLENMEDİ", 0, 0)});
            this.repositoryYenilendi.LargeImages = this.ımageCollection1;
            this.repositoryYenilendi.Name = "repositoryYenilendi";
            // 
            // ımageCollection1
            // 
            this.ımageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ımageCollection1.ImageStream")));
            this.ımageCollection1.Images.SetKeyName(0, "Error 32x32.png");
            this.ımageCollection1.Images.SetKeyName(1, "refresh 32x32.png");
            // 
            // FrmPasifPoliceler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gcPasifPoliceler);
            this.Controls.Add(this.leftPanel);
            this.Name = "FrmPasifPoliceler";
            this.Text = "Pasif Poliçeler";
            this.Load += new System.EventHandler(this.FrmPasifPoliceler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbYenilendimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPasifPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPasifPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryYenilendi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl leftPanel;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporTip;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporSure;
        private DevExpress.XtraGrid.GridControl gcPasifPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPasifPoliceler;
        private DevExpress.XtraEditors.SimpleButton btnExcell;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryYenilendi;
        private DevExpress.Utils.ImageCollection ımageCollection1;
        private DevExpress.XtraEditors.LookUpEdit CmbYenilendimi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}