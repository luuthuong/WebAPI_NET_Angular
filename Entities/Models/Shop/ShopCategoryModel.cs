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
    [Table("Category",Schema =Schema.Shop)]
    public class ShopCategoryModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public virtual ShopCategoryModel? Parent { get; set; }
        [Required,MaxLength(75)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? MetaName { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
    }
}
