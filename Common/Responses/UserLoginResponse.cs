using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class UserLoginResponse
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? RefreshToken { get; set; }
    }
}
