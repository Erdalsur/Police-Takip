using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Data;
using Policem.Data.Common.Abstract;

namespace Policem.Core.Business.Concrete.Managers
{
    public class PoliceDosyaManager : IPoliceDosyaService
    {
        private IPoliceDosyaDal _policeDosyaDal;
        public PoliceDosyaManager(IPoliceDosyaDal policeDosyaDal)
        {
            _policeDosyaDal = policeDosyaDal;
        }
        public PoliceDosyaDetay Add(PoliceDosyaDetay policeDosya)
        {
            return _policeDosyaDal.Add(policeDosya);
        }

        public PoliceDosyaDetay Delete(PoliceDosyaDetay policeDosya)
        {
            return _policeDosyaDal.Delete(policeDosya);
        }

        public PoliceDosyaDetay GetById(int id)
        {
            return _policeDosyaDal.Get(i => i.Id == id);
        }

        public List<PoliceDosyaDetay> GetPoliceById(int id)
        {
            return _policeDosyaDal.GetList(i => i.PoliceId == id);
        }

        public PoliceDosyaDetay Update(PoliceDosyaDetay policeDosya)
        {
            return _policeDosyaDal.Update(policeDosya);
        }
    }
}
