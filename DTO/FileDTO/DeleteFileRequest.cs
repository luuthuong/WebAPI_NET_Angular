﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FileDTO
{
    public class DeleteFileRequest
    {
        public IEnumerable<string>? IdFile { get; set; }
    }
}
