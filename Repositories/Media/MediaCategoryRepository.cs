using Entities;
using Entities.Models;
using Repositories.Interface.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Media
{
    public class MediaCategoryRepository : RepositoryBase<MediaCategoryModel, IdentityUserContext>, IMediaCategoryRepository
    {
        public MediaCategoryRepository(IdentityUserContext context) : base(context) { }

    }
}
