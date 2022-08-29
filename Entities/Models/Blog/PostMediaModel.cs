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
    [Table("PostMedia",Schema = Schema.Blog)]
    public class PostMediaModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? Type { get; set; }

        [Required]
        public string? PostId { get; set; }
        public virtual PostModel? Post { get; set; }

        [Required]
        public string? Name { get; set; }
        public byte[]? SrcFile { get; set; }
        public string? FileURL { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
