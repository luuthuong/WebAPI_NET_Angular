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
    [Table("Type",Schema =Schema.Shop)]
    public class ShopTypeModel
    {
        [Key]
        public string? Id { get; set; }
        [MaxLength(75),Required]
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
