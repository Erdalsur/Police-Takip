using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Data;
using Policem.Data.Common.Abstract;

namespace Policem.Core.Business.Concrete.Managers
{
    public class PoliceManager : IPoliceService
    {
        private IPoliceDal _policeDal;

        public PoliceManager(IPoliceDal policeDal)
        {
            _policeDal = policeDal;

        }

        public Police Add(Police police)
        {
            return _policeDal.Add(police);
        }

        public Police Delete(Police police)
        {
            return _policeDal.Delete(police);
        }

        public List<Police> GetAll()
        {
            return _policeDal.GetList();
        }

        public Police GetById(int id)
        {
            return _policeDal.Get(i => i.PoliceId == id);
        }

        public Police GetByPoliceNumber(string number)
        {
            return _policeDal.Get(i => i.PoliceNo == number);
        }

        public List<Police> GetMusteriPoliceleri(Firma policeMusteri)
        {

            return _policeDal.GetList(i => i.Firma.FirmaId == policeMusteri.FirmaId);
        }

        public Police Update(Police police)
        {
            return _policeDal.Update(police);
        }
    }
}
