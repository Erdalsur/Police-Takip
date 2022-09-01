using FluentValidation;
using Policem.Data;

namespace Policem.Core.Business.ValidationRules.FluentValidation
{
   
    public class SigortaciValidator : AbstractValidator<Sigortaci>
    {
        public SigortaciValidator()
        {
            RuleFor(t => t.FirmaNo).NotEmpty().WithMessage("Firma No Boş Olamaz");
            RuleFor(t => t.SigortaciAdi).NotEmpty().WithMessage("Sigortaci Adı Boş Olamaz.").WithErrorCode("1");
            RuleFor(t => t.TemsilciTel).MaximumLength(13).WithMessage("Geçersiz Telefon Numarası").NotEmpty().WithMessage("Temsil Telefonu Boş Olamaz.");
        }
    }
}
