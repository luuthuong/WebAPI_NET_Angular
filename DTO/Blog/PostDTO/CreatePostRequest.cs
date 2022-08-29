using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PostDTO
{
    public class CreatePostRequest
    {
        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public IEnumerable<string>? CategoryId { get; set; }
        public string? MetaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public bool Published { get; set; } = false;
        public string? Content { get; set; }
    }
}
