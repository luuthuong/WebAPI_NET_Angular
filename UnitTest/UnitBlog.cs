using Common;
using DTO.PostDTO;
using Entities;
using Entities.Models.Blog;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repositories.Blog;
using Repositories.Interface;
using Repositories.Interface.Blog;
using Services.Blog;
using Services.Interface.Blog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Token;
using Token.Interface;

namespace UnitTest
{
    public class UnitBlog
    {
        private IPostRepository _postRepository;
        private IPostService _postService;
        [SetUp]
        public void Setup()
        {
            _postRepository = new PostRepository(new IdentityUserContext(new DbContextOptions<IdentityUserContext>()));
            _postService = new PostService(
                new Mock<IPostRepository>().Object, 
                new Mock<ITokenService>().Object, 
                new Mock<IPostCategoryRepository>().Object, 
                new Mock<IBlogCategoryRepository>().Object, 
                new Mock<IUserRepository>().Object);
        }
        [Test]
        public void getAllBlog()
        {
            var result = _postService.GetAllPost();
            Assert.Pass(JSONManager.ConvertToJson(result));
        }
        //[Test]
        //public void CreateBlog()
        //{
        //    var request = new CreatePostRequest
        //    {
        //        Title = "test title",
        //        MetaTitle = "This is meta title",
        //        Content = "asdasdas",
        //        Slug = "asdasd",
        //        Summary = "asdasdas"
        //    };
        //    bool result = _postService.CreateNewPost(request);
        //    Assert.That(result, Is.EqualTo(true));
        //}
    }
}
