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
    public class FileMediaRepository : RepositoryBase<FileModel, RepositoryContext>, IFileMediaRepository
    {
        public FileMediaRepository(RepositoryContext context) : base(context){ }
    }
}
