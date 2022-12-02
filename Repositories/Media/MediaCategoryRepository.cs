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
    public class MediaCategoryRepository : RepositoryBase<MediaCategoryModel, Entities.AppDbContext>, IMediaCategoryRepository
    {
        public MediaCategoryRepository(Entities.AppDbContext context) : base(context) { }

    }
}
