using AutoMapper;
using Backend.Business.Services.Interfaces;
using Backend.Common.Constants;
using Backend.Common.Models;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
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

        public TokenService(AppDbContext dbContext, ILogger<TokenService> logger, IMapper mapper, IConfigurationService configuration) : base(dbContext, logger, mapper)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration.JWTTokenKey);
            var phone = user.PhoneNumber?.ToString() ?? string.Empty;
            var claimIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, string.Join(",", roles)),
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

        public async Task<AuthenticationResponse> RefreshToken(string token, IList<string> roles)
        {
            var user = DBContext.Users.SingleOrDefault(usr => usr.RefreshTokens.Any(t => t.Token == token));
            if (user == null) return null;
            var refreshToken = await DBContext.RefreshTokens.FirstOrDefaultAsync(t => t.UserId == user.Id && t.Token == token);
            if(!refreshToken.IsActive) return null;
            var newRefreshToken = GenerateRefreshToken(user.Id);
            newRefreshToken.OriginalToken = refreshToken.OriginalToken;
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            DBContext.RefreshTokens.Add(newRefreshToken);
            await DBContext.SaveChangesAsync();
            var jwtToken = GenerateJwtToken(user, roles);
            var userModel = Mapper.Map<User, UserModel>(user);
            return new AuthenticationResponse(userModel, jwtToken, refreshToken.Token, roles);
        }

        public async Task<bool> RevokeToken(string token)
        {
            var user = await DBContext.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(usr => usr.RefreshTokens.Any(t => t.Token == token));
            if (user == null) return false;
            var refreshToken = user.RefreshTokens.Single(x=>x.Token== token);
            if (!refreshToken.IsActive) return false;
            refreshToken.Revoked = DateTime.UtcNow;
            return await DBContext.SaveChangesAsync() > 0;
        }
    }
}
