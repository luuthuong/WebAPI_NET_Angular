using AutoMapper;
using Backend.Business.Services.Interfaces;
using Backend.Common.Constants;
using Backend.Common.Models;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Services
{
    public class TokenService : ServiceBase, ITokenService
    {
        private readonly IConfigurationService _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenService(AppDbContext dbContext, ILogger<TokenService> logger, IMapper mapper, IConfigurationService configuration, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, mapper)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(_configuration));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(_httpContextAccessor));
        }

        public string JwtToken
        {
            get
            {
                var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers.Authorization.Single();
                return authorizationHeader?.Split(" ").Last() ?? string.Empty;
            }
        }

        public string GenerateJwtToken(User user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration.JWTTokenKey);
            var phone = user.PhoneNumber?.ToString() ?? string.Empty;
            var claimIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypeConstants.Role, string.Join(",", roles)),
                new Claim(ClaimTypeConstants.Email, user?.Email ?? string.Empty),
                new Claim(ClaimTypeConstants.PhoneNumber, phone),
                new Claim(ClaimTypeConstants.UserId, user.Id.ToString())
            });
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(Guid userId)
        {
            using(var rng = RandomNumberGenerator.Create())
            {
                var randomBytes = new byte[64];
                rng.GetBytes(randomBytes);
                return new RefreshToken
                {
                    UserId= userId,
                    Token = Convert.ToBase64String(randomBytes),
                    Expires= DateTime.UtcNow.AddDays(1),
                    Created= DateTime.UtcNow
                };
            }
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token, bool isCheckExpired = false)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JWTTokenKey));
            var tokenValidationParameter = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = isCheckExpired,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = isCheckExpired
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out SecurityToken validatedToken);
            var jwtSecurityToken = validatedToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return principal;
        }

        public async Task<AuthenticationResponse> RefreshToken(RefreshTokenRequest request, IList<string> roles)
        {
            var user = DBContext.Users.SingleOrDefault(usr => usr.RefreshTokens.Any(t => t.Token == request.RefreshToken));
            if (user == null) return null;
            var refreshToken = await DBContext.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.Token == request.RefreshToken);
            if(refreshToken.Expires< DateTime.UtcNow || !refreshToken.IsActive) throw new SecurityTokenExpiredException("Token invalid or was expried");

            var newRefreshToken = GenerateRefreshToken(user.Id);
            newRefreshToken.OriginalToken = refreshToken.OriginalToken;  
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            DBContext.RefreshTokens.Add(newRefreshToken);
            await DBContext.SaveChangesAsync();
            var jwtToken = GenerateJwtToken(user, roles);
            var userModel = Mapper.Map<User, UserModel>(user);
            return new AuthenticationResponse(userModel, jwtToken, newRefreshToken.Token, roles);
        }

        public async Task<bool> RevokeToken(RefreshTokenRequest token)
        {
            var user = await DBContext.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(usr => usr.RefreshTokens.Any(t => t.Token == token.RefreshToken));
            if (user == null) throw new SecurityTokenException("token invalid");
            var refreshToken = user.RefreshTokens.Single(x=> x.Token == token.RefreshToken);
            if (!refreshToken.IsActive) throw new SecurityTokenException("token was expired");
            refreshToken.Revoked = DateTime.UtcNow;
            return await DBContext.SaveChangesAsync() > 0;
        }
    }
}
