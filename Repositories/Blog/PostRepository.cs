using Entities;
using Entities.Models;
using Repositories.Interface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Blog
{
    public class PostRepository : RepositoryBase<PostModel, IdentityUserContext>, IPostRepository
    {
        public PostRepository(IdentityUserContext context) : base(context){}
    }
}
