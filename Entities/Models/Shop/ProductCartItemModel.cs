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
    [Table("ProductCartItem",Schema =Schema.Shop)]
    public class ProductCartItemModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        public string? CartId { get; set; }
        public virtual ShopCartModel? Cart{get;set;}
        [MaxLength(100)]
        public string? Sku { get; set; }
        [Required]
        public int? Amount { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public float? Discount { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
