using Entities;
using Entities.Models.Blog;
using Repositories.Interface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Blog
{
    public class PostMetaRepository:RepositoryBase<PostMetaModel, Entities.AppDbContext>,IPostMetaRepository
    {
        public PostMetaRepository(Entities.AppDbContext context) : base(context) {       }
    }
}
