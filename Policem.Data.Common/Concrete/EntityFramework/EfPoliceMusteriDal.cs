using Policem.Core.DataAccess;
using Policem.Data.Common.Abstract;

namespace Policem.Data.Common.Concrete.EntityFramework
{
    public class EfPoliceMusteriDal : EfEntityRepositoryBase<Firma, PoliceContext>, IPoliceMusteriDal
    {
    }
}
