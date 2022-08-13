﻿using Microsoft.AspNetCore.Http;
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
        public string? FileName { get; set; }
        public IFormFile? File { get; set; }
        public string? FileCategoryId { get; set; }
    }
}
