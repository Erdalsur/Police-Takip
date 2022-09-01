namespace Policem.UI.Forms
{
    partial class FrmGelmeyenPoliceler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGelmeyenPoliceler));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barBtnExcell = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBtnPDF = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBtnGuncel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barBtnGuncelle = new DevExpress.XtraBars.BarButtonItem();
            this.gridControlPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gridViewPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnExcell,
            this.barBtnPDF,
            this.barBtnGuncelle,
            this.barBtnGuncel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExcell),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPDF),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnGuncel)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barBtnExcell
            // 
            this.barBtnExcell.Caption = "Excell\'e Aktar";
            this.barBtnExcell.Id = 0;
            this.barBtnExcell.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.Excel_32x32;
            this.barBtnExcell.Name = "barBtnExcell";
            this.barBtnExcell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExcell_ItemClick);
            // 
            // barBtnPDF
            // 
            this.barBtnPDF.Caption = "PDF\'e Aktar";
            this.barBtnPDF.Id = 1;
            this.barBtnPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnPDF.ImageOptions.Image")));
            this.barBtnPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnPDF.ImageOptions.LargeImage")));
            this.barBtnPDF.Name = "barBtnPDF";
            this.barBtnPDF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPDF_ItemClick);
            // 
            // barBtnGuncel
            // 
            this.barBtnGuncel.Caption = "Güncelle";
            this.barBtnGuncel.Id = 3;
            this.barBtnGuncel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnGuncel.ImageOptions.Image")));
            this.barBtnGuncel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnGuncel.ImageOptions.LargeImage")));
            this.barBtnGuncel.Name = "barBtnGuncel";
            this.barBtnGuncel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnGuncel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 58);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 58);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 392);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 58);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 392);
            // 
            // barBtnGuncelle
            // 
            this.barBtnGuncelle.Caption = "Güncelle";
            this.barBtnGuncelle.Id = 2;
            this.barBtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnGuncelle.ImageOptions.Image")));
            this.barBtnGuncelle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnGuncelle.ImageOptions.LargeImage")));
            this.barBtnGuncelle.Name = "barBtnGuncelle";
            // 
            // gridControlPoliceler
            // 
            this.gridControlPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPoliceler.Location = new System.Drawing.Point(0, 58);
            this.gridControlPoliceler.MainView = this.gridViewPoliceler;
            this.gridControlPoliceler.Name = "gridControlPoliceler";
            this.gridControlPoliceler.Size = new System.Drawing.Size(800, 392);
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
            this.gridViewPoliceler.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewPoliceler_RowClick);
            this.gridViewPoliceler.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.GridViewPoliceler_RowCellStyle);
            this.gridViewPoliceler.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewPoliceler_FocusedRowChanged);
            // 
            // FrmGelmeyenPoliceler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControlPoliceler);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "FrmGelmeyenPoliceler";
            this.Text = "Gelmeyen Poliçeler";
            this.Load += new System.EventHandler(this.FrmGelmeyenPoliceler_Load);
            this.Shown += new System.EventHandler(this.FrmGelmeyenPoliceler_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGelmeyenPoliceler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControlPoliceler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPoliceler;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnExcell;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnPDF;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnGuncel;
        private DevExpress.XtraBars.BarButtonItem barBtnGuncelle;
    }
}