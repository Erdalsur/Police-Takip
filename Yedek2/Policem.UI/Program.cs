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
            Program.InitLookAndFeel();
            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            string[] commandLine = new string[0];
            SingleInstanceController instanceController = new SingleInstanceController();
            try
            {
                instanceController.Run(commandLine);
            }
            catch
            {
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
            System.Windows.Forms.Application.EnableVisualStyles();
            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            SkinManager.Default.RegisterAssembly(typeof(OfficeSkins).Assembly);
            SkinManager.Default.RegisterAssembly(typeof(BonusSkins).Assembly);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            CompositionRoot.Wire(new ResolveModule());
            CompositionRoot.Resolve<Session>();
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