using DTO.PostDTO;
using Repositories.Interface.Blog;
using Services.Interface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Blog
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> CreateNewPost(CreatePostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePost(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostOfAuthor(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostOfCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTOModel> GetAllPost()
        {
            throw new NotImplementedException();
        }

        public PostDTOModel GetPostById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTOModel> GetPostOfAuthor(string authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTOModel> GetPostOfCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTOModel> SearchPost(SearchPostRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePost(UpdatePostRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
