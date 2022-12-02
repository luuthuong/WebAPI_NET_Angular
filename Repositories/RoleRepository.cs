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
    public class RoleRepository : RepositoryBase<RoleModel, Entities.AppDbContext>, IRoleRepository
    {
        public RoleRepository(Entities.AppDbContext context) : base(context){}
    }
}
