using DTO;
using Entities.Models;
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

namespace Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly IConfiguration _config;
        public AuthenticationServices(
            SignInManager<UserModel> signInManager,
            UserManager<UserModel> userManager,
            IConfiguration config
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }
        public async Task<JwtSecurityToken?> Login(LoginDTO login)
        {
            var user = new UserModel();
            if (login.UserName != null) {
                user = await _userManager.FindByNameAsync(login.UserName);
            }
            else if (login.Email != null && login.Email.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(login.Email);
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password,login.IsRemember,lockoutOnFailure:false);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                foreach (var item in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, item));
                }
                var token = GetToken(authClaims);
                return token;
            }
            
            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:JWTTokenKey"]));
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}
