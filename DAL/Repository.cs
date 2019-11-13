using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected DbContext Context;

        public Repository(DbContext _context)
        {
            Context = _context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllInclude(params Expression<Func<T, object>>[] includes)
        {
          return  includes.Aggregate(Context.Set<T>().AsQueryable(),
                 (current, includeProperty) =>current.Include(includeProperty)).ToList();
        }

        //public IEnumerable<T> GetAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        //{
        //    return includes.Aggregate(Context.Set<T>().Where(predicate),
        //        (current, includeProperty) =>
        //            current.Include(includeProperty)).ToList();
        //}

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();

        }

        public void Remove(int id)
        {      
         
            Context.Set<T>().Remove(Context.Set<T>().Find(id));
            Context.SaveChanges();

        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        
    }
}
