using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface IPoliceMusteriService
    {
        List<Firma> GetAll();
        Firma GetById(int id);
        Firma GetByMusteriNumber(string number);
        Firma Add(Firma policeMusteri);
        Firma Update(Firma policeMusteri);
        Firma Delete(Firma policeMusteri);

    }

}
