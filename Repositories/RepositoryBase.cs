using Entities;
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

        public bool Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public IQueryable<T> GetAll()
        {
           return _context.Set<T>().AsQueryable().AsNoTracking();
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