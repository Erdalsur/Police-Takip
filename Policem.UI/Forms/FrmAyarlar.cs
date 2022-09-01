using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars.Helpers;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms.Base;
using Policem.UI.Properties;
using Policem.Core.Utility;

namespace Policem.UI.Forms
{
    public partial class FrmAyarlar : XPopupForm
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            nb.PaintStyleName = "SkinNavigationPane";
            tcSettingPages.ShowTabHeader = DefaultBoolean.False;
            btnKaydet.ItemClick += BtnKaydet_ItemClick;
            btnIptal.ItemClick += BtnIptal_ItemClick;
            chkEnableEvenRow.Checked = AppSession.Settings.EnableAppearanceEvenRow;
            colorPickEditZorunlu.EditValue = AppSession.Settings.ZorunluAlanRengi;
            colorAktifEdit.EditValue = AppSession.Settings.AktifAlanRengi;
            txtMailAdresi.EditValue = AppSession.Settings.OutlookMailAdresi;
            txtMuyaneHatirlaticiSayisi.EditValue = AppSession.Settings.MuayeneTakvimHatirlatici;
            List<string> bonusskins = new List<string>(new[]{
                                                                //"DevExpress Style",
                                                                //"DevExpress Dark Style",
                                                                //"Seven Classic",
                                                                //"Office 2010 Blue",
                                                                //"Office 2010 Black",
                                                                //"Office 2010 Silver",
                                                                //"Office 2013",
                                                                //"Office 2013 Dark Gray",
                                                                //"Office 2013 Light Gray",
                                                                //"Visual Studio 2013 Blue",
                                                                //"Visual Studio 2013 Light",
                                                                //"Visual Studio 2013 Dark",
                                                                //"Xmas 2008 Blue",
                                                                //"Valentine",
                                                                //"McSkin",
                                                                //"Summer 2008",
                                                                //"Pumpkin",
                                                                //"Springtime",
                                                                //"Whiteprint",
                                                                //"Blueprint"
                                                                "VS2010",
                                                                "Coffee",
                                                                "Liquid Sky",
                                                                "London Liquid Sky",
                                                                "Glass Oceans",
                                                                "Stardust",
                                                                "Dark Side",
                                                                "Foggy",
                                                                "High Contrast",
                                                                "Seven",
                                                                "Sharp",
                                                                "Sharp Plus",
                                                                "The Asphalt World",
                                                                "Caramel",
                                                                "Money Twins",
                                                                "Lilian",
                                                                "iMaginary",
                                                                "Black",
                                                                "Office 2007 Blue",
                                                                "Office 2007 Black",
                                                                "Office 2007 Silver",
                                                                "Office 2007 Green",
                                                                "Office 2007 Pink",
                                                                "Blue",
                                                                "Darkroom",
                                                                "Metropolis Dark",
                                                                "Metropolis"
                                                                            });

            for (int i = DevExpress.Skins.SkinManager.Default.Skins.Count - 1; i > 0; i--)
            {
                if (bonusskins.Contains(DevExpress.Skins.SkinManager.Default.Skins[i].SkinName))
                    DevExpress.Skins.SkinManager.Default.Skins.RemoveAt(i);
            }
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(rgbiSkins);

            SkinHelper.InitSkinGallery(rgbiSkins, true, false);

            btnAktifYap.Click += new EventHandler(btnAktifYap_Click);
            btnAktifTemizle.Click += new EventHandler(btnAktifTemizle_Click);
            txtMailHost.Text=IniIslemleri.VeriOku("MailSetting", "Host");
            txtMailPort.Text=IniIslemleri.VeriOku("MailSetting", "Port");
            var ssl=IniIslemleri.VeriOku("MailSetting", "SSL");
            if (ssl == "True")
                txtMailSSL.IsOn = true;
            else
                txtMailSSL.IsOn = false;
            txtMailKullanici.Text=IniIslemleri.VeriOku("MailSetting", "Kullanici");
            var sifre=IniIslemleri.VeriOku("MailSetting", "Password");
            txtMailSifre.Text = CryptoManager.SifreCoz(sifre);

            txtMailAdresler.Text=IniIslemleri.VeriOku("Guvercin", "Adres");
        }

        void btnAktifTemizle_Click(object sender, EventArgs e)
        {
            //StartupRibbonPage = null;
            btnKaydet.PerformClick();
        }

        void btnAktifYap_Click(object sender, EventArgs e)
        {
            string MRUform = string.Empty;
            if (AppSession.MainForm.ActiveMdiChild != null)
            {
                XForm activeChild = AppSession.MainForm.ActiveMdiChild as XForm;
                MRUform = activeChild.ToString().Split(',')[0];
            }

            //StartupRibbonPage = AppSession.MainForm.Ribbon.SelectedPage.Text;
            btnKaydet.PerformClick();
        }

        private void BtnIptal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnKaydet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Settings.Default.Ardisil = chkEnableEvenRow.Checked;
            Settings.Default.Aktif= ((Color)colorAktifEdit.EditValue).Name;
            Settings.Default.Zorunlu = ((Color)colorPickEditZorunlu.EditValue).Name;
            Settings.Default.SkinName = DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveSkinName;   // SkinName;
            Settings.Default.OutlookMailAdres = txtMailAdresi.EditValue.ToString();
            Settings.Default.MuayeneTakvimHatirlatici = Convert.ToInt32(txtMuyaneHatirlaticiSayisi.EditValue);
            //AppSession.Settings.AllowFormGlass = chkAllowFormGlass.Checked ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

            AppSession.Settings.EnableAppearanceEvenRow = chkEnableEvenRow.Checked;
            AppSession.Settings.ZorunluAlanRengi = ((Color)this.colorPickEditZorunlu.EditValue).Name;
            AppSession.Settings.AktifAlanRengi = ((Color)this.colorAktifEdit.EditValue).Name;
            AppSession.Settings.SkinName = UserLookAndFeel.Default.SkinName;
            AppSession.Settings.OutlookMailAdresi = txtMailAdresi.EditValue.ToString();
            AppSession.Settings.MuayeneTakvimHatirlatici = Convert.ToInt32(txtMuyaneHatirlaticiSayisi.EditValue);
            AppSession.Settings.Save();
                        
            
            Settings.Default.Save();
            Settings.Default.Upgrade();
            IniIslemleri.VeriYaz("MailSetting", "Host", txtMailHost.EditValue.ToString().Trim());
            IniIslemleri.VeriYaz("MailSetting", "Port", txtMailPort.EditValue.ToString());
            //var ssl=
            IniIslemleri.VeriYaz("MailSetting", "SSL", txtMailSSL.EditValue.ToString());
            IniIslemleri.VeriYaz("MailSetting", "Kullanici", txtMailKullanici.EditValue.ToString().Trim());
            var sifre = txtMailSifre.EditValue.ToString().Trim();
            IniIslemleri.VeriYaz("MailSetting", "Password", CryptoManager.Sifrele(sifre));

            IniIslemleri.VeriYaz("Guvercin", "Adres", txtMailAdresler.EditValue.ToString().Trim());
            
            AppSession.MainForm.NotifyMain("Ayarlar Değiştirildi...");
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void nbSettings_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            switch (nb.ActiveGroup.Name)
            {
                case "miUI": tcSettingPages.SelectedTabPage = tpUI; break;
                case "miTema": tcSettingPages.SelectedTabPage = tpTema; break;
                case "miGeneral": tcSettingPages.SelectedTabPage = tpGeneral; break;
                case "miMail": tcSettingPages.SelectedTabPage = tpMail; break;
            }
        }
    }
}
