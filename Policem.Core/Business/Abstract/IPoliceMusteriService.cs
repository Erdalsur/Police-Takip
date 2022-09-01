using System.Collections.Generic;
using System.ServiceModel;
using Policem.Data;

namespace Policem.Core.Business.Abstract
{
    [ServiceContract]
    public interface IPoliceMusteriService
    {
        [OperationContract]
        List<Firma> GetAll();
        [OperationContract]
        Firma GetById(int id);
        [OperationContract]
        Firma GetByMusteriNumber(string number);
        [OperationContract]
        Firma Add(Firma policeMusteri);
        [OperationContract]
        Firma Update(Firma policeMusteri);
        [OperationContract]
        Firma Delete(Firma policeMusteri);

    }
}
