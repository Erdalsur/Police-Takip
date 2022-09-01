using Policem.Core.DataAccess;
using Policem.Data.Common.Abstract;

namespace Policem.Data.Common.Concrete.EntityFramework
{
    public class EfPoliceDal : EfEntityRepositoryBase<Police, PoliceContext>, IPoliceDal
    {
    }
}
