using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Post",Schema ="Blog")]
    public class PostModel
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public string? AuthorId { get; set; }
        public virtual UserModel? User { get; set; }

        public string? ParentId { get; set; }
        public virtual PostModel? PostParent { get; set; }

        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        [Required]
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public bool? Published { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Content { get; set; }
    }
}
