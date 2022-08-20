using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? UserId { get; set; }
        public UserModel? User { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

    }
}
