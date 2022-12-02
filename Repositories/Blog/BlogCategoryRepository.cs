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
    public class BlogCategoryRepository:RepositoryBase<BlogCategoryModel, Entities.AppDbContext>,IBlogCategoryRepository
    {
        public BlogCategoryRepository(Entities.AppDbContext context) : base(context) { }
    }
}
