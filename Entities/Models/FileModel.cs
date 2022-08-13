using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("FileMedia")]
    public class FileModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public ushort? Type { get; set; }

        [Required]
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageURL { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<MediaCategoryModel>? Categories { get; set; }

        //public FileModel()
        //{
        //    Categories = new HashSet<MediaCategoryModel>();
        //}
    }
}
