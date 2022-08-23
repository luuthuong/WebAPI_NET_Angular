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
    [Table("ProductMeta",Schema =Schema.Shop)]
    public class ProductMetaModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [Required,MaxLength(50)]
        public string? Key { get; set; }
        public string? Content { get; set; }
    }
}
