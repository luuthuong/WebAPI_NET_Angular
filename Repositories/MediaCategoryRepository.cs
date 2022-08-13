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
    public class MediaCategoryRepository:RepositoryBase<MediaCategoryModel,RepositoryContext>,IMediaCategoryRepository
    {
        public MediaCategoryRepository(RepositoryContext context) : base(context) {}
        
    }
}
