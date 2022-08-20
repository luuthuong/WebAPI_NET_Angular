using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PostCategory",Schema = Schema.Blog)]
    public class PostCategoryModel
    {
        public string? PostId { get; set; }
        public virtual PostModel? Post { get; set; }

        public string? CategoryId { get; set; }
        public virtual BlogCategoryModel? Category { get; set; }
    }
}
