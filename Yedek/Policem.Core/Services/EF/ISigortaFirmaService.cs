using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface ISigortaFirmaService
    {
        List<Sigortaci> GetAll();
        Sigortaci GetById(int id);
        Sigortaci GetByFirmaNumber(string number);
        Sigortaci Add(Sigortaci sigortaFirma);
        Sigortaci Update(Sigortaci sigortaFirma);
        Sigortaci Delete(Sigortaci sigortaFirma);

    }
}
