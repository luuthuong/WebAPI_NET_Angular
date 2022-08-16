using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IRepositoryBase<T>
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> GetByCondition(Expression<Func<T,bool>> condition);
        IEnumerable<T> GetAllWithInclude(Expression<Func<T, bool>> ?filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> ?orderBy = null, string includeProperties = "");
        bool Create(T entity);
        Task<bool> CreateRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool Delete(T entity);
        Task<bool> DeleteRange(IEnumerable<T> entities);
        void Save();
    }
}
