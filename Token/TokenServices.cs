using Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Token.Interface;

namespace Token
{

    public class TokenServices : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenServices(
             IConfiguration config,
             IHttpContextAccessor httpContextAccessor
             )
        {
            _config = config ?? throw new ArgumentNullException(nameof(_config));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(_httpContextAccessor));
        }

        public string? GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:JWTTokenKey"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signingCredentials
                );
            var token = tokenHandler.CanWriteToken ? tokenHandler.WriteToken(tokenOptions) : null;
            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public string GetCurrentToken()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["authorization"];
            return (string)authorizationHeader ==  string.Empty ? string.Empty : authorizationHeader.Single().Split(" ").Last();
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token, bool checkExpiredTime = false)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:JWTTokenKey"]));
            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = _config["JWT:ValidIssuer"],
                ValidAudience = _config["JWT:ValidAudience"],
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                IssuerSigningKey = secretKey,
                ValidateLifetime = checkExpiredTime,
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return principal;
        }

        public bool ResolveCredentialViaToken()
        {
            throw new NotImplementedException();
        }

        public string ResolveUserEmail()
        {
            string token = GetCurrentToken();
            ClaimsPrincipal principal = GetPrincipalFromToken(token, true);
            if (principal == null)
                throw new SecurityTokenException("Token invalid");
            var userEmail = principal.Claims.Where(claim => claim.Type == ClaimTypes.Email).Select(x => x.Value).FirstOrDefault();
            return userEmail ?? string.Empty;
        }

        public string ResolveUserId()
        {
            string token = GetCurrentToken();
            ClaimsPrincipal principal = GetPrincipalFromToken(token, true);
            if (principal == null)
                throw new SecurityTokenException("Token invalid");
            var userId = principal.Claims.Where(claim => claim.Type == JwtClaimTypes.UserId).Select(x=>x.Value).FirstOrDefault();
            return userId ?? string.Empty;
        }

        public string ResolveUserName()
        {
            string token = GetCurrentToken();
            ClaimsPrincipal principal = GetPrincipalFromToken(token, true);
            if (principal == null)
                throw new SecurityTokenException("Token Invalid");
            string? userName = principal.Claims.Where(claim => claim.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();
            return userName ?? String.Empty;
        }

        public string ValidateAndResolveUserId(string token)
        {
            throw new NotImplementedException();
        }

        public string ValidateAndResolveUserName(string token)
        {
            throw new NotImplementedException();
        }

        //public ClaimsPrincipal ValidateJwtToken(string token)
        //{
        //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:JWTTokenKey"]));
        //    var tokenValidatorParameter = new TokenValidationParameters()
        //    {
        //        ValidateAudience = true,
        //        ValidateActor = true,
        //        ValidateIssuer = true,
        //        ValidateLifetime = true,
        //        RequireExpirationTime = true,
        //        RequireSignedTokens = true,
        //        ValidIssuer = _config["JWT:ValidIssuer"],
        //        ValidAudience = _config["JWT:ValidAudience"],
        //        IssuerSigningKey = secretKey,
        //    };
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var principle = tokenHandler.ValidateToken(token, tokenValidatorParameter, out SecurityToken securityToken) ;
        //    var jwtSecurityToken = securityToken as JwtSecurityToken;
        //    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        throw new SecurityTokenException("Token invalid");
        //    return principle;
        //}
    }
}