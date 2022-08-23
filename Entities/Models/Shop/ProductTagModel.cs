using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shop
{
    [Table("ProductTag",Schema = Schema.Shop)]
    public class ProductTagModel
    {
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        public string? TagId { get; set; }
        public virtual ShopTagModel? Tag { get; set; }
    }
}
