using System.Collections.Generic;
using System.Linq;
using Policem.Data.Common.Concrete.EntityFramework;

namespace Policem.Data.Common.Repository
{
    public class SigortaciManagementRepository : WriteRepository<PoliceContext>, ISigortaciManagementRepository
    {
        public IEnumerable<Sigortaci> GetAllSigortaci()
        {
            return Context.Sigortacilar.OrderBy(t => t.SigortaciAdi);
        }

        public Sigortaci GetSigortaci(int Id)
        {
            return Context.Sigortacilar.FirstOrDefault(t => t.SigortaciId == Id);
        }

        public int GetTotalSigortaci()
        {
            return Context.Sigortacilar.Count();
        }
    }
}
