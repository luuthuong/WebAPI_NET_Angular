using Entities;
using Entities.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityUserContext _context;
        public UserRepository(IdentityUserContext context)
        {
            _context = context;
        }
        public bool Create(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> GetByCondition(Expression<Func<UserModel, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
