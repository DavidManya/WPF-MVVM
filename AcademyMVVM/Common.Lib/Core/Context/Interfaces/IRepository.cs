using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Lib.Infrastructure;

namespace Common.Lib.Core.Context.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> QueryAll();
        T Find(Guid id);
        SaveResult<T> Add(T entity);
        SaveResult<T> Update(T entity);
        SaveResult<T> Delete(T entity);
    }
}
