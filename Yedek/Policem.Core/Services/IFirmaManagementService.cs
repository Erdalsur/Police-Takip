using System;
using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface IFirmaManagementService : IDisposable
    {
        IEnumerable<Firma> GetAllFirma();
        int GetTotalFirma();
        Firma GetFirma(int Id);
        Firma EkleFirma(Firma firma);
        Firma SilFirma(Firma firma);
        Firma GüncelleFirma(Firma firma);
    }
}
