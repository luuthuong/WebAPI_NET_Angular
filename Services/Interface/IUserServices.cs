using DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserServices
    {
        Task<IdentityResult> RegisterUser(UserRegisterDTO user);
        bool DeleteUser();
        bool UpdateUser();
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO? GetUserById(string id);
    }
}
