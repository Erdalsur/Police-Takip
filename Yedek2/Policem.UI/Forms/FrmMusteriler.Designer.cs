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
            this.gridControlMusteriler = new DevExpress.XtraGrid.GridControl();
            this.gridViewMusteriler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.tabAktifPolice = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gridViewPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabMusterileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tabAktifPolice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).BeginInit();
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
            this.tabMusterileri.Controls.Add(this.gridControlMusteriler);
            this.tabMusterileri.Name = "tabMusterileri";
            this.tabMusterileri.Size = new System.Drawing.Size(933, 389);
            this.tabMusterileri.Text = "Müşteriler";
            // 
            // gridControlMusteriler
            // 
            this.gridControlMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMusteriler.Location = new System.Drawing.Point(0, 0);
            this.gridControlMusteriler.MainView = this.gridViewMusteriler;
            this.gridControlMusteriler.MenuManager = this.barManager1;
            this.gridControlMusteriler.Name = "gridControlMusteriler";
            this.gridControlMusteriler.Size = new System.Drawing.Size(933, 389);
            this.gridControlMusteriler.TabIndex = 103;
            this.gridControlMusteriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMusteriler});
            // 
            // gridViewMusteriler
            // 
            this.gridViewMusteriler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewMusteriler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewMusteriler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMusteriler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMusteriler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewMusteriler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewMusteriler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridViewMusteriler.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewMusteriler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewMusteriler.Appearance.Row.Options.UseFont = true;
            this.gridViewMusteriler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewMusteriler.Appearance.ViewCaption.Options.UseFont = true;
            this.gridViewMusteriler.GridControl = this.gridControlMusteriler;
            this.gridViewMusteriler.Name = "gridViewMusteriler";
            this.gridViewMusteriler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewMusteriler.OptionsBehavior.Editable = false;
            this.gridViewMusteriler.OptionsBehavior.ReadOnly = true;
            this.gridViewMusteriler.OptionsCustomization.AllowGroup = false;
            this.gridViewMusteriler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMusteriler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMusteriler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMusteriler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewMusteriler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridViewMusteriler.OptionsView.ColumnAutoWidth = false;
            this.gridViewMusteriler.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMusteriler.OptionsView.ShowGroupPanel = false;
            this.gridViewMusteriler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewMusteriler_RowClick);
            this.gridViewMusteriler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewMusteriler_FocusedRowChanged);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Yeni Müşteri Ekle";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // tabAktifPolice
            // 
            this.tabAktifPolice.Controls.Add(this.gridControlPoliceler);
            this.tabAktifPolice.Name = "tabAktifPolice";
            this.tabAktifPolice.Size = new System.Drawing.Size(933, 389);
            this.tabAktifPolice.Text = "Aktif Poliçeleri";
            // 
            // gridControlPoliceler
            // 
            this.gridControlPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPoliceler.Location = new System.Drawing.Point(0, 0);
            this.gridControlPoliceler.MainView = this.gridViewPoliceler;
            this.gridControlPoliceler.Name = "gridControlPoliceler";
            this.gridControlPoliceler.Size = new System.Drawing.Size(933, 389);
            this.gridControlPoliceler.TabIndex = 104;
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
            this.gridViewPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewPoliceler.OptionsBehavior.Editable = false;
            this.gridViewPoliceler.OptionsBehavior.ReadOnly = true;
            this.gridViewPoliceler.OptionsCustomization.AllowGroup = false;
            this.gridViewPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gridViewPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.ShowGroupPanel = false;
            this.gridViewPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.GridViewPoliceler_RowClick);
            this.gridViewPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridViewPoliceler_RowCellStyle);
            this.gridViewPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridViewPoliceler_FocusedRowChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tabAktifPolice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControlMusteriler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMusteriler;
        private DevExpress.XtraGrid.GridControl gridControlPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPoliceler;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}