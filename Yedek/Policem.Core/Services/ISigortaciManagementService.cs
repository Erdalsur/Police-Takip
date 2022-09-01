using System;
using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface ISigortaciManagementService : IDisposable
    {
        IEnumerable<Sigortaci> GetAllFirma();
        int GetTotalFirma();
        Sigortaci GetFirma(int Id);
        Sigortaci EkleFirma(Sigortaci firma);
        Sigortaci SilFirma(Sigortaci firma);
        Sigortaci GüncelleFirma(Sigortaci firma);
    }
}
