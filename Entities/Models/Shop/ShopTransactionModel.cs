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
    [Table("Transaction",Schema =Schema.Shop)]
    public class ShopTransactionModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        public virtual UserModel? User { get; set; }
        [Required]
        public string? OrderId { get; set; }
        public virtual ShopOrderModel? Order { get; set; }
        [Required,MaxLength(50)]
        public string? Code { get; set; }
        public uint? Type { get; set; }
        public uint? Mode { get; set; }
        public uint? Status { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
