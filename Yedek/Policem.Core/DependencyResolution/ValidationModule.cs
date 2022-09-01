using FluentValidation;
using Ninject.Modules;
using Policem.Core.ValidationRules.FluentValidation;
using Policem.Data;

namespace Policem.Core.DependencyResolution
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Sigortaci>>().To<SigortaciValidator>().InSingletonScope();
        }
    }
}
