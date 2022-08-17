using DTO.FileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.MediaCategoryDTO
{
    public class GetFilesInCategoryDTOModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<FileDTOModel>? Files { get; set; }
    }
}
