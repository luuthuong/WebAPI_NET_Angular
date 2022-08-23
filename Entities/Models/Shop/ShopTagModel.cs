using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shop
{
    [Table("Tag",Schema = Schema.Shop)]
    public class ShopTagModel
    {
        [Key]
        public string? Id { get; set; }
        [Required,MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? MetaName { get; set; }
        [Required,MaxLength(50)]
        public string? Slug { get; set; }
        public string? Content { get; set; }
    }
}
