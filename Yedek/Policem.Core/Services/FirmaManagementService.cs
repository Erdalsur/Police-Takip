using System.Collections.Generic;
using Policem.Data;
using Policem.Data.Common.Abstract;
using Policem.Data.Common.Repository;
using StructureMap;

namespace Policem.Core.Services
{
    public class FirmaManagementService : IFirmaManagementService
    {
        //private readonly IFirmaManagementRepository _firmaManagementRepository;
        private readonly IFirmaManagementRepository repository;
        public FirmaManagementService(IPoliceMusteriDal policeMusteriDal)
        {
            //var kernel = new StandardKernel(new BusinessModule());
            //repository = kernel.Get<FirmaManagementRepository>();
            repository=ObjectFactory.GetInstance<IFirmaManagementRepository>();   
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        public Firma EkleFirma(Firma firma)
        {
            return repository.Insert<Firma>(firma);
            //throw new NotImplementedException();
        }

        public IEnumerable<Firma> GetAllFirma()
        {
            return repository.GetAllFirma();
        }

        public Firma GetFirma(int Id)
        {
            return repository.GetFirma(Id);
        }

        public int GetTotalFirma()
        {
            return repository.GetTotalFirma();
        }

        public Firma GüncelleFirma(Firma firma)
        {
            return repository.Update<Firma>(firma);
        }

        public Firma SilFirma(Firma firma)
        {
            return repository.Delete<Firma>(firma);
        }
    }
}

