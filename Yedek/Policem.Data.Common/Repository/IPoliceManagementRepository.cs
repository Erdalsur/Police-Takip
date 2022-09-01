using System.Collections.Generic;

namespace Policem.Data.Common.Repository
{
    public interface IPoliceManagementRepository:IWriteRepository
    {
        int GetTotalPolice();
        Police GetPolice(int Id);
        Police GetPolice(string PoliceNo);
        IEnumerable<Police> GetAllPolice();
        IEnumerable<Police> GetGelmeyenPoliceler();
    }
}
