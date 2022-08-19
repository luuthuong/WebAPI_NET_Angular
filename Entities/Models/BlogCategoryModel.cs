using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Category",Schema ="Blog")]
    public class BlogCategoryModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public virtual BlogCategoryModel? Parent { get; set; }

        [Required,MaxLength(150)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? MetaTitle { get; set; }

        [MaxLength(200)]
        public string? Slug { get; set; }
    }
}
