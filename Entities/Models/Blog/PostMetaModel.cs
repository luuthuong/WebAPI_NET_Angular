using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Blog
{
    [Table("PostMeta", Schema = Schema.Blog)]
    public class PostMetaModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? PostId { get; set; }
        public virtual PostModel? Post { get; set; }

        [MaxLength(50)]
        public string? Key { get; set; }
        public string? Content { get; set; }
    }
}
