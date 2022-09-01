using System.Collections.Generic;
using System.ServiceModel;
using Policem.Data;

namespace Policem.Core.Business.Abstract
{
    [ServiceContract]
    public interface IFirmaPoliceService
    {
        [OperationContract]
        List<SigortaciEkran> GetAll();
    }
    [ServiceContract]
    public interface ISigortaFirmaService
    {
        [OperationContract]
        List<Sigortaci> GetAll();
        [OperationContract]
        Sigortaci GetById(int id);
        [OperationContract]
        Sigortaci GetByFirmaNumber(string number);
        [OperationContract]
        Sigortaci Add(Sigortaci sigortaFirma);
        [OperationContract]
        Sigortaci Update(Sigortaci sigortaFirma);
        [OperationContract]
        Sigortaci Delete(Sigortaci sigortaFirma);

    }
}
