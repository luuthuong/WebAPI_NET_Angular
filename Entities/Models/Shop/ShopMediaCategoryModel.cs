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
    [Table("MediaCategory",Schema = Schema.Shop)]
    public class ShopMediaCategoryModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
