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
    public class UserRepository : RepositoryBase<UserModel, IdentityUserContext>, IUserRepository
    {
        public UserRepository(IdentityUserContext context) : base(context){ }
    }
}
