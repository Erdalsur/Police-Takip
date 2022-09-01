using System.Collections.Generic;
using System.ServiceModel;
using Policem.Data;

namespace Policem.Core.Business.Abstract
{
    [ServiceContract]
    public interface IPoliceService
    {
        [OperationContract]
        List<Police> GetAll();
        [OperationContract]
        Police GetById(int id);
        [OperationContract]
        Police GetByPoliceNumber(string number);
        [OperationContract]
        Police Add(Police police);
        [OperationContract]
        Police Update(Police police);
        [OperationContract]
        Police Delete(Police police);
        [OperationContract]
        List<Police> GetMusteriPoliceleri(Firma policeMusteri);
    }
}
