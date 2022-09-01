using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using Microsoft.VisualBasic.ApplicationServices;
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
            //new AppSession();
            //setting dosyasından oku
            AppSession.PrgSettingsOrg = new PrgSettings();
            AppSession.PrgSettingsOrg.ZorunluAlanRengi = Settings.Default.Zorunlu;
            AppSession.PrgSettingsOrg.AktifAlanRengi = Settings.Default.Aktif;
            AppSession.PrgSettingsOrg.SkinName = Settings.Default.SkinName;
            AppSession.PrgSettingsOrg.EnableAppearanceEvenRow = Settings.Default.Ardisil;
            AppSession.PrgSettingsOrg.OutlookMailAdresi = Settings.Default.OutlookMailAdres;
            AppSession.PrgSettingsOrg.MuayeneTakvimHatirlatici = Settings.Default.MuayeneTakvimHatirlatici;
            AppSession.Settings = new PrgSettings();
            AppSession.Settings.ZorunluAlanRengi = Settings.Default.Zorunlu;
            AppSession.Settings.AktifAlanRengi = Settings.Default.Aktif;
            AppSession.Settings.SkinName = Settings.Default.SkinName;
            AppSession.Settings.EnableAppearanceEvenRow = Settings.Default.Ardisil;
            AppSession.Settings.OutlookMailAdresi = Settings.Default.OutlookMailAdres;
            AppSession.Settings.MuayeneTakvimHatirlatici = Settings.Default.MuayeneTakvimHatirlatici;
            UserLookAndFeel.Default.SetSkinStyle(AppSession.Settings.SkinName);
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
    }
}