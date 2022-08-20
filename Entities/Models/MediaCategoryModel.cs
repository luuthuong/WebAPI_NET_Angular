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
    [Table("Category",Schema =Schema.Media)]
    public class MediaCategoryModel
    {
        [Key]
        public string? Id { get; set; }

        public string? ParentId { get; set; }
        public virtual MediaCategoryModel? Parent { get; set; }

        [Required]
        public string? UserId { get; set; }
        public virtual UserModel? User { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
