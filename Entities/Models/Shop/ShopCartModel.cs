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
    [Table("Cart",Schema = Schema.Shop)]
    public class ShopCartModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        public virtual UserModel? User { get; set; }
        public uint? Status { get; set; }
        [Required,MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        [Required, MaxLength(15)]
        public string? Phone { get; set; }
        [Required, MaxLength(50)]
        public string? Email { get; set; }
        [Required, MaxLength(100)]
        public string? Adress { get; set; }
        public string? AdressPrimary { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [Required, MaxLength(50)]
        public string? Province { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
