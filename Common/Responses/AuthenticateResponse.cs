using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string? RefreshToken { get; set; }

        public AuthenticateResponse(UserModel user, string jwtToken, string refreshToken) { 
            DisplayName = user.DisplayName ?? string.Empty; 
            Token = jwtToken; 
            RefreshToken = refreshToken;
        }
    }
}
