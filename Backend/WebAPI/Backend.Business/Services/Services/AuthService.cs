using AutoMapper;
using Backend.Business.Services.Interfaces;
using Backend.Common.Requests;
using Backend.Common.Responses;
using Backend.DBContext;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Services
{
    public class AuthService : ServiceBase, IAuthService
    {
        public AuthService(AppDbContext dBContext, ILogger logger, IMapper mapper) : base(dBContext, logger, mapper){}

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
