using Entities;
using Entities.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoleRepository : RepositoryBase<RoleModel, IdentityUserContext>, IRoleRepository
    {
        public RoleRepository(IdentityUserContext context) : base(context){}
    }
}
