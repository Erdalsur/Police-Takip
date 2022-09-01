using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.DependencyResolvers.Ninject;
using Policem.Data;

namespace Policem.Core.Service
{
    public class PoliceService : IPoliceService
    {
        private readonly IPoliceService policeService;
        public PoliceService()
        {
            policeService = InstanceFactory<IPoliceService>.GetInstance();
        }

        public Police Add(Police police)
        {
            return policeService.Add(police);
        }

        public Police Delete(Police police)
        {
            return policeService.Delete(police);
        }

        public List<Police> GetAll()
        {
            return policeService.GetAll();
        }

        public Police GetById(int id)
        {
            return policeService.GetById(id);
        }

        public Police GetByPoliceNumber(string number)
        {
            return policeService.GetByPoliceNumber(number);
        }

        public List<Police> GetMusteriPoliceleri(Firma policeMusteri)
        {
            return policeService.GetMusteriPoliceleri(policeMusteri);
        }

        public Police Update(Police police)
        {
            return policeService.Update(police);
        }
    }
}
