using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.ValidationRules.FluentValidation;
using Policem.Core.Core.Aspects.ValidationAspects;
using Policem.Data;
using Policem.Data.Common.Abstract;


namespace Policem.Core.Business.Concrete.Managers
{
    public class SigortaFirmaManager : ISigortaFirmaService
    {
        private ISigortaFirmaDal _sigortaDal;


        public SigortaFirmaManager(ISigortaFirmaDal sigortaDal)
        {
            _sigortaDal = sigortaDal;

        }
        [FluentValidationAspect(typeof(SigortaciValidator))]
        public Sigortaci Add(Sigortaci sigortaFirma)
        {
            return _sigortaDal.Add(sigortaFirma);
        }

        public Sigortaci Delete(Sigortaci sigortaFirma)
        {
            return _sigortaDal.Delete(sigortaFirma);
        }

        public List<Sigortaci> GetAll()
        {
            return _sigortaDal.GetList();
        }

        public Sigortaci GetByFirmaNumber(string number)
        {
            return _sigortaDal.Get(i => i.FirmaNo == number);
        }

        public Sigortaci GetById(int id)
        {
            return _sigortaDal.Get(i => i.SigortaciId == id);
        }

        [FluentValidationAspect(typeof(SigortaciValidator))]
        public Sigortaci Update(Sigortaci sigortaFirma)
        {
            //validation
            //ValidatorTool.FluentValidate(new SigortaciValidator(), sigortaFirma);
            return _sigortaDal.Update(sigortaFirma);
        }
    }
}
