using Entities;
using Entities.Models.Media;
using Repositories.Interface;
using Repositories.Interface.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Media
{
    public class FileCategoryRepository : RepositoryBase<FileCategoryModel, IdentityUserContext>, IFileCategoryRepository
    {
        public FileCategoryRepository(IdentityUserContext context) : base(context) { }
    }
}
