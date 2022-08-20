using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PostComment",Schema = Schema.Blog)]
    public class PostCommentModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? PostId { get; set; }
        public virtual PostModel? Post { get; set; }
        public string? ParentId { get; set; }
        public virtual PostCommentModel? ParentComment { get; set; }

        [MaxLength(100),Required]
        public string? Title { get; set; }
        public bool? Published { get; set; }
        public string? Content { get; set; }
        [Required]
        public DateTime? TimeStamp { get; set; }
        [Required]
        public int CommentCount { get; set; }
        public int VoteCount { get; set; }
    }
}
