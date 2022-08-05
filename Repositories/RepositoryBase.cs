using Entities;
using Repositories.Interface;
using System.Linq.Expressions;

namespace Repositories
{
    public class RepositoryBase<T,Context> : IRepositoryBase<T>
    {
        private readonly IdentityUserContext _context;
        public RepositoryBase(Context context)
        {
            _context = context;
        }
        public bool Create(T entity)
        {

        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}