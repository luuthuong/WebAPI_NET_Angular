using AutoMapper;
using Backend.Business.Services.Interfaces;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.DBContext;
using Backend.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Services
{
    public class AuthService :ServiceBase, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthService(AppDbContext dBContext, 
            ILogger<AuthService> logger, 
            IMapper mapper, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager) : base(dBContext, logger, mapper) {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public Task<bool> ChangePasswordAsync(Guid userId, UserChangePasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserLoginResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogOutAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RevokeToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
