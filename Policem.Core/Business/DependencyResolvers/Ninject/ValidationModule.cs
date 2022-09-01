using FluentValidation;
using Ninject.Modules;
using Policem.Core.Business.ValidationRules.FluentValidation;
using Policem.Data;

namespace Policem.Core.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            //AssemblyScanner.FindValidatorsInAssemblyContaining<SigortaciValidator>()
            //    .ForEach(m => Bind(m.InterfaceType).To(m.ValidatorType));
            Bind<IValidator<Sigortaci>>().To<SigortaciValidator>().InSingletonScope();
        }
    }
}
