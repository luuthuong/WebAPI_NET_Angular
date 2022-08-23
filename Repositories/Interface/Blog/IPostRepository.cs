using Entities.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface.Blog
{
    public interface IPostRepository:IRepositoryBase<PostModel>
    {
    }
}
