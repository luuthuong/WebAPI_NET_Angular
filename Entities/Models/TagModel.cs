using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Tag",Schema ="Blog")]
    public class TagModel
    {
        [Key]
        public string? Id { get; set; }

        [Required,MaxLength(75)]
        public string? Name { get; set; }
        public string? MetaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
    }
}
