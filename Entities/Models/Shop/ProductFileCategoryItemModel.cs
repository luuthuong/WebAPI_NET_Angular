using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Shop
{
    [Table("ProductFileCategoryItem",Schema = Schema.Shop)]
    public class ProductFileCategoryItemModel
    {
        public string? CategoryId { get; set; }
        public virtual ShopMediaCategoryModel? MediaCategory { get; set; }

        public string? FileMediaId { get; set; }
        public virtual ShopFileMedia? FileMedia { get; set; }
    }
}
