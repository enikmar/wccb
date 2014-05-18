using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WCCB.DataLayer.Repositories.Interfaces;

namespace WCCB.DataLayer.Repositories
{
    public abstract class RepositoryBase<TType, TContext> : IRepositoryBase<TType>
        where TContext : ObjectContext, new()
        where TType : EntityObject
    {
        #region Implementation of IDisposable

        public abstract void Dispose();

        #endregion

        #region Implementation of IRepositoryBase<TType>

        public abstract IEnumerable<TType> GetAll();
        public abstract IEnumerable<TType> Get(Expression<Func<TType, bool>> query);
        public abstract TType GetById(object id);
        public abstract void Add(TType item);
        public abstract void Update(TType item);
        public abstract void Delete(TType item);

        #endregion
    }
}
