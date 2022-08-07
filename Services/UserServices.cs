using DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<UserDTO> GetAllUsers()
        {
            List<UserDTO> listUser = new List<UserDTO>();
            var result =  _repository.GetAll().AsEnumerable();
            foreach (var item in result)
            {
                var user = new UserDTO
                {
                    Email = item.Email,
                    Id = item.Id,
                    Name = item.UserName,
                    PhoneNumber = item.PhoneNumber
                };
                listUser.Add(user);
            }
            return listUser;
        }

        public UserDTO GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterDTO user)
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
