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
    [Table("Product", Schema = Schema.Shop)]
    public class ProductModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        public virtual UserModel? User { get; set; }
        [Required,MaxLength(250)]
        public string? Name { get; set; }
        public string? MetaTitle { get; set; }
        [Required,MaxLength(100)]
        public string? Slug { get; set; }
        public uint? Type { get; set; }
        [MaxLength(100)]
        public string? Sku { get; set; }
        [Required]
        public float? Price { get; set; }
        public float? Discount { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Content { get; set; }
    }
}
