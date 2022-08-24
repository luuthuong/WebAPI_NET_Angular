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
    [Table("FileMedia",Schema = Schema.Shop)]
    public class ShopFileMedia
    {
        [Key]
        public string? Id { get; set; }
        [Required,MaxLength(150)]
        public string? Name { get; set; }
        public string? File { get; set; }
        public string? FileUrl { get; set; }
        public int? Size { get; set; }
        public string? CreatedDate { get; set; }
    }
}
