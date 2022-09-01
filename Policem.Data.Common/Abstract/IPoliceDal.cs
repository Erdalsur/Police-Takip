using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policem.Core.DataAccess;

namespace Policem.Data.Common.Abstract
{
    public interface IPoliceDal : IEntityRepository<Police>
    {
    }
}
