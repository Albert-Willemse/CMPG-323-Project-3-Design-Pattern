using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SuperStore_P3.DAL.Repository
{
    // Generic repository implementation for CRUD operations on entities of type T.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SuperStoreContext _context;

        public GenericRepository(SuperStoreContext context)
        {
            _context = context;
        }

        // Add a new entity to the repository.
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        // Add a collection of entities to the repository.
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        // Find entities based on a specified filtering expression.
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        // Retrieve all entities of type T.
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        // Retrieve an entity by its unique identifier.
        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        // Remove an entity from the repository.
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        // Remove a collection of entities from the repository.
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        // Update an existing entity in the repository.
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        // Persist changes to the underlying data store.
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}