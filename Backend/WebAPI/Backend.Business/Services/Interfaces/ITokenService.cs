using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Interfaces
{
    public interface ITokenService
    {
        string JwtToken { get; }
        string GenerateJwtToken(User user, IEnumerable<string> roles);
        RefreshToken GenerateRefreshToken(Guid userId);
        Task<AuthenticationResponse> RefreshToken(RefreshTokenRequest request, IList<string> roles);
        Task<bool> RevokeToken(RefreshTokenRequest token);
        ClaimsPrincipal GetPrincipalFromToken(string token, bool isCheckExpired = false);
    }
}
