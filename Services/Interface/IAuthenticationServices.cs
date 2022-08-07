using DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAuthenticationServices
    {
        Task<AuthenticatedResponseDTO?> Login(LoginDTO login);
        Task<AuthenticatedResponseDTO?> RefreshToken(AuthenticatedResponseDTO token);
    }
}
