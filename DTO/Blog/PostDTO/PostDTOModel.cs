using Entities.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PostDTO
{
    public class PostDTOModel
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

        public PostDTOModel()
        {

        }

        public PostDTOModel ToDomain(PostModel post)
        {
            return new PostDTOModel
            {
                Id = post.Id,
                ParentId = post.ParentId,
                AuthorId = post.AuthorId,
                Title = post.Title,
                MetaTitle = post.MetaTitle,
                Slug = post.Slug,
                Content = post.Content,
                Summary = post.Summary,
                CreatedDate = post.CreatedDate,
                Published = post.Published ,
                PublishedDate = post.PublishedDate,
                UpdatedDate = post.UpdatedDate
            };
        }
    }
}
