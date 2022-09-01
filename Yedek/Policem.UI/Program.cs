using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraSplashScreen;
using Policem.Core.DependencyResolution;

namespace Policem.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CompositionRoot.Wire(new BusinessModule());

            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            //BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //#if DEBUG
            //            DataBase.SetInitializer(new Init());
            //#endif
            //Application.Run(new MainForm());
            
            CompositionRoot.Resolve<Session2>();
            Application.Run(CompositionRoot.Resolve<MainForm>());
        }
    }
}
