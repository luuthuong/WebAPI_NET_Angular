using Entities.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Blog.PostDTO
{
    public class PostDetailDTOModel
    {
        public string? Id { get; set; }
        public string? AuthorId { get; set; }

        public string? AuthorName { get; set; }
        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public bool? Published { get; set; }

        public IEnumerable<string?>? CategoryNames { get; set; }
        public IEnumerable<string?>? CategoryIds { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Content { get; set; }

        public PostDetailDTOModel ToDomain(PostModel post)
        {
            return new PostDetailDTOModel
            {
                Id = post.Id,
                ParentId = post.ParentId,
                AuthorId = post.AuthorId,
                Title = post.Title,
                MetaTitle = post.MetaTitle,
                Content = post.Content,
                Slug = post.Slug,
                Summary = post.Summary,
                CreatedDate = post.CreatedDate,
                Published = post.Published,
                PublishedDate = post.PublishedDate,
                UpdatedDate = post.UpdatedDate
            };
        }
    }
}
