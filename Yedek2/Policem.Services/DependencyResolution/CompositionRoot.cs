using System.Web.ModelBinding;
using FluentValidation.Mvc;
using Ninject;
using Ninject.Modules;
using Policem.Core.Business.DependencyResolvers.Ninject;

namespace Policem.Services.DependencyResolution
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
            ValidationConfiguration();
        }

        public static void Validate(INinjectModule module)
        {
            _ninjectKernel.Load(module);
            ValidationConfiguration();
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }

        private static void ValidationConfiguration()
        {
            NinjectValidatoryFactory validatorFactory = new NinjectValidatoryFactory();
            FluentValidationModelValidatorProvider.Configure(x => x.ValidatorFactory = validatorFactory);
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }

    }
}
