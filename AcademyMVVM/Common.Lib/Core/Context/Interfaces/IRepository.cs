using System;
using System.Linq;
using Common.Lib.Infrastructure;

namespace Common.Lib.Core.Context
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> QueryAll();
        T Find(Guid id);
        SaveResult<T> Add(T entity);
        SaveResult<T> Update(T entity);
        DeleteResult<T> Delete(T entity);
    }
}
