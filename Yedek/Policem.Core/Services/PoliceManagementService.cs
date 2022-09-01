using System.Collections.Generic;
using Ninject;
using Policem.Core.DependencyResolution;
using Policem.Data;
using Policem.Data.Common.Concrete.EntityFramework;
using Policem.Data.Common.Repository;

namespace Policem.Core.Services
{
    public class PoliceManagementService : IPoliceManagementService
    {
        private readonly PoliceManagementRepository repository;
        public PoliceManagementService()
        {
            var kernel = new StandardKernel(new BusinessModule());
            //kernel.Bind<PoliceContext>().To<PoliceContext>().InSingletonScope();
            repository = kernel.Get<PoliceManagementRepository>();
            
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public Police EklePolice(Police police)
        {
            return repository.Insert<Police>(police);
        }

        public IEnumerable<Police> GetAllPolice()
        {
            return repository.GetAllPolice();
        }

        public Police GetPolice(int Id)
        {
            return repository.GetPolice(Id);
        }

        public int GetTotalPolice()
        {
            return repository.GetTotalPolice();
        }

        public Police GüncellePolice(Police police)
        {
            return repository.Update<Police>(police);
        }

        public Police SilPolice(Police police)
        {
            return repository.Delete<Police>(police);
        }
    }
}
