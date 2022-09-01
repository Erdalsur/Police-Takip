using System;
using System.Data.Entity;
using FluentValidation;
using Ninject;
using Ninject.Modules;
using Policem.Core.Services;
using Policem.Core.ValidationRules.FluentValidation;
using Policem.Data;
using Policem.Data.Common.Abstract;
using Policem.Data.Common.Concrete.EntityFramework;
using Policem.Data.Common.Repository;

namespace Policem.Core.DependencyResolution
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            //Bind<IFirmaManagementService>().To<FirmaManagementService>();//.InSingletonScope();
            //Bind<ISigortaciManagementService>().To<SigortaciManagementService>();//.InSingletonScope();
            //Bind<IPoliceManagementService>().To<PoliceManagementService>();//.InSingletonScope();
            //Bind<IFirmaManagementRepository>().To<FirmaManagementRepository>();
            //Bind<ISigortaciManagementRepository>().To<SigortaciManagementRepository>();
            //Bind<IPoliceManagementRepository>().To<PoliceManagementRepository>();
            Bind<IPoliceService>().To<PoliceManager>().InSingletonScope();
            Bind<IPoliceDal>().To<EfPoliceDal>().InSingletonScope();
            Bind<ISigortaFirmaService>().To<SigortaFirmaManager>().InSingletonScope();
            Bind<ISigortaFirmaDal>().To<EfSigortaFirmaDal>().InSingletonScope();
            Bind<IPoliceMusteriService>().To<PoliceMusteriManager>().InSingletonScope();
            Bind<IPoliceMusteriDal>().To<EfPoliceMusteriDal>().InSingletonScope();
            //Bind<DbContext>().To<PoliceContext>();
        }
        
    }

    public class DependencyResolver<T>
    {
        public static T Resolve()
        {
            IKernel kernel = new StandardKernel(new ResolveModule());

            return kernel.Get<T>();
        }
    }
    public class ResolveModule : NinjectModule
    {
        public override void Load()
        {
            //var soaSetting = ConfigurationManager.AppSettings["SOA"];

            //var soa = !string.IsNullOrEmpty(soaSetting) && soaSetting.ToBoolean();

            //if (soa)
            //{
            //    Kernel.Load(new ServiceModule());
            //}
            //else
            //{
                Kernel.Load(new BusinessModule());
            //}
        }
    }

    public class NinjectValidatoryFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public NinjectValidatoryFactory()
        {
            _kernel = new StandardKernel(new ValidationModule());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            //var bindings = (List<IBinding>)_kernel.GetBindings(validatorType);

            //if (bindings.Count > 0)
            //    return (IValidator)_kernel.Get(validatorType);

            //return null;

            return (validatorType == null) ? null : (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
