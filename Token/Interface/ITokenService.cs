using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Token.Interface
{
    public interface ITokenService
    {
        string? GenerateAccessToken(IEnumerable<Claim> claims);

        string? GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromToken(string token, bool checkExpiredTime = false);

        //ClaimsPrincipal ValidateJwtToken(string token);

        string GetCurrentToken();

        bool ResolveCredentialViaToken();

        string ResolveUserId();

        string ResolveUserName();

        string ResolveUserEmail();

        string ValidateAndResolveUserId(string token);
        string ValidateAndResolveUserName(string token);

    }
}
