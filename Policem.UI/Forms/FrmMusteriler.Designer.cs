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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblUnvan = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabMusterileri = new DevExpress.XtraTab.XtraTabPage();
            this.gcMusteriler = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniMüşteriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvMusteriler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.tabAktifPolice = new DevExpress.XtraTab.XtraTabPage();
            this.gcPoliceler = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabMusterileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcMusteriler)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tabAktifPolice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPoliceler)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblUnvan);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(939, 33);
            this.panelControl1.TabIndex = 4;
            // 
            // lblUnvan
            // 
            this.lblUnvan.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUnvan.Appearance.Options.UseFont = true;
            this.lblUnvan.Location = new System.Drawing.Point(2, 2);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(90, 29);
            this.lblUnvan.TabIndex = 3;
            this.lblUnvan.Text = "lblUnvan";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 33);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabMusterileri;
            this.xtraTabControl1.Size = new System.Drawing.Size(939, 417);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabMusterileri,
            this.tabAktifPolice});
            // 
            // tabMusterileri
            // 
            this.tabMusterileri.Controls.Add(this.gcMusteriler);
            this.tabMusterileri.Name = "tabMusterileri";
            this.tabMusterileri.Size = new System.Drawing.Size(933, 389);
            this.tabMusterileri.Text = "Müşteriler";
            // 
            // gcMusteriler
            // 
            this.gcMusteriler.ContextMenuStrip = this.contextMenuStrip1;
            this.gcMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMusteriler.Location = new System.Drawing.Point(0, 0);
            this.gcMusteriler.MainView = this.gvMusteriler;
            this.gcMusteriler.MenuManager = this.barManager1;
            this.gcMusteriler.Name = "gcMusteriler";
            this.gcMusteriler.Size = new System.Drawing.Size(933, 389);
            this.gcMusteriler.TabIndex = 103;
            this.gcMusteriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMusteriler});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniMüşteriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 26);
            // 
            // yeniMüşteriToolStripMenuItem
            // 
            this.yeniMüşteriToolStripMenuItem.Name = "yeniMüşteriToolStripMenuItem";
            this.yeniMüşteriToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.yeniMüşteriToolStripMenuItem.Text = "Yeni Müşteri Ekle";
            this.yeniMüşteriToolStripMenuItem.Click += new System.EventHandler(this.BtnYeniMusteri_Click);
            // 
            // gvMusteriler
            // 
            this.gvMusteriler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvMusteriler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMusteriler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMusteriler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMusteriler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvMusteriler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvMusteriler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gvMusteriler.Appearance.OddRow.Options.UseBackColor = true;
            this.gvMusteriler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvMusteriler.Appearance.Row.Options.UseFont = true;
            this.gvMusteriler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvMusteriler.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMusteriler.GridControl = this.gcMusteriler;
            this.gvMusteriler.Name = "gvMusteriler";
            this.gvMusteriler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvMusteriler.OptionsBehavior.Editable = false;
            this.gvMusteriler.OptionsBehavior.ReadOnly = true;
            this.gvMusteriler.OptionsCustomization.AllowGroup = false;
            this.gvMusteriler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gvMusteriler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gvMusteriler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gvMusteriler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvMusteriler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvMusteriler.OptionsView.ColumnAutoWidth = false;
            this.gvMusteriler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvMusteriler.OptionsView.ShowGroupPanel = false;
            this.gvMusteriler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewMusteriler_RowClick);
            this.gvMusteriler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewMusteriler_FocusedRowChanged);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1});
            this.barManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(939, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(939, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 450);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(939, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 450);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Yeni Müşteri";
            this.barSubItem1.Id = 1;
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem1_ItemClick);
            // 
            // tabAktifPolice
            // 
            this.tabAktifPolice.Controls.Add(this.gcPoliceler);
            this.tabAktifPolice.Name = "tabAktifPolice";
            this.tabAktifPolice.Size = new System.Drawing.Size(933, 389);
            this.tabAktifPolice.Text = "Aktif Poliçeleri";
            // 
            // gcPoliceler
            // 
            this.gcPoliceler.ContextMenuStrip = this.contextMenuStrip2;
            this.gcPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPoliceler.Location = new System.Drawing.Point(0, 0);
            this.gcPoliceler.MainView = this.gvPoliceler;
            this.gcPoliceler.MenuManager = this.barManager1;
            this.gcPoliceler.Name = "gcPoliceler";
            this.gcPoliceler.Size = new System.Drawing.Size(933, 389);
            this.gcPoliceler.TabIndex = 104;
            this.gcPoliceler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPoliceler});
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
            this.toolStripMenuItem1.Image = global::Policem.UI.Properties.Resources.New;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem1.Text = "Yeni Poliçe Ekle";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.BtnYeniPolice_Click);
            // 
            // gvPoliceler
            // 
            this.gvPoliceler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPoliceler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvPoliceler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gvPoliceler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gvPoliceler.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPoliceler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.Row.Options.UseFont = true;
            this.gvPoliceler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvPoliceler.Appearance.ViewCaption.Options.UseFont = true;
            this.gvPoliceler.GridControl = this.gcPoliceler;
            this.gvPoliceler.Name = "gvPoliceler";
            this.gvPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvPoliceler.OptionsBehavior.Editable = false;
            this.gvPoliceler.OptionsBehavior.ReadOnly = true;
            this.gvPoliceler.OptionsCustomization.AllowGroup = false;
            this.gvPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gvPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gvPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gvPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gvPoliceler.OptionsView.ShowGroupPanel = false;
            this.gvPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewPoliceler_RowClick);
            this.gvPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridViewPoliceler_RowCellStyle);
            this.gvPoliceler.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridViewPoliceler_PopupMenuShowing);
            this.gvPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPoliceler_FocusedRowChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // FrmMusteriler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmMusteriler";
            this.Text = "Müşteriler";
            this.Load += new System.EventHandler(this.FrmMusteriler_Load);
            this.Shown += new System.EventHandler(this.FrmMusteriler_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabMusterileri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcMusteriler)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tabAktifPolice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPoliceler)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblUnvan;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabMusterileri;
        private DevExpress.XtraTab.XtraTabPage tabAktifPolice;
        private DevExpress.XtraGrid.GridControl gcMusteriler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMusteriler;
        private DevExpress.XtraGrid.GridControl gcPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPoliceler;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniMüşteriToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}