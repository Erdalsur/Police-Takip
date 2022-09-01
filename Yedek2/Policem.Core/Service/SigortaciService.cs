using System.Collections.Generic;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.DependencyResolvers.Ninject;
using Policem.Data;

namespace Policem.Core.Service
{
    public class SigortaciService:ISigortaFirmaService
    {
        private readonly ISigortaFirmaService service;
        public SigortaciService()
        {
            service = InstanceFactory<ISigortaFirmaService>.GetInstance();
        }

        public Sigortaci Add(Sigortaci sigortaFirma)
        {
            return service.Add(sigortaFirma);
        }

        public Sigortaci Delete(Sigortaci sigortaFirma)
        {
            return service.Delete(sigortaFirma);
        }

        public List<Sigortaci> GetAll()
        {
            return service.GetAll();
        }

        public Sigortaci GetByFirmaNumber(string number)
        {
            return service.GetByFirmaNumber(number);
        }

        public Sigortaci GetById(int id)
        {
            return service.GetById(id);
        }

        public Sigortaci Update(Sigortaci sigortaFirma)
        {
            return service.Update(sigortaFirma);
        }
    }
}
