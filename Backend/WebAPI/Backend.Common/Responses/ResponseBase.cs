using Backend.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Responses
{
    public class ResponseBase<T>
    {
        public ResponseStatusEnum ResponseStatus { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
