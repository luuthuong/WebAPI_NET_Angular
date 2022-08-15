﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FileDTO
{
    public class CreateFileRequest
    {
        public IEnumerable<IFormFile>? File { get; set; }   
        public string? FileCategoryId { get; set; } 
    }
}
