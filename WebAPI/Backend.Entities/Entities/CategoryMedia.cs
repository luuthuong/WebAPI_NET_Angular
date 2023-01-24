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
    [Table("CategoryMedia", Schema = SchemaConstants.Media)]
    public class CategoryMedia: EntityBase
    {
        public Guid? ParentId { get; set; }
        public virtual CategoryMedia Parent { get; set; }
        [Required]
        public string Name { get;set; }
        public string Description { get;set; }
        public DateTime CreateDate { get;set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<FileCategory> FileCategories { get; set; }
        [ForeignKey("CreateBy")]
        public Guid CreateBy { get; set; }
        public User User { get; set; }
    }
}
