using Backend.Common.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Entities
{
    [Table("BlogComment", Schema = SchemaConstants.Blog)]
    public class BlogComment: EntityBase
    {
        [ForeignKey("BlogId")]
        public Guid BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        [ForeignKey("ParentId")]
        public Guid? ParentId { get; set; }
        public virtual BlogComment ParentComment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
        public int VoteComment { get; set; }
    }
}
