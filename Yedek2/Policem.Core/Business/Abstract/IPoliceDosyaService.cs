using System.Collections.Generic;
using System.ServiceModel;
using Policem.Data;

namespace Policem.Core.Business.Abstract
{
    [ServiceContract]
    public interface IPoliceDosyaService
    {
        [OperationContract]
        PoliceDosyaDetay GetById(int id);
        [OperationContract]
        PoliceDosyaDetay Add(PoliceDosyaDetay police);
        [OperationContract]
        PoliceDosyaDetay Update(PoliceDosyaDetay police);
        [OperationContract]
        PoliceDosyaDetay Delete(PoliceDosyaDetay police);
        [OperationContract]
        List<PoliceDosyaDetay> GetPoliceById(int id);
    }
}
