using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MediaCategoryDTO
{
    public class GetFilesInCategoryRequest
    {
        public string? Id { get; set; }
        public bool IncludeSubFolder { get; set; } = false;
    }
}
