using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shop
{
    [Table("ProductCategory",Schema = Schema.Shop)]
    public class ProductCategoryModel
    {
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        public string? CategoryId { get; set; }
        public virtual ShopCategoryModel? Category { get; set; }
    }
}
