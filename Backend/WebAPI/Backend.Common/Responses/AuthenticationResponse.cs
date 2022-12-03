using Backend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Responses
{
    public  class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public AuthenticationResponse(UserModel user, string jwtToken, string refreshToken, IEnumerable<string> roles)
        {
            Id= user.Id;
            DisplayName= user.DisplayName;
            Token = jwtToken;
            RefreshToken= refreshToken;
            Roles= roles;
        }
    }
}
