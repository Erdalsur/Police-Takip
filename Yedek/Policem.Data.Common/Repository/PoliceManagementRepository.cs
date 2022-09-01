using System.Collections.Generic;
using System.Linq;
using Policem.Data.Common.Concrete.EntityFramework;

namespace Policem.Data.Common.Repository
{
    public class PoliceManagementRepository : WriteRepository<PoliceContext>, IPoliceManagementRepository
    {
        public IEnumerable<Police> GetAllPolice()
        {
            return Context.Policeler.OrderByDescending(a => a.PoliceBaslangicTarih);
        }

        public IEnumerable<Police> GetGelmeyenPoliceler()
        {

            return Context.Policeler.Where(t => t.PoliceGeldimi == 0);
        }

        public Police GetPolice(int Id)
        {
            return Context.Policeler.FirstOrDefault(t => t.PoliceId == Id);
        }

        public Police GetPolice(string PoliceNo)
        {
            return Context.Policeler.FirstOrDefault(t => t.PoliceNo == PoliceNo);
        }

        public int GetTotalPolice()
        {
            return Context.Policeler.Count();
        }
    }
}
