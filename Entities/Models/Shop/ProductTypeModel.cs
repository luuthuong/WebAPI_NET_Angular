using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shop
{
    [Table("ProductType",Schema = Schema.Shop)]
    public class ProductTypeModel
    {
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        public string? TypeId { get; set; }
        public virtual ShopTypeModel? Type { get; set; }
    }
}
