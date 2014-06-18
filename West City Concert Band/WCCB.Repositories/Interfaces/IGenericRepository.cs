using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WCCB.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> filter);
        
        T FindById(object id);

        T Create(T item);

        void Update(T item);

        void Delete(object id);

        bool Exists(T item);

        void Dispose();
    }
}