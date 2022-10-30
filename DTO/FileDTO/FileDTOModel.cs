using DTO.MediaCategoryDTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FileDTO
{
    public class FileDTOModel
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
        public string? FileUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? Size { get; set; }
        public IEnumerable<string?>? FileCategoryIds { get; set; }
    }
}
