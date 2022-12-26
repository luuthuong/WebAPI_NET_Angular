using Backend.Common.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Entities
{
    [Table("BlogCategory", Schema = SchemaConstants.Blog)]
    public class BlogCategory: EntityBase
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Slug { get; set; }
        public string MetaTitle { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public Guid? ParentId { get; set; }
        public virtual BlogCategory Parent { get; set; }
    }
}
