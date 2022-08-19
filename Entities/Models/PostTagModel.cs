using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("PostTag",Schema ="Blog")]
    public class PostTagModel
    {
        public string? PostId { get; set; }
        public virtual PostModel? Post { get; set; }

        public string? TagId { get; set; }
        public virtual TagModel? Tag { get; set; }
    }
}
