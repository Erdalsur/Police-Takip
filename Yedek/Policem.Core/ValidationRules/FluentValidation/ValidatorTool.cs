using System;
using FluentValidation;
using Policem.Core.ExceptionHandling.Exceptions;
using Policem.Data;

namespace Policem.Core.ValidationRules.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);

            foreach (var error in result.Errors)
            {
                throw new ValidationCoreException(error.ErrorMessage);
            }
        }
    }

    public class SigortaciValidator : AbstractValidator<Sigortaci>
    {
        public SigortaciValidator()
        {
            base.RuleFor(t => t.FirmaNo).NotEmpty();
            base.RuleFor(t => t.SigortaciAdi).NotEmpty();
            base.RuleFor(t => t.TemsilciTel).Length(13);
                
        }
    }
}
