using System;
using System.Collections.Generic;
using System.Data;
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
        protected WccbContext Context;
        protected DbSet<T> DbSet;

        protected GenericRepository()
        {
            Context = new WccbContext();
            DbSet = Context.Set<T>();
        }

        public virtual IQueryable<T> FindAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            var resultSet = DbSet.AsQueryable();

            if (filter != null)
                resultSet = resultSet.Where(filter);
            
            return resultSet;
        }

        public virtual T FindById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual bool Exists(T item)
        {
            return DbSet.Contains(item);
        }

        public virtual T Create(T item)
        {
            DbSet.Add(item);
            Context.SaveChanges();
            return item;
        }

        public virtual void Update(T item)
        {
            DbSet.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            var item = DbSet.Find(id);
            DbSet.Remove(item);
            Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
