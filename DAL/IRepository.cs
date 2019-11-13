using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllInclude(params Expression<Func<T, object>>[] includes);
        //IEnumerable<T> GetAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
