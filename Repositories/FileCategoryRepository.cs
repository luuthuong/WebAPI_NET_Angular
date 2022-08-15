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
    public class FileCategoryRepository : RepositoryBase<FileCategoryModel, RepositoryContext>, IFileCategoryRepository
    {
        public FileCategoryRepository(RepositoryContext context) : base(context){}
    }
}
