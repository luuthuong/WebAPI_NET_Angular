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
    [Table("ProductReview",Schema = Schema.Shop)]
    public class ProductReviewModel
    {
        [Key]
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public virtual ProductReviewModel? Parent { get; set; }
        public string? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [Required,MaxLength(100)]
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Like { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }

    }
}
