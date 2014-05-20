using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WCCB.DataLayer.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           int pageSize = 0,
           int pageNo = 0);

        TEntity GetById(object id);

        bool Exists(TEntity item);

        void Create(TEntity item);

        void Update(TEntity item);

        void Delete(TEntity item);

        void Delete(object id);

        void Dispose();
    }
}