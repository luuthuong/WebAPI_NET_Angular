using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Responses
{
    public class UserLoginResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
