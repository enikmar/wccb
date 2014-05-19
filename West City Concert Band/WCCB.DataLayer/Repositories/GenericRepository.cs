using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WCCB.DataLayer.Repositories.Interfaces;

namespace WCCB.DataLayer.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly WccbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected GenericRepository(WccbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           int pageSize = 0,
           int pageNo = 0)
        {
            IQueryable<TEntity> resultSet = _dbSet;

            if (filter != null)
                resultSet = resultSet.Where(filter);

            if (orderBy != null)
                resultSet = orderBy(resultSet);

            if (pageNo > 0)
                resultSet = resultSet.Skip(pageSize * pageNo);

            if (pageSize > 0)
                resultSet = resultSet.Take(pageSize);
            
            return resultSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity item)
        {
            _dbSet.Attach(item);
            //_context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity item)
        {
            //if (_context.Entry(item).State == EntityState.Detached)
            //{
            //    _dbSet.Attach(item);
            //}
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
