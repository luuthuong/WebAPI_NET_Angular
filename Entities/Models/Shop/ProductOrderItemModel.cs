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
    [Table("ProductOrderItem",Schema = Schema.Shop)]
    public class ProductOrderItemModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        public string? OrderId { get; set; }
        public virtual ShopOrderModel? Order { get; set; }
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
