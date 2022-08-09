using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<UserModel> _userManager;
        public UserServices(IUserRepository repository, UserManager<UserModel> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public bool DeleteUser()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTOModel> GetAllUsers()
        {
            List<UserDTOModel> listUser = new List<UserDTOModel>();
            var result =  _repository.GetAll().AsEnumerable();
            foreach (var item in result)
            {
                var user = new UserDTOModel
                {
                    Email = item.Email,
                    Id = item.Id,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber
                };
                listUser.Add(user);
            }
            return listUser;
        }

        public UserDTOModel? GetUserById(string id)
        {
            var result = _repository.GetByCondition(x => x.Id == id).FirstOrDefault();
            if (result == null)
                return null;
            UserDTOModel user = new UserDTOModel
            {
                Email = result.Email,
                Id = result.Id,
                UserName = result.UserName,
                PhoneNumber = result.PhoneNumber
            };
            return user;
        }

        public IEnumerable<Claim>? GetUserClaim()
        {
           return ClaimsPrincipal.Current?.Identities.First().Claims;
        }

        public async Task<IdentityResult> RegisterUser(RegisterUserRequest user)
        {
            var newuser = new UserModel()
            {
                UserName = user.Name,
                Email = user.Email
            };
          return await  _userManager.CreateAsync(newuser, user.Password);
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
