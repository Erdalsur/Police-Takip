using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using Policem.Core.Core.Aktivasyon;
using Policem.Services.DependencyResolution;
using Policem.UI.Forms;
using Policem.UI.Properties;

namespace Policem.UI
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            this.IsSingleInstance = true;
            this.StartupNextInstance += new StartupNextInstanceEventHandler(this.This_StartupNextInstance);
        }

        public void This_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
        }

        protected override void OnCreateMainForm()
        {
            new AppSession();
            LisansKontrol();
            //setting dosyasından oku
            try
            {
                var dosya = Application.StartupPath.ToString() + "\\Settings.xml";
                //xml dosyayı oku string olarak gönder
                if (File.Exists(dosya) == true)
                {
                    var xmlDosya = System.IO.File.ReadAllText(dosya);
                    AppSession.PrgSettingsOrg = PrgSettings.LoadSettings(xmlDosya);
                    AppSession.Settings = AppSession.PrgSettingsOrg;
                }
                else
                {
                    AppSession.PrgSettingsOrg = new PrgSettings();
                    AppSession.PrgSettingsOrg.ZorunluAlanRengi = Settings.Default.Zorunlu;
                    AppSession.PrgSettingsOrg.AktifAlanRengi = Settings.Default.Aktif;
                    AppSession.PrgSettingsOrg.SkinName = Settings.Default.SkinName;
                    AppSession.PrgSettingsOrg.EnableAppearanceEvenRow = Settings.Default.Ardisil;
                    AppSession.PrgSettingsOrg.OutlookMailAdresi = Settings.Default.OutlookMailAdres;
                    AppSession.PrgSettingsOrg.MuayeneTakvimHatirlatici = Settings.Default.MuayeneTakvimHatirlatici;
                    AppSession.Settings = AppSession.PrgSettingsOrg;
                    UserLookAndFeel.Default.SetSkinStyle(AppSession.Settings.SkinName);
                }

            }
            catch { MessageBox.Show("İlk Session Oluşturma Hatası"); }
            //using (Login login = new Login())
            {
                //if (login.ShowDialog() == DialogResult.OK)
                {
                    AppSession.LaunchingTime = DateTime.Now;
                    SplashScreenManager.ShowForm(typeof(SplashScreen1));
                    AppSession.MainForm = new RibbonMainForm
                    {
                        ShowInTaskbar = true,
                        WindowState = FormWindowState.Minimized
                    };
                    this.MainForm = (Form)AppSession.MainForm;
                }
                //else
                //{
                //    Form form = new Form();
                //    this.MainForm = form;
                //    form.Close();
                //}
            }
        }

        public void LisansKontrol()
        {
            try
            {
                System.Reflection.AssemblyProductAttribute assemblyProduct = (System.Reflection.AssemblyProductAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(System.Reflection.AssemblyProductAttribute));
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                AppSession.Lisansim = new Lisansim();
                AppSession.Lisansim.AktivasyonKodu = LisanslamaSistemi.LisansSeriUretimi();
                AppSession.Lisansim.Adi = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterUser", null).ToString();
                AppSession.Lisansim.Firma = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "RegisterCompany", null).ToString();
                AppSession.Lisansim.Email = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "Email", null).ToString();
                AppSession.Lisansim.SerialNumber = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "Key", null).ToString();
                AppSession.Lisansim.YüklenenTarih = Convert.ToDateTime(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\ErSu\" + fvi.ProductName, "Key", null).ToString());
                AppSession.Lisansim.LisansDurum = LisanslamaSistemi.LisansKontrol(AppSession.Lisansim.AktivasyonKodu, AppSession.Lisansim.SerialNumber);
            }
            catch { }
        }
    }

    public class Lisansim
    {
        public string AktivasyonKodu { get; set; }
        public string SerialNumber { get; set; }
        public string Adi { get; set; }
        public string Firma { get; set; }
        public string Email { get; set; }
        public bool LisansDurum { get; set; }
        public DateTime YüklenenTarih { get; set; }

    }
}