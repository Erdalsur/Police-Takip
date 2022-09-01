using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface IPoliceService
    {
        List<Police> GetAll();
        Police GetById(int id);
        Police GetByPoliceNumber(string number);
        Police Add(Police police);
        Police Update(Police police);
        Police Delete(Police police);
        List<Police> GetMusteriPoliceleri(Firma policeMusteri);
    }
}
