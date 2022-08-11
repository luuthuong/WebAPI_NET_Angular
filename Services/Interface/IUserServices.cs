using DTO.UserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserServices
    {
        Task<IdentityResult> RegisterUser(RegisterUserRequest user);
        Task<bool> DeleteUser(string Id);
        Task<bool> UpdateUser(string id, UpdateUserRequest request);
        IEnumerable<UserDTOModel> GetAllUsers();
        Task<UserDTOModel?> GetUserById(string id);
        IEnumerable<Claim>? GetUserClaim();
    }
}
