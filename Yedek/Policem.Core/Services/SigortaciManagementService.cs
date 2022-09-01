using System.Collections.Generic;
using Ninject;
using Policem.Core.DependencyResolution;
using Policem.Data;
using Policem.Data.Common.Repository;

namespace Policem.Core.Services
{
    public class SigortaciManagementService : ISigortaciManagementService
    {
        private readonly SigortaciManagementRepository _firmaRepository;
        public SigortaciManagementService()
        {
            var kernel = new StandardKernel(new BusinessModule());
            _firmaRepository = kernel.Get<SigortaciManagementRepository>();
            
        }
        public void Dispose()
        {
            _firmaRepository.Dispose();
            
        }

        public Sigortaci EkleFirma(Sigortaci firma)
        {
            return _firmaRepository.Insert<Sigortaci>(firma);
        }

        public IEnumerable<Sigortaci> GetAllFirma()
        {
            return _firmaRepository.GetAllSigortaci();
        }

        public Sigortaci GetFirma(int Id)
        {
            return _firmaRepository.GetSigortaci(Id);
        }

        public int GetTotalFirma()
        {
            return _firmaRepository.GetTotalSigortaci();
        }

        public Sigortaci GüncelleFirma(Sigortaci firma)
        {
            return _firmaRepository.Update<Sigortaci>(firma);
        }

        public Sigortaci SilFirma(Sigortaci firma)
        {
            return _firmaRepository.Delete<Sigortaci>(firma);
        }
    }
}
