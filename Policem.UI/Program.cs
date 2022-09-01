using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Policem.UI.DependencyResolution;
using Policem.UI.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraSplashScreen;
using Policem.Core.Business.DependencyResolvers.Ninject;
using FluentValidation.Mvc;
using System.Web.Mvc;
using DevExpress.UserSkins;
using System.Configuration;
using Policem.Core.Utility;

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
            try
            {
                InitLookAndFeel();
            }
            catch { MessageBox.Show("InitLookAndFeel Hatası"); }
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            string[] commandLine = new string[0];
            SingleInstanceController instanceController = new SingleInstanceController();
            try
            {
                instanceController.Run(commandLine);
            }
            catch
            {
                MessageBox.Show("Program Yüklenme Hatası");
            }

            //SplashScreenManager.ShowForm(typeof(SplashScreen1));
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
            ////BonusSkins.Register();
            //SkinManager.EnableFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////#if DEBUG
            ////            DataBase.SetInitializer(new Init());
            ////#endif


            //AppSession.MainForm = new RibbonMainForm();
            //AppSession.MainForm.WindowState = FormWindowState.Minimized;
            
            //Application.Run(new RibbonMainForm());
            ////Application.Run(new MainForm());

            ////Application.Run(CompositionRoot.Resolve<MainForm>());
        }

        private static void InitLookAndFeel()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var Server = IniIslemleri.VeriOku("DataSetting", "Host");
                var DataBaseName = IniIslemleri.VeriOku("DataSetting", "DataBase");
                var Kullanici = IniIslemleri.VeriOku("DataSetting", "User");
                var SifreHash = IniIslemleri.VeriOku("DataSetting", "Password");
                var Sifre = CryptoManager.SifreCoz(SifreHash);
                config.ConnectionStrings.ConnectionStrings["PoliceTakip"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    Server, DataBaseName, Kullanici, Sifre);
                config.ConnectionStrings.ConnectionStrings["PoliceTakipDosya"].ConnectionString = String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    Server, DataBaseName + "Dosya", Kullanici, Sifre);
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch { MessageBox.Show("Ini Yüklenme Hatası"); }
            try
            {
                Application.EnableVisualStyles();
                SkinManager.EnableFormSkins();
                BonusSkins.Register();
                SkinManager.Default.RegisterAssembly(typeof(OfficeSkins).Assembly);
                SkinManager.Default.RegisterAssembly(typeof(BonusSkins).Assembly);
                SkinManager.Default.RegisterAssembly(typeof(OfficeSkins).Assembly);
                Application.SetCompatibleTextRenderingDefault(false);
            }
            catch { MessageBox.Show("Skin Yüklenme Hatası"); }
            try
            {
                CompositionRoot.Wire(new ResolveModule());
            }
            catch { MessageBox.Show("Ninject Modül Yüklenme Hatası"); }
            try
            {
                CompositionRoot.Resolve<Session>();
            }
            catch
            {
                MessageBox.Show("Session Yüklenme Hatası");
            }
        }
    }
}
            //CompositionRoot.Validate(new ValidationModule());
            
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //System.Web.Mvc.ModelValidatorProviders.Providers.Clear();
            //NinjectValidatoryFactory validatorFactory = new NinjectValidatoryFactory();
            //ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(validatorFactory));
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            //FluentValidationModelValidatorProvider.Configure(provider =>
            //{
            //    provider.ValidatorFactory = new NinjectValidatoryFactory();
            //    provider.AddImplicitRequiredValidator = false;
            //});