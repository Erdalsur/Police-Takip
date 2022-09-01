using Ninject;
using Ninject.Modules;
using Policem.Core.DependencyResolution;
using Policem.Core.Services;
using Policem.Data;

namespace Policem.UI.DependencyResolution
{
    public class Session
    {
        public Session()
        {

            businessModule = new BusinessModule();
            validationModule = new ValidationModule();
            kernel = new StandardKernel(businessModule);

            //FirmaService = kernel.Get<IFirmaManagementService>();
            //SigortaciService = kernel.Get<ISigortaciManagementService>();
            //PoliceService = kernel.Get<IPoliceManagementService>();
            //Mapper.CreateServiceMaps();
            PoliceService = kernel.Get<IPoliceService>();
            FirmaService = kernel.Get<IPoliceMusteriService>();
            SigortaciService = kernel.Get<ISigortaFirmaService>();
        }
        public ValidationModule validationModule;
        public BusinessModule businessModule;
        private IKernel kernel;
        public static IPoliceService PoliceService;
        public static IPoliceMusteriService FirmaService;
        public static ISigortaFirmaService SigortaciService;
        //public static IFirmaManagementService FirmaService { get; set; }

        //public static ISigortaciManagementService SigortaciService { get; set; }

        //public static IPoliceManagementService PoliceService { get; set; }
    }

    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }

    public class Session2
    {
        public Session2(IPoliceService pol,IPoliceMusteriService musteri,ISigortaFirmaService sig)
        {
            PoliceService = pol;
            FirmaService=musteri;
            SigortaciService = sig;
        }
        public static IPoliceService PoliceService;
        public static IPoliceMusteriService FirmaService;
        public static ISigortaFirmaService SigortaciService;
    }
}
