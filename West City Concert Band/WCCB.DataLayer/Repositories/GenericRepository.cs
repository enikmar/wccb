using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WCCB.DataLayer.DbContexts;
using WCCB.DataLayer.Repositories.Interfaces;

namespace WCCB.DataLayer.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        readonly WccbContext _context;
        readonly DbSet<T> _dbSet;

        protected GenericRepository()
        {
            _context = new WccbContext();
            _dbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            var resultSet = _dbSet.AsQueryable();

            if (filter != null)
                resultSet = resultSet.Where(filter);
            
            return resultSet;
        }

        public virtual T FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual bool Exists(T item)
        {
            return _dbSet.Contains(item);
        }

        public virtual T Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }

        public virtual void Update(T item)
        {
            _dbSet.Attach(item);
            //_context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
