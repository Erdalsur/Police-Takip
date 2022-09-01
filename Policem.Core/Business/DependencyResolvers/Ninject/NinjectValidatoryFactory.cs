using System;
using FluentValidation;
using System.Linq;
using Ninject;
using Policem.Data;
using Policem.Core.Business.ValidationRules.FluentValidation;

namespace Policem.Core.Business.DependencyResolvers.Ninject
{
    public class NinjectValidatoryFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public NinjectValidatoryFactory()
        {
            _kernel = new StandardKernel(new ValidationModule());
        }

        public void AddBinding()
        {
            _kernel.Bind<IValidator<Sigortaci>>().To<SigortaciValidator>();
            
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            //var bindings = (List<IBinding>)_kernel.GetBindings(validatorType);

            //if (bindings.Count > 0)
            //    return (IValidator)_kernel.Get(validatorType);

            //return null;
            if (!_kernel.GetBindings(validatorType).Any())
            {
                return null;
            }

            return _kernel.Get(validatorType) as IValidator;
            //return (validatorType == null) ? null : (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
