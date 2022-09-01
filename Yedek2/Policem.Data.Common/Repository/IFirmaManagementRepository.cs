using System.Collections.Generic;

namespace Policem.Data.Common.Repository
{
    public interface IFirmaManagementRepository:IWriteRepository
    {
        int GetTotalFirma();
        Firma GetFirma(int Id);
        IEnumerable<Firma> GetAllFirma();
    }
}
