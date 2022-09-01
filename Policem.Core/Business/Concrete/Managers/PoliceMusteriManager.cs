using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Data;
using Policem.Data.Common.Abstract;

namespace Policem.Core.Business.Concrete.Managers
{
    public class PoliceMusteriManager : IPoliceMusteriService
    {
        private IPoliceMusteriDal _musteriDal;

        public PoliceMusteriManager(IPoliceMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;

        }

        public Firma Add(Firma policeMusteri)
        {
            return _musteriDal.Add(policeMusteri);
        }

        public Firma Delete(Firma policeMusteri)
        {
            return _musteriDal.Delete(policeMusteri);
        }

        public List<Firma> GetAll()
        {
            return _musteriDal.GetList();
        }

        public Firma GetById(int id)
        {
            return _musteriDal.Get(i => i.FirmaId == id);
        }

        public Firma GetByMusteriNumber(string number)
        {
            return _musteriDal.Get(i => i.Kod == number);
        }

        public Firma Update(Firma policeMusteri)
        {
            return _musteriDal.Update(policeMusteri);
        }
    }
}
