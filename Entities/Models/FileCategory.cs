using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("FileCategory")]
    public class FileCategory
    {
        public string? FileMediaId { get; set; }
        public FileModel? FileModel { get; set; }

        public string? CategoryId { get; set; }
        public MediaCategoryModel? MediaCategoryModel { get; set; }
    }
}
