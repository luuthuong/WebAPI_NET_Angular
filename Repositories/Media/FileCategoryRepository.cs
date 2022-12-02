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
    public class FileCategoryRepository : RepositoryBase<FileCategoryModel, Entities.AppDbContext>, IFileCategoryRepository
    {
        public FileCategoryRepository(Entities.AppDbContext context) : base(context) { }
    }
}
