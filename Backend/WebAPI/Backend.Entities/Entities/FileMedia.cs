using Backend.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Entities
{
    [Table("File", Schema = SchemaConstants.Media)]
    public class FileMedia: EntityBase
    {
        [Required]
        public string Extension { get;set; }
        [Required]
        public string Title { get; set; } 
        public byte[] FileContent { get; set; }
        public double Size { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid CreatedBy { get; set; }
        public virtual ICollection<FileCategory> FileCategories { get; set; }
    }
}
