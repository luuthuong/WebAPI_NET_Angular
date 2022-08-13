using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FileDTO
{
    public class CreateFileRequest
    {
        public ushort Type { get; set; }
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }   
        public string? FileUrl { get; set; }
        public string? FileCategoryId { get; set; }
    }
}
