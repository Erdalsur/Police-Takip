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
            this.leftPanel = new DevExpress.XtraEditors.PanelControl();
            this.btnExcell = new DevExpress.XtraEditors.SimpleButton();
            this.CmbRaporTip = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbRaporSure = new DevExpress.XtraEditors.LookUpEdit();
            this.gridControlPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gridViewPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
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
            // btnExcell
            // 
            this.btnExcell.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExcell.ImageOptions.Image = global::Policem.UI.Properties.Resources.Excel_32x32;
            this.btnExcell.Location = new System.Drawing.Point(2, 406);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(235, 42);
            this.btnExcell.TabIndex = 6;
            this.btnExcell.Text = "Excell Aktar";
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
            // gridControlPoliceler
            // 
            this.gridControlPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPoliceler.Location = new System.Drawing.Point(239, 0);
            this.gridControlPoliceler.MainView = this.gridViewPoliceler;
            this.gridControlPoliceler.Name = "gridControlPoliceler";
            this.gridControlPoliceler.Size = new System.Drawing.Size(561, 450);
            this.gridControlPoliceler.TabIndex = 106;
            this.gridControlPoliceler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPoliceler});
            // 
            // gridViewPoliceler
            // 
            this.gridViewPoliceler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewPoliceler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewPoliceler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridViewPoliceler.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewPoliceler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.Row.Options.UseFont = true;
            this.gridViewPoliceler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.ViewCaption.Options.UseFont = true;
            this.gridViewPoliceler.GridControl = this.gridControlPoliceler;
            this.gridViewPoliceler.Name = "gridViewPoliceler";
            this.gridViewPoliceler.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewPoliceler.OptionsBehavior.Editable = false;
            this.gridViewPoliceler.OptionsBehavior.ReadOnly = true;
            this.gridViewPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gridViewPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.ShowGroupPanel = false;
            this.gridViewPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewPoliceler_RowClick);
            this.gridViewPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridViewPoliceler_RowCellStyle);
            this.gridViewPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPoliceler_FocusedRowChanged);
            // 
            // FrmPasifPoliceler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControlPoliceler);
            this.Controls.Add(this.leftPanel);
            this.Name = "FrmPasifPoliceler";
            this.Text = "Pasif Poliçeler";
            this.Load += new System.EventHandler(this.FrmPasifPoliceler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl leftPanel;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporTip;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporSure;
        private DevExpress.XtraGrid.GridControl gridControlPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPoliceler;
        private DevExpress.XtraEditors.SimpleButton btnExcell;
    }
}