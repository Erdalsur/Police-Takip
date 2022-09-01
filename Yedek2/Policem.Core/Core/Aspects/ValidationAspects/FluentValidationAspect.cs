using System;
using System.Linq;
using FluentValidation;
using Policem.Core.Core.CrossCuttingConcern.Validation.FluentValidation;
using PostSharp.Aspects;

namespace Policem.Core.Core.Aspects.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private readonly Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)//Compile time
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var ta = args.Arguments.ToList();
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            
            foreach (var entity in ta)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
            
        }
    }
}
