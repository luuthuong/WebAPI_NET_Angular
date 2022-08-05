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
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        void Save();
    }
}
