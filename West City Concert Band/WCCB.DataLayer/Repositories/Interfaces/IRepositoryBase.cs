using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WCCB.DataLayer.Repositories.Interfaces
{
    public interface IRepositoryBase<TType> : IDisposable
    {
        IEnumerable<TType> GetAll();
        IEnumerable<TType> Get(Expression<Func<TType, bool>> query);
        TType GetById(object id);
        void Add(TType item);
        void Update(TType item);
        void Delete(TType item);
    }
}