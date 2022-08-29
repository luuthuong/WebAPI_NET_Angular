using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PostDTO
{
    public class SearchPostRequest
    {
        public string? AuthorId { get; set; }
        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public string? MetaTile { get; set; }
        public bool? Published { get; set; } = false;
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
