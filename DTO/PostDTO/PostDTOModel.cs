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
        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public bool? Published { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Content { get; set; }

        public PostDTOModel()
        {

        }

        public PostDTOModel ToDomain()
        {
            return new PostDTOModel();
        }
    }
}
