namespace Policem.UI.Forms
{
    partial class RibbonMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonMainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSigortacilar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMusteriler = new DevExpress.XtraBars.BarButtonItem();
            this.btnAktifPoliceler = new DevExpress.XtraBars.BarButtonItem();
            this.BsiInfo = new DevExpress.XtraBars.BarStaticItem();
            this.btnGenelAyarlar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPasifPoliceler = new DevExpress.XtraBars.BarButtonItem();
            this.btnGelmeyenPoliceler = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDatabaseAyar = new DevExpress.XtraBars.BarButtonItem();
            this.barTextSaat = new DevExpress.XtraBars.BarStaticItem();
            this.btnHakkinda = new DevExpress.XtraBars.BarButtonItem();
            this.btnLisans = new DevExpress.XtraBars.BarButtonItem();
            this.RaporGelmeyenPolicelerim = new DevExpress.XtraBars.BarButtonItem();
            this.RaporSüresindeYenilenmemis = new DevExpress.XtraBars.BarButtonItem();
            this.RaporAktifPolicelerim = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnSigortacilar,
            this.btnMusteriler,
            this.btnAktifPoliceler,
            this.BsiInfo,
            this.btnGenelAyarlar,
            this.btnPasifPoliceler,
            this.btnGelmeyenPoliceler,
            this.barButtonItem1,
            this.btnDatabaseAyar,
            this.barTextSaat,
            this.btnHakkinda,
            this.btnLisans,
            this.RaporGelmeyenPolicelerim,
            this.RaporSüresindeYenilenmemis,
            this.RaporAktifPolicelerim});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 16;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(865, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSigortacilar
            // 
            this.btnSigortacilar.Caption = "Sigorta Firmaları";
            this.btnSigortacilar.Id = 1;
            this.btnSigortacilar.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.Assessors;
            this.btnSigortacilar.Name = "btnSigortacilar";
            this.btnSigortacilar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSigortacilar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSigortacilar_ItemClick);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Caption = "Poliçe Sahipleri";
            this.btnMusteriler.Id = 2;
            this.btnMusteriler.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.contacts_48x48;
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnMusteriler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMusteriler_ItemClick);
            // 
            // btnAktifPoliceler
            // 
            this.btnAktifPoliceler.Caption = "Aktif Poliçeler";
            this.btnAktifPoliceler.Id = 3;
            this.btnAktifPoliceler.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.property;
            this.btnAktifPoliceler.Name = "btnAktifPoliceler";
            this.btnAktifPoliceler.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnAktifPoliceler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAktifPoliceler_ItemClick);
            // 
            // BsiInfo
            // 
            this.BsiInfo.Caption = "barStaticItem1";
            this.BsiInfo.Id = 4;
            this.BsiInfo.Name = "BsiInfo";
            // 
            // btnGenelAyarlar
            // 
            this.btnGenelAyarlar.Caption = "Genel Ayarlar";
            this.btnGenelAyarlar.Id = 5;
            this.btnGenelAyarlar.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.setting_48x48;
            this.btnGenelAyarlar.Name = "btnGenelAyarlar";
            this.btnGenelAyarlar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGenelAyarlar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnGenelAyarlar_ItemClick);
            // 
            // btnPasifPoliceler
            // 
            this.btnPasifPoliceler.Caption = "Pasif Poliçelerim";
            this.btnPasifPoliceler.Id = 6;
            this.btnPasifPoliceler.ImageOptions.Image = global::Policem.UI.Properties.Resources.ErrorMsg;
            this.btnPasifPoliceler.Name = "btnPasifPoliceler";
            this.btnPasifPoliceler.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPasifPoliceler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPasifPoliceler_ItemClick);
            // 
            // btnGelmeyenPoliceler
            // 
            this.btnGelmeyenPoliceler.Caption = "Gelmeyen Poliçeler";
            this.btnGelmeyenPoliceler.Id = 7;
            this.btnGelmeyenPoliceler.ImageOptions.Image = global::Policem.UI.Properties.Resources.EMail_48x48;
            this.btnGelmeyenPoliceler.Name = "btnGelmeyenPoliceler";
            this.btnGelmeyenPoliceler.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnGelmeyenPoliceler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGelmeyenPoliceler_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnDatabaseAyar
            // 
            this.btnDatabaseAyar.Caption = "Data Ayarları";
            this.btnDatabaseAyar.Id = 9;
            this.btnDatabaseAyar.ImageOptions.Image = global::Policem.UI.Properties.Resources.Database;
            this.btnDatabaseAyar.Name = "btnDatabaseAyar";
            this.btnDatabaseAyar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDatabaseAyar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDatabaseAyar_ItemClick);
            // 
            // barTextSaat
            // 
            this.barTextSaat.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barTextSaat.Caption = "Saat";
            this.barTextSaat.Id = 10;
            this.barTextSaat.Name = "barTextSaat";
            // 
            // btnHakkinda
            // 
            this.btnHakkinda.Caption = "Hakkında";
            this.btnHakkinda.Id = 11;
            this.btnHakkinda.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.help_32x32;
            this.btnHakkinda.Name = "btnHakkinda";
            this.btnHakkinda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHakkinda_ItemClick);
            // 
            // btnLisans
            // 
            this.btnLisans.Caption = "Lisans";
            this.btnLisans.Id = 12;
            this.btnLisans.Name = "btnLisans";
            this.btnLisans.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLisans_ItemClick);
            // 
            // RaporGelmeyenPolicelerim
            // 
            this.RaporGelmeyenPolicelerim.Caption = "Gelmeyen Poliçelerim";
            this.RaporGelmeyenPolicelerim.Id = 13;
            this.RaporGelmeyenPolicelerim.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.today_32x32;
            this.RaporGelmeyenPolicelerim.Name = "RaporGelmeyenPolicelerim";
            this.RaporGelmeyenPolicelerim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RaporGelmeyenPolicelerim_ItemClick);
            // 
            // RaporSüresindeYenilenmemis
            // 
            this.RaporSüresindeYenilenmemis.Caption = "Süresinde Yenilenmemiş Poliçelerim";
            this.RaporSüresindeYenilenmemis.Id = 14;
            this.RaporSüresindeYenilenmemis.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.Permissions;
            this.RaporSüresindeYenilenmemis.Name = "RaporSüresindeYenilenmemis";
            this.RaporSüresindeYenilenmemis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RaporSüresindeYenilenmemis_ItemClick);
            // 
            // RaporAktifPolicelerim
            // 
            this.RaporAktifPolicelerim.Caption = "Aktif Poliçelerim";
            this.RaporAktifPolicelerim.Id = 15;
            this.RaporAktifPolicelerim.ImageOptions.LargeImage = global::Policem.UI.Properties.Resources.Transfer_48x48;
            this.RaporAktifPolicelerim.Name = "RaporAktifPolicelerim";
            this.RaporAktifPolicelerim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RaporAktifPolicelerim_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "İşlemler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSigortacilar);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMusteriler);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tanımlar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnAktifPoliceler);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPasifPoliceler);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnGelmeyenPoliceler);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "İşlemler";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Raporlar";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.RaporGelmeyenPolicelerim);
            this.ribbonPageGroup3.ItemLinks.Add(this.RaporSüresindeYenilenmemis);
            this.ribbonPageGroup3.ItemLinks.Add(this.RaporAktifPolicelerim);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Raporlar";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Ayarlar";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnGenelAyarlar);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDatabaseAyar);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Sistem";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnHakkinda);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnLisans);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Yardım";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.BsiInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barTextSaat);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 535);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(865, 31);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // RibbonMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 566);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "RibbonMainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Poliçe Takip Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RibbonMainForm_FormClosing);
            this.Load += new System.EventHandler(this.RibbonMainForm_Load);
            this.Shown += new System.EventHandler(this.RibbonMainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnSigortacilar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnMusteriler;
        private DevExpress.XtraBars.BarButtonItem btnAktifPoliceler;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem BsiInfo;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.BarButtonItem btnGenelAyarlar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnPasifPoliceler;
        private DevExpress.XtraBars.BarButtonItem btnGelmeyenPoliceler;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnDatabaseAyar;
        private DevExpress.XtraBars.BarStaticItem barTextSaat;
        private DevExpress.XtraBars.BarButtonItem btnHakkinda;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnLisans;
        private DevExpress.XtraBars.BarButtonItem RaporGelmeyenPolicelerim;
        private DevExpress.XtraBars.BarButtonItem RaporSüresindeYenilenmemis;
        private DevExpress.XtraBars.BarButtonItem RaporAktifPolicelerim;
    }
}