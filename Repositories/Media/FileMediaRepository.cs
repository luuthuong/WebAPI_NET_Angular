using Entities;
using Entities.Models.Media;
using Repositories.Interface.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Media
{
    public class FileMediaRepository : RepositoryBase<FileModel, Entities.AppDbContext>, IFileMediaRepository
    {
        public FileMediaRepository(Entities.AppDbContext context) : base(context) { }
    }
}
