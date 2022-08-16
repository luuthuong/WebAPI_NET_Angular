using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FileDTO
{
    public class UpdateFileRequest
    {
        public string? FileId { get; set; }
        public IEnumerable<string>? CategoryIds { get; set; }
    }
}
