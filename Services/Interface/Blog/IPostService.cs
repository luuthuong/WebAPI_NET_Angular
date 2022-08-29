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

        PostDTOModel? GetPostById(string id);

        bool CreateNewPost(CreatePostRequest request);

        bool UpdatePost(string Id,UpdatePostRequest request);

        Task<bool> DeletePost( IEnumerable<string> ids, bool includeChilren = false);

        Task<bool> DeletePostOfAuthor(string authorId, bool includeChilren = false);

        Task<bool> DeletePostOfCategory(string categoryId, bool includeChilren = false);

    }
}
