using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Policem.Data;

namespace Policem.Core.DataAccess
{
    public interface IQueryRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
    }
}
