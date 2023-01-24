using Backend.Common.Requests;
using Backend.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponse> LoginAsync(LoginRequest request);
        Task<bool> ChangePasswordAsync(Guid userId, UserChangePasswordRequest request);
        Task<string> ValidUserAsync(Guid id);
    }
}
