using System.Web.ModelBinding;
using FluentValidation.Mvc;
using Ninject;
using Ninject.Modules;
using Policem.Core.Business.DependencyResolvers.Ninject;

namespace Policem.UI.DependencyResolution
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

    //public class NinjectControllerFactory : DefaultControllerFactory
    //{
    //    private readonly IKernel _kernel;

    //    public NinjectControllerFactory()
    //    {
    //        _kernel = new StandardKernel(new ResolveModule());
    //    }

    //    /// <summary>
    //    /// Web api DI çözümü Kernel'a ihtiyaç duyuyor. Daha iyi bir çözüm implemente edilebilir. Şimdilik uygun.
    //    /// </summary>
    //    public IKernel Kernel
    //    {
    //        get { return _kernel; }
    //    }

    //    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    //    {
    //        return controllerType == null ? null : (IController)_kernel.Get(controllerType);
    //    }
    //}
}
