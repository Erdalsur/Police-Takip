namespace Policem.UI.Forms
{
    partial class FrmPoliceler
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
            this.leftPanel = new DevExpress.XtraEditors.PanelControl();
            this.btnExcell = new DevExpress.XtraEditors.SimpleButton();
            this.CmbRaporTip = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbRaporSure = new DevExpress.XtraEditors.LookUpEdit();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gvPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoliceler)).BeginInit();
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
            this.leftPanel.Size = new System.Drawing.Size(239, 552);
            this.leftPanel.TabIndex = 4;
            // 
            // btnExcell
            // 
            this.btnExcell.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExcell.Location = new System.Drawing.Point(2, 508);
            this.btnExcell.Name = "btnExcell";
            this.btnExcell.Size = new System.Drawing.Size(235, 42);
            this.btnExcell.TabIndex = 5;
            this.btnExcell.Text = "Excell Aktar";
            this.btnExcell.Click += new System.EventHandler(this.BtnExcell_Click);
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
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(157, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem1.Text = "Yeni Poliçe Ekle";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.BtnYeniPolice_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(239, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcPoliceler);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pdfViewer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(992, 552);
            this.splitContainerControl1.SplitterPosition = 430;
            this.splitContainerControl1.TabIndex = 107;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcPoliceler
            // 
            this.gcPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPoliceler.Location = new System.Drawing.Point(0, 0);
            this.gcPoliceler.MainView = this.gvPoliceler;
            this.gcPoliceler.Name = "gcPoliceler";
            this.gcPoliceler.Size = new System.Drawing.Size(552, 552);
            this.gcPoliceler.TabIndex = 106;
            this.gcPoliceler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPoliceler});
            // 
            // gvPoliceler
            // 
            this.gvPoliceler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPoliceler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvPoliceler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvPoliceler.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPoliceler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.Row.Options.UseFont = true;
            this.gvPoliceler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.ViewCaption.Options.UseFont = true;
            this.gvPoliceler.GridControl = this.gcPoliceler;
            this.gvPoliceler.Name = "gvPoliceler";
            this.gvPoliceler.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvPoliceler.OptionsBehavior.Editable = false;
            this.gvPoliceler.OptionsBehavior.ReadOnly = true;
            this.gvPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvPoliceler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gvPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gvPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPoliceler.OptionsView.ShowGroupPanel = false;
            this.gvPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewPoliceler_RowClick);
            this.gvPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPoliceler_FocusedRowChanged);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.Size = new System.Drawing.Size(430, 552);
            this.pdfViewer1.TabIndex = 107;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToVisible;
            // 
            // FrmPoliceler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 552);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.leftPanel);
            this.KeyPreview = true;
            this.Name = "FrmPoliceler";
            this.Text = "Aktif Poliçeler";
            this.Load += new System.EventHandler(this.FrmPoliceler_Load);
            this.Shown += new System.EventHandler(this.FrmPoliceler_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPoliceler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.leftPanel)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporTip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbRaporSure.Properties)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoliceler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl leftPanel;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporSure;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit CmbRaporTip;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExcell;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPoliceler;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
    }
}