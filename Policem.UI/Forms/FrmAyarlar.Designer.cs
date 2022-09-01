namespace Policem.UI.Forms
{
    partial class FrmAyarlar
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
            this.nb = new DevExpress.XtraNavBar.NavBarControl();
            this.miGeneral = new DevExpress.XtraNavBar.NavBarGroup();
            this.miMail = new DevExpress.XtraNavBar.NavBarGroup();
            this.miUI = new DevExpress.XtraNavBar.NavBarGroup();
            this.miTema = new DevExpress.XtraNavBar.NavBarGroup();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnIptal = new DevExpress.XtraBars.BarButtonItem();
            this.btnKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tcSettingPages = new DevExpress.XtraTab.XtraTabControl();
            this.tpGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.txtMuyaneHatirlaticiSayisi = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtMailAdresi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnAktifTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnAktifYap = new DevExpress.XtraEditors.SimpleButton();
            this.chkEnableEvenRow = new DevExpress.XtraEditors.CheckEdit();
            this.tpUI = new DevExpress.XtraTab.XtraTabPage();
            this.colorPickEditZorunlu = new DevExpress.XtraEditors.ColorPickEdit();
            this.chkAllowFormGlass = new DevExpress.XtraEditors.CheckEdit();
            this.colorAktifEdit = new DevExpress.XtraEditors.ColorEdit();
            this.colorEditZorunlu = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPopupFilterMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbEditorShowMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tpTema = new DevExpress.XtraTab.XtraTabPage();
            this.rgbiSkins = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.tpMail = new DevExpress.XtraTab.XtraTabPage();
            this.txtMailSSL = new DevExpress.XtraEditors.ToggleSwitch();
            this.txtMailPort = new DevExpress.XtraEditors.SpinEdit();
            this.txtMailKullanici = new DevExpress.XtraEditors.TextEdit();
            this.txtMailAdresler = new DevExpress.XtraEditors.TextEdit();
            this.txtMailSifre = new DevExpress.XtraEditors.TextEdit();
            this.txtMailHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcSettingPages)).BeginInit();
            this.tcSettingPages.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMuyaneHatirlaticiSayisi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAdresi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableEvenRow.Properties)).BeginInit();
            this.tpUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditZorunlu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowFormGlass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorAktifEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditZorunlu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPopupFilterMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditorShowMode.Properties)).BeginInit();
            this.tpTema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgbiSkins)).BeginInit();
            this.rgbiSkins.SuspendLayout();
            this.tpMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSSL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailKullanici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAdresler.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailHost.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // nb
            // 
            this.nb.ActiveGroup = this.miGeneral;
            this.nb.Dock = System.Windows.Forms.DockStyle.Left;
            this.nb.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.miGeneral,
            this.miMail,
            this.miUI,
            this.miTema});
            this.nb.Location = new System.Drawing.Point(0, 29);
            this.nb.Name = "nb";
            this.nb.OptionsNavPane.ExpandedWidth = 145;
            this.nb.OptionsNavPane.ShowExpandButton = false;
            this.nb.OptionsNavPane.ShowOverflowPanel = false;
            this.nb.Size = new System.Drawing.Size(145, 416);
            this.nb.TabIndex = 12;
            this.nb.Text = "navBarControl1";
            this.nb.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Dark Style");
            this.nb.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbSettings_ActiveGroupChanged);
            // 
            // miGeneral
            // 
            this.miGeneral.Caption = "Genel Ayarlar";
            this.miGeneral.Expanded = true;
            this.miGeneral.Name = "miGeneral";
            // 
            // miMail
            // 
            this.miMail.Caption = "Mail Ayarları";
            this.miMail.Name = "miMail";
            // 
            // miUI
            // 
            this.miUI.Caption = "Kullanıcı Arabirimi";
            this.miUI.Name = "miUI";
            // 
            // miTema
            // 
            this.miTema.Caption = "Temalar";
            this.miTema.Name = "miTema";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnIptal,
            this.btnKaydet});
            this.barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnIptal),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKaydet)});
            this.bar1.Text = "Tools";
            // 
            // btnIptal
            // 
            this.btnIptal.Caption = "İptal";
            this.btnIptal.Id = 0;
            this.btnIptal.Name = "btnIptal";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Caption = "Kaydet";
            this.btnKaydet.Id = 1;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnKaydet_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(551, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 445);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(551, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 416);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(551, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 416);
            // 
            // tcSettingPages
            // 
            this.tcSettingPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettingPages.Location = new System.Drawing.Point(145, 29);
            this.tcSettingPages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcSettingPages.Name = "tcSettingPages";
            this.tcSettingPages.SelectedTabPage = this.tpGeneral;
            this.tcSettingPages.Size = new System.Drawing.Size(406, 416);
            this.tcSettingPages.TabIndex = 14;
            this.tcSettingPages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpUI,
            this.tpGeneral,
            this.tpTema,
            this.tpMail});
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.txtMuyaneHatirlaticiSayisi);
            this.tpGeneral.Controls.Add(this.labelControl4);
            this.tpGeneral.Controls.Add(this.txtMailAdresi);
            this.tpGeneral.Controls.Add(this.labelControl3);
            this.tpGeneral.Controls.Add(this.btnAktifTemizle);
            this.tpGeneral.Controls.Add(this.btnAktifYap);
            this.tpGeneral.Controls.Add(this.chkEnableEvenRow);
            this.tpGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(400, 388);
            this.tpGeneral.Text = "General";
            // 
            // txtMuyaneHatirlaticiSayisi
            // 
            this.txtMuyaneHatirlaticiSayisi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMuyaneHatirlaticiSayisi.Location = new System.Drawing.Point(191, 59);
            this.txtMuyaneHatirlaticiSayisi.MenuManager = this.barManager1;
            this.txtMuyaneHatirlaticiSayisi.Name = "txtMuyaneHatirlaticiSayisi";
            this.txtMuyaneHatirlaticiSayisi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMuyaneHatirlaticiSayisi.Properties.IsFloatValue = false;
            this.txtMuyaneHatirlaticiSayisi.Properties.Mask.EditMask = "N00";
            this.txtMuyaneHatirlaticiSayisi.Size = new System.Drawing.Size(100, 20);
            this.txtMuyaneHatirlaticiSayisi.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 62);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(169, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Muayene Kaç Gün Önce Hatırlatılsın";
            // 
            // txtMailAdresi
            // 
            this.txtMailAdresi.Location = new System.Drawing.Point(149, 33);
            this.txtMailAdresi.MenuManager = this.barManager1;
            this.txtMailAdresi.Name = "txtMailAdresi";
            this.txtMailAdresi.Size = new System.Drawing.Size(226, 20);
            this.txtMailAdresi.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 36);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(127, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Outlook Takvim Mail Adresi";
            // 
            // btnAktifTemizle
            // 
            this.btnAktifTemizle.Location = new System.Drawing.Point(282, 185);
            this.btnAktifTemizle.Name = "btnAktifTemizle";
            this.btnAktifTemizle.Size = new System.Drawing.Size(72, 23);
            this.btnAktifTemizle.TabIndex = 2;
            this.btnAktifTemizle.Text = "Temizle";
            this.btnAktifTemizle.Visible = false;
            // 
            // btnAktifYap
            // 
            this.btnAktifYap.Location = new System.Drawing.Point(28, 185);
            this.btnAktifYap.Name = "btnAktifYap";
            this.btnAktifYap.Size = new System.Drawing.Size(248, 23);
            this.btnAktifYap.TabIndex = 2;
            this.btnAktifYap.Text = "Şu anki Ribbon\'ı açılışta otomatik getir";
            this.btnAktifYap.Visible = false;
            // 
            // chkEnableEvenRow
            // 
            this.chkEnableEvenRow.Location = new System.Drawing.Point(16, 11);
            this.chkEnableEvenRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEnableEvenRow.Name = "chkEnableEvenRow";
            this.chkEnableEvenRow.Properties.Caption = "Ardışıl satırlar farklı renklendirilsin";
            this.chkEnableEvenRow.Size = new System.Drawing.Size(196, 19);
            this.chkEnableEvenRow.TabIndex = 1;
            // 
            // tpUI
            // 
            this.tpUI.Controls.Add(this.colorPickEditZorunlu);
            this.tpUI.Controls.Add(this.chkAllowFormGlass);
            this.tpUI.Controls.Add(this.colorAktifEdit);
            this.tpUI.Controls.Add(this.colorEditZorunlu);
            this.tpUI.Controls.Add(this.labelControl10);
            this.tpUI.Controls.Add(this.labelControl7);
            this.tpUI.Controls.Add(this.labelControl2);
            this.tpUI.Controls.Add(this.labelControl1);
            this.tpUI.Controls.Add(this.cmbPopupFilterMode);
            this.tpUI.Controls.Add(this.cmbEditorShowMode);
            this.tpUI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpUI.Name = "tpUI";
            this.tpUI.Size = new System.Drawing.Size(400, 388);
            this.tpUI.Text = "UI";
            // 
            // colorPickEditZorunlu
            // 
            this.colorPickEditZorunlu.EditValue = System.Drawing.Color.Empty;
            this.colorPickEditZorunlu.Location = new System.Drawing.Point(164, 8);
            this.colorPickEditZorunlu.Name = "colorPickEditZorunlu";
            this.colorPickEditZorunlu.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.colorPickEditZorunlu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorPickEditZorunlu.Size = new System.Drawing.Size(106, 20);
            this.colorPickEditZorunlu.TabIndex = 34;
            // 
            // chkAllowFormGlass
            // 
            this.chkAllowFormGlass.Location = new System.Drawing.Point(150, 295);
            this.chkAllowFormGlass.Name = "chkAllowFormGlass";
            this.chkAllowFormGlass.Properties.Caption = "AllowFormGlass (W7)";
            this.chkAllowFormGlass.Size = new System.Drawing.Size(125, 19);
            this.chkAllowFormGlass.TabIndex = 33;
            this.chkAllowFormGlass.Visible = false;
            // 
            // colorAktifEdit
            // 
            this.colorAktifEdit.EditValue = System.Drawing.Color.Empty;
            this.colorAktifEdit.Location = new System.Drawing.Point(164, 33);
            this.colorAktifEdit.Name = "colorAktifEdit";
            this.colorAktifEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorAktifEdit.Size = new System.Drawing.Size(106, 20);
            this.colorAktifEdit.TabIndex = 31;
            // 
            // colorEditZorunlu
            // 
            this.colorEditZorunlu.EditValue = System.Drawing.Color.Empty;
            this.colorEditZorunlu.Location = new System.Drawing.Point(274, 3);
            this.colorEditZorunlu.Name = "colorEditZorunlu";
            this.colorEditZorunlu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEditZorunlu.Size = new System.Drawing.Size(106, 20);
            this.colorEditZorunlu.TabIndex = 31;
            this.colorEditZorunlu.Visible = false;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(77, 36);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(77, 13);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "Aktif Text Rengi";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(68, 10);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(86, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Zorunlu alan rengi";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(60, 271);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Popup Filtre Modu";
            this.labelControl2.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(68, 247);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Editör Açılış Şekli";
            this.labelControl1.Visible = false;
            // 
            // cmbPopupFilterMode
            // 
            this.cmbPopupFilterMode.Location = new System.Drawing.Point(152, 268);
            this.cmbPopupFilterMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPopupFilterMode.Name = "cmbPopupFilterMode";
            this.cmbPopupFilterMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPopupFilterMode.Size = new System.Drawing.Size(106, 20);
            this.cmbPopupFilterMode.TabIndex = 1;
            this.cmbPopupFilterMode.Visible = false;
            // 
            // cmbEditorShowMode
            // 
            this.cmbEditorShowMode.Location = new System.Drawing.Point(152, 245);
            this.cmbEditorShowMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEditorShowMode.Name = "cmbEditorShowMode";
            this.cmbEditorShowMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEditorShowMode.Size = new System.Drawing.Size(106, 20);
            this.cmbEditorShowMode.TabIndex = 0;
            this.cmbEditorShowMode.Visible = false;
            // 
            // tpTema
            // 
            this.tpTema.Controls.Add(this.rgbiSkins);
            this.tpTema.Name = "tpTema";
            this.tpTema.Size = new System.Drawing.Size(400, 388);
            this.tpTema.Text = "Tema";
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Controls.Add(this.galleryControlClient1);
            this.rgbiSkins.DesignGalleryGroupIndex = 0;
            this.rgbiSkins.DesignGalleryItemIndex = 0;
            this.rgbiSkins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgbiSkins.Location = new System.Drawing.Point(0, 0);
            this.rgbiSkins.Name = "rgbiSkins";
            this.rgbiSkins.Size = new System.Drawing.Size(400, 388);
            this.rgbiSkins.TabIndex = 35;
            this.rgbiSkins.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.rgbiSkins;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(379, 384);
            // 
            // tpMail
            // 
            this.tpMail.Controls.Add(this.txtMailSSL);
            this.tpMail.Controls.Add(this.txtMailPort);
            this.tpMail.Controls.Add(this.txtMailKullanici);
            this.tpMail.Controls.Add(this.txtMailAdresler);
            this.tpMail.Controls.Add(this.txtMailSifre);
            this.tpMail.Controls.Add(this.txtMailHost);
            this.tpMail.Controls.Add(this.labelControl12);
            this.tpMail.Controls.Add(this.labelControl11);
            this.tpMail.Controls.Add(this.labelControl9);
            this.tpMail.Controls.Add(this.labelControl8);
            this.tpMail.Controls.Add(this.labelControl6);
            this.tpMail.Controls.Add(this.labelControl5);
            this.tpMail.Name = "tpMail";
            this.tpMail.Size = new System.Drawing.Size(400, 388);
            this.tpMail.Text = "Mail Ayarları";
            // 
            // txtMailSSL
            // 
            this.txtMailSSL.Location = new System.Drawing.Point(122, 60);
            this.txtMailSSL.MenuManager = this.barManager1;
            this.txtMailSSL.Name = "txtMailSSL";
            this.txtMailSSL.Properties.OffText = "Off";
            this.txtMailSSL.Properties.OnText = "On";
            this.txtMailSSL.Size = new System.Drawing.Size(95, 24);
            this.txtMailSSL.TabIndex = 3;
            // 
            // txtMailPort
            // 
            this.txtMailPort.EditValue = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.txtMailPort.Location = new System.Drawing.Point(122, 37);
            this.txtMailPort.MenuManager = this.barManager1;
            this.txtMailPort.Name = "txtMailPort";
            this.txtMailPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMailPort.Properties.IsFloatValue = false;
            this.txtMailPort.Properties.Mask.EditMask = "N00";
            this.txtMailPort.Size = new System.Drawing.Size(100, 20);
            this.txtMailPort.TabIndex = 2;
            // 
            // txtMailKullanici
            // 
            this.txtMailKullanici.Location = new System.Drawing.Point(122, 87);
            this.txtMailKullanici.Name = "txtMailKullanici";
            this.txtMailKullanici.Size = new System.Drawing.Size(182, 20);
            this.txtMailKullanici.TabIndex = 1;
            // 
            // txtMailAdresler
            // 
            this.txtMailAdresler.Location = new System.Drawing.Point(122, 139);
            this.txtMailAdresler.Name = "txtMailAdresler";
            this.txtMailAdresler.Size = new System.Drawing.Size(182, 20);
            this.txtMailAdresler.TabIndex = 1;
            // 
            // txtMailSifre
            // 
            this.txtMailSifre.Location = new System.Drawing.Point(122, 113);
            this.txtMailSifre.Name = "txtMailSifre";
            this.txtMailSifre.Properties.PasswordChar = 'X';
            this.txtMailSifre.Size = new System.Drawing.Size(182, 20);
            this.txtMailSifre.TabIndex = 1;
            // 
            // txtMailHost
            // 
            this.txtMailHost.Location = new System.Drawing.Point(122, 11);
            this.txtMailHost.MenuManager = this.barManager1;
            this.txtMailHost.Name = "txtMailHost";
            this.txtMailHost.Size = new System.Drawing.Size(182, 20);
            this.txtMailHost.TabIndex = 1;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(38, 116);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(69, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Kullanıcı Şifresi";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(52, 90);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(55, 13);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Kullanıcı Adı";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(90, 65);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(17, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "SSL";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(31, 40);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(76, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Mail Server Port";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(54, 14);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Mail Server";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(5, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(102, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Rapor Atılacak Mailler";
            // 
            // FrmAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 445);
            this.Controls.Add(this.tcSettingPages);
            this.Controls.Add(this.nb);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmAyarlar";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.FrmAyarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcSettingPages)).EndInit();
            this.tcSettingPages.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMuyaneHatirlaticiSayisi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAdresi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnableEvenRow.Properties)).EndInit();
            this.tpUI.ResumeLayout(false);
            this.tpUI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorPickEditZorunlu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllowFormGlass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorAktifEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditZorunlu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPopupFilterMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditorShowMode.Properties)).EndInit();
            this.tpTema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgbiSkins)).EndInit();
            this.rgbiSkins.ResumeLayout(false);
            this.tpMail.ResumeLayout(false);
            this.tpMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSSL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailKullanici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailAdresler.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailHost.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl nb;
        private DevExpress.XtraNavBar.NavBarGroup miUI;
        private DevExpress.XtraNavBar.NavBarGroup miGeneral;
        private DevExpress.XtraNavBar.NavBarGroup miTema;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl tcSettingPages;
        private DevExpress.XtraTab.XtraTabPage tpUI;
        private DevExpress.XtraEditors.ColorPickEdit colorPickEditZorunlu;
        private DevExpress.XtraEditors.CheckEdit chkAllowFormGlass;
        private DevExpress.XtraEditors.ColorEdit colorAktifEdit;
        private DevExpress.XtraEditors.ColorEdit colorEditZorunlu;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPopupFilterMode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEditorShowMode;
        private DevExpress.XtraTab.XtraTabPage tpGeneral;
        private DevExpress.XtraEditors.SimpleButton btnAktifTemizle;
        private DevExpress.XtraEditors.SimpleButton btnAktifYap;
        private DevExpress.XtraEditors.CheckEdit chkEnableEvenRow;
        private DevExpress.XtraTab.XtraTabPage tpTema;
        private DevExpress.XtraBars.Ribbon.GalleryControl rgbiSkins;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraBars.BarButtonItem btnIptal;
        private DevExpress.XtraBars.BarButtonItem btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtMailAdresi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit txtMuyaneHatirlaticiSayisi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraNavBar.NavBarGroup miMail;
        private DevExpress.XtraTab.XtraTabPage tpMail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ToggleSwitch txtMailSSL;
        private DevExpress.XtraEditors.SpinEdit txtMailPort;
        private DevExpress.XtraEditors.TextEdit txtMailKullanici;
        private DevExpress.XtraEditors.TextEdit txtMailAdresler;
        private DevExpress.XtraEditors.TextEdit txtMailSifre;
        private DevExpress.XtraEditors.TextEdit txtMailHost;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}