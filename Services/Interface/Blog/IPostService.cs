using DTO.PostDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface.Blog
{
    public interface IPostService
    {
        IEnumerable<PostDTOModel> GetAllPost();
        IEnumerable<PostDTOModel> GetPostOfAuthor(string authorId);
        IEnumerable<PostDTOModel> GetPostOfCategory(string categoryId);
        IEnumerable<PostDTOModel> SearchPost(SearchPostRequest request);
        PostDTOModel GetPostById(string id);
        Task<bool> CreateNewPost(CreatePostRequest request);
        Task<bool> UpdatePost(UpdatePostRequest request);
        Task<bool> DeletePost(IEnumerable<string> ids);
        Task<bool> DeletePostOfAuthor(string authorId);
        Task<bool> DeletePostOfCategory(string categoryId);
    }
}
