using System.Collections.Generic;

namespace Policem.Data.Common.Repository
{
    public interface ISigortaciManagementRepository:IWriteRepository
    {
        int GetTotalSigortaci();
        Sigortaci GetSigortaci(int Id);
        IEnumerable<Sigortaci> GetAllSigortaci();
    }
}
