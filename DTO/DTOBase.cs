using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOBase
    {
        public string? Id { get; set; }
    }

    public class ResponseBaseDTO<T>
    {
        public int? Status { get; set; }
        public string? Message { get; set; }
        public T? Response { get; set; }
    }
    public class ResponseBaseDTO
    {
        public int? Status { get; set; }
        public string? Message { get; set; }
    }
}
