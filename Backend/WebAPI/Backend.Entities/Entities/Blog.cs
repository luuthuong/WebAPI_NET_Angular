using Backend.Common.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Entities
{
    [Table("Blog", Schema = SchemaConstants.Blog)]
    public class Blog: EntityBase
    {
        public string Content { get; set; }
        public string Description { get; set; }
        public Guid CreateBy { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get;set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public Guid? UpdateBy { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public virtual BlogCategory? Category { get; set; }
    }
}
