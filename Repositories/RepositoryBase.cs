﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System.Linq.Expressions;

namespace Repositories
{
    public abstract class RepositoryBase<T,BaseContext> : DbContext,IRepositoryBase<T> where T:class where BaseContext:DbContext
    {
        private readonly BaseContext _context;
        public RepositoryBase(BaseContext context)
        {
            _context = context;
        }
        public bool Create(T entity)
        {

           _context.Set<T>().Add(entity);
           return _context.SaveChanges() > 0;
        }
        public async Task<bool> CreateRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Delete(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }

            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            if (entities.Any())
            {
                _context.RemoveRange(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public IQueryable<T> GetAll()
        {
           return _context.Set<T>().AsQueryable().AsNoTracking();
        }
        public IEnumerable<T> GetAllWithInclude( Expression<Func<T, bool>> ?filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> ?orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
           return _context.Set<T>().Where(condition).AsNoTracking();
        }

        public void Save()
        {
             _context.SaveChanges();
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}