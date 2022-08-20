﻿using Entities;
using Entities.Models;
using Repositories.Interface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Blog
{
    public class PostCategoryRepository:RepositoryBase<PostCategoryModel,IdentityUserContext>,IPostCategoryRepository
    {
        public PostCategoryRepository(IdentityUserContext context) : base(context) { }
    }
}
