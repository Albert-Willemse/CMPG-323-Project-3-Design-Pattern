using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SuperStore_P3.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int? id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void SaveChanges();
    }
}
