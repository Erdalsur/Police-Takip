using System.Collections.Generic;
using System.Linq;
using Policem.Data.Common.Concrete.EntityFramework;

namespace Policem.Data.Common.Repository
{
    public class FirmaManagementRepository : WriteRepository<PoliceContext>, IFirmaManagementRepository
    {
        public IEnumerable<Firma> GetAllFirma()
        {
            return Context.Firmalar.OrderBy(a => a.Name);
        }

        public Firma GetFirma(int Id)
        {
            return Context.Firmalar.FirstOrDefault(a => a.FirmaId == Id);
        }

        public int GetTotalFirma()
        {
            return Context.Firmalar.Count();
        }
    }
}
