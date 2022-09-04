using DTO.PostDTO;
using Entities.Models.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Repositories.Interface;
using Repositories.Interface.Blog;
using Services.Interface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Token.Interface;

namespace Services.Blog
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IPostCategoryRepository _categoryPostRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public PostService(
            IPostRepository repository,
            ITokenService tokenService,
            IPostCategoryRepository categoryRepository,
            IBlogCategoryRepository blogCategoryRepository,
            IUserRepository userRepository
            )
        {
            _repository = repository;
            _tokenService = tokenService;
            _categoryPostRepository = categoryRepository;
            _userRepository = userRepository;
            _blogCategoryRepository = blogCategoryRepository;
        }

        public bool CreateNewPost(CreatePostRequest request)
        {
            using (var transaction = _repository.Transaction())
            {
                var userId = _tokenService.ResolveUserId();

                if (userId == null) throw new ArgumentNullException(userId);
                PostModel post = new PostModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    AuthorId = userId,
                    Title = request.Title,
                    MetaTitle = request.MetaTitle,
                    Slug = request.Slug,
                    ParentId = request.ParentId,
                    Published = request.Published,
                    Content = request.Content,
                    Summary = request.Summary,
                    CreatedDate = DateTime.Now,
                };

                if (request.Published) 
                    post.PublishedDate = DateTime.Now;

                if (request.CategoryId?.Count() > 0)
                {
                    var postCategories = request.CategoryId.Select(item =>
                    {
                        var postCategory = new PostCategoryModel
                        {
                            CategoryId = item,
                            PostId = post.Id
                        };
                        return postCategory;
                    });
                    _categoryPostRepository.CreateRange(postCategories);
                }

                transaction.Commit();
                return _repository.Create(post);
            }
        }

        public async Task<bool> DeletePost( IEnumerable<string> ids, bool includeChilren)
        {
           var findPostResult = _repository.GetByCondition(item=>ids.Contains(item.Id)).ToList();
            foreach (var post in findPostResult)
            {
                var children = _repository.GetByCondition(x => x.ParentId == post.Id);
                if (includeChilren)
                {
                   await _repository.DeleteRange(children);
                }
                else
                {
                    children = children.ToList().Select(item =>
                    {
                        item.ParentId = null;
                        return item;
                    }).AsQueryable();
                    await _repository.UpdateRange(children);
                }
            }
           return await _repository.DeleteRange(findPostResult);
        }

        public async Task<bool> DeletePostOfAuthor(string authorId, bool includeChilren = false)
        {
            var findPostResult = _repository.GetByCondition(x => x.AuthorId == authorId);
            foreach (var post in findPostResult)
            {
                var children = _repository.GetByCondition(x => x.ParentId == post.Id);
                if (includeChilren)
                {
                    await _repository.DeleteRange(children);
                }
                else
                {
                    children = children.ToList().Select(item =>
                    {
                        item.ParentId = null;
                        return item;
                    }).AsQueryable();
                    await _repository.UpdateRange(children);
                }
            }
            return await _repository.DeleteRange(findPostResult) ;
        }

        public async Task<bool> DeletePostOfCategory(string categoryId, bool includeChilren = false)
        {
            var postCategory = _categoryPostRepository.GetByCondition(x => x.CategoryId == categoryId).Select(x => x.PostId).ToList();
            var findPostResult = _repository.GetByCondition(x => postCategory.Contains(x.Id));
            foreach (var post in findPostResult)
            {
                var children = _repository.GetByCondition(x => x.ParentId == post.Id);
                if (includeChilren)
                {
                    await _repository.DeleteRange(children);
                }
                else
                {
                    children = children.ToList().Select(item =>
                    {
                        item.ParentId = null;
                        return item;
                    }).AsQueryable();
                    await _repository.UpdateRange(children);
                }
            }
            return await _repository.DeleteRange(findPostResult);
        }

        public IEnumerable<PostDTOModel> GetAllPost()
        {
            var result = _repository.GetAll().ToList();
            var listPost = result.Select(x =>
            {
                var postDTO = new PostDTOModel().ToDomain(x);
                var userName = _userRepository.GetByCondition(usr => usr.Id == x.AuthorId).Select(usr=>usr.DisplayName).FirstOrDefault();
                var categoryPost = _categoryPostRepository.GetByCondition(item => item.PostId == x.Id).Include(item=>item.Category).Select(item=>item.Category).AsEnumerable();
                if(categoryPost != null)
                {
                    postDTO.CategoryIds = categoryPost.Select(item => item?.Id) ?? Enumerable.Empty<string>();
                    postDTO.CategoryNames = categoryPost.Select(item => item?.Name) ?? Enumerable.Empty<string>();
                }
                postDTO.AuthorName = userName ;
                return postDTO;
            });
            return listPost.OrderByDescending(x=>x.CreatedDate) ?? Enumerable.Empty<PostDTOModel>();
        }

        public PostDTOModel? GetPostById(string id)
        {
            var result = _repository.GetByCondition(x => x.Id == id).FirstOrDefault();
            if (result == null) return new PostDTOModel();
            var post = new PostDTOModel().ToDomain(result);
            return post;
        }

        public IEnumerable<PostDTOModel> GetPostChildren(string parentId)
        {
            var result = _repository.GetByCondition(x => x.ParentId == parentId).Select(x=> new PostDTOModel().ToDomain(x));
            return result.AsEnumerable() ?? Enumerable.Empty<PostDTOModel>();
            throw new NotImplementedException();
        }

        public IEnumerable<PostDTOModel> GetPostOfAuthor(string authorId)
        {
            var findPostResult = _repository.GetByCondition(x => x.AuthorId == authorId);
            return findPostResult.Select(x => new PostDTOModel().ToDomain(x));
        }

        public IEnumerable<PostDTOModel> GetPostOfCategory(string categoryId)
        {
            var postCategory = _categoryPostRepository.GetByCondition(x => x.CategoryId == categoryId).Select(x => x.PostId).ToList();
            var result = _repository.GetByCondition(x => postCategory.Contains(x.Id)).Select(x => new PostDTOModel().ToDomain(x));
            return result;
        }

        public IEnumerable<PostDTOModel> SearchPost(SearchPostRequest request)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePost(string Id, UpdatePostRequest request)
        {
            var result = _repository.GetByCondition(x => x.Id == Id).FirstOrDefault();
            var userId = _tokenService.ResolveUserId();
            if(userId == null) throw new ArgumentNullException(nameof(userId));

            if(result != null)
            {
                result.AuthorId = userId;
                result.ParentId = request.ParentId;
                result.Title = request.Title;
                result.MetaTitle = request.MetaTitle;
                result.Slug = request.Slug;
                result.Summary = request.Summary;
                result.Content = request.Content;
                result.Published = request.Published;
                result.UpdatedDate = DateTime.Now;
                return _repository.Update(result);
            }
            return false;
        }
    }
}
