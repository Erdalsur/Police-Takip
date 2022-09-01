using System.Collections.Generic;
using Policem.Data;
using Policem.Data.Common.Abstract;

namespace Policem.Core.Services
{
    public class SigortaFirmaManager : ISigortaFirmaService
    {
        private ISigortaFirmaDal _sigortaDal;

        //public SigortaFirmaManager()
        //{
        //}
        public SigortaFirmaManager(ISigortaFirmaDal sigortaDal)
        {
            _sigortaDal = sigortaDal;

        }

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

        public Sigortaci Update(Sigortaci sigortaFirma)
        {
            return _sigortaDal.Update(sigortaFirma);
        }
    }
}

