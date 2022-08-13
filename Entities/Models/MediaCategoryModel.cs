using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("CategoryMedia")]
    public class MediaCategoryModel
    {
        [Key]
        public string? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<FileModel>? FilesMedia { get; set; }

        public MediaCategoryModel()
        {
            FilesMedia = new HashSet<FileModel>();
        }

    }
}
