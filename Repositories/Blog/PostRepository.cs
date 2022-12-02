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
    public class PostRepository : RepositoryBase<PostModel, Entities.AppDbContext>, IPostRepository
    {
        public PostRepository(Entities.AppDbContext context) : base(context){}
    }
}
