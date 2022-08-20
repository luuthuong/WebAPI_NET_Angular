using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Token.Interface;

namespace Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly IClaimsTransformation _claimsInformation;
        public AuthenticationServices(
            SignInManager<UserModel> signInManager,
            UserManager<UserModel> userManager,
            ITokenService tokenService,
            IConfiguration config,
            IClaimsTransformation claimsTransformation
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _config = config;
            _claimsInformation = claimsTransformation;
        }
        public async Task<AuthenticatedResponseDTO?> Login(LoginDTO login)
        {
            await _signInManager.SignOutAsync();
            UserModel user = new UserModel();
            if (login.UserName != null) {
                user = await _userManager.FindByNameAsync(login.UserName);
            }
            else{
                user = await _userManager.FindByEmailAsync(login.Email);
            }

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, login.IsRemember, lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.UserData,user.Id),
                            new Claim(ClaimTypes.Name,user.UserName),
                            new Claim(ClaimTypes.Email,user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                        };
                    foreach (var item in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, item));
                    }
                    var token = _tokenService.GenerateAccessToken(authClaims);
                    var refreshToken = _tokenService.GenerateRefreshToken();
                    user.RefreshToken = refreshToken;
                    user.RefreshTokenExpiredTime = DateTime.Now.AddMinutes(30);
                    await _userManager.UpdateAsync(user);
                    return new AuthenticatedResponseDTO
                    {
                        AcessToken = token,
                        RefreshToken = refreshToken
                    };
                }
            }
            return null;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticatedResponseDTO?> RefreshToken(AuthenticatedResponseDTO token)
        {
            if (token.AcessToken == null)
                return null;
            var principle = _tokenService.GetPrincipalFromExpiredToken(token.AcessToken);
            var userName = principle.Identity?.Name ?? String.Empty;
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiredTime <= DateTime.UtcNow)
                throw new SecurityTokenException("Token invalid");

            var newAccessToken = _tokenService.GenerateAccessToken(principle.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiredTime = DateTime.Now.AddMinutes(30);
            await _userManager.UpdateAsync(user);
            return new AuthenticatedResponseDTO()
            {
                AcessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
