using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.DependencyResolvers.Ninject;
using Policem.Data;

namespace Policem.Core.Service
{
    public class MusteriService:IPoliceMusteriService
    {
        private readonly IPoliceMusteriService service;
        public MusteriService()
        {
            service = InstanceFactory<IPoliceMusteriService>.GetInstance();
        }

        public Firma Add(Firma policeMusteri)
        {
            return service.Add(policeMusteri);
        }

        public Firma Delete(Firma policeMusteri)
        {
            return service.Delete(policeMusteri);
        }

        public List<Firma> GetAll()
        {
            return service.GetAll();
        }

        public Firma GetById(int id)
        {
            return service.GetById(id);
        }

        public Firma GetByMusteriNumber(string number)
        {
            return service.GetByMusteriNumber(number);
        }

        public Firma Update(Firma policeMusteri)
        {
            return service.Update(policeMusteri);
        }
    }
}
