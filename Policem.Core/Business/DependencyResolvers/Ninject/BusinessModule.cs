using Ninject.Modules;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.Concrete.Managers;
using Policem.Data.Common.Abstract;
using Policem.Data.Common.Concrete.EntityFramework;

namespace Policem.Core.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IPoliceService>().To<PoliceManager>().InSingletonScope();
            Bind<IPoliceDal>().To<EfPoliceDal>().InSingletonScope();
            Bind<IPoliceDosyaService>().To<PoliceDosyaManager>().InSingletonScope();
            Bind<IPoliceDosyaDal>().To<EfPoliceDosyaDal>().InSingletonScope();
            Bind<ISigortaFirmaService>().To<SigortaFirmaManager>().InSingletonScope();
            Bind<ISigortaFirmaDal>().To<EfSigortaFirmaDal>().InSingletonScope();
            Bind<IPoliceMusteriService>().To<PoliceMusteriManager>().InSingletonScope();
            Bind<IPoliceMusteriDal>().To<EfPoliceMusteriDal>().InSingletonScope();
            //Bind<DbContext>().To<PoliceContext>();
            Bind<IFirmaPoliceService>().To<FirmaPoliceManager>().InSingletonScope();
        }

    }
}
