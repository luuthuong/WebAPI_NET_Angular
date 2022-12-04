using AutoMapper;
using Backend.Business.Services.Interfaces;
using Backend.Common.Enums;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Services
{
    public class AuthService :ServiceBase, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfigurationService _configuration;
        private readonly ITokenService _tokenService;


        public AuthService(AppDbContext dBContext, 
            ILogger<AuthService> logger, 
            IMapper mapper, 
            UserManager<User> userManager, 
            IConfigurationService configuration,
            ITokenService tokenService,
            SignInManager<User> signInManager) : base(dBContext, logger, mapper) {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public Task<bool> ChangePasswordAsync(Guid userId, UserChangePasswordRequest request)
        {

            throw new NotImplementedException();
        }

        public async Task<UserLoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.Status == StatusEnum.Active && (usr.UserName == request.UserName || usr.Email == request.Email));
            var token = _tokenService.JwtToken;
            if(user == null)
            {
                return new UserLoginResponse()
                {
                    HttpStatusCode = HttpStatusCode.Unauthorized
                };
            }
            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if(loginResult.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var jwtToken = _tokenService.GenerateJwtToken(user, roles);
                var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
                DBContext.RefreshTokens.RemoveRange(DBContext.RefreshTokens.Where(x =>x.UserId == user.Id));
                DBContext.RefreshTokens.Add(refreshToken);
                await DBContext.SaveChangesAsync();
                return new UserLoginResponse()
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    HttpStatusCode = HttpStatusCode.OK,
                    RefreshToken = refreshToken.Token,
                    Token = jwtToken,
                    Roles = roles
                };
            }
            return new UserLoginResponse
            {
                HttpStatusCode = HttpStatusCode.Unauthorized
            };
        }

        public async Task<string> ValidUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return "Unauthorized";
            }
            return "";
        }

        public Task<bool> LogOutAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
