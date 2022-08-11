using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
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


        public IEnumerable<UserDTOModel> GetAllUsers()
        {
            List<UserDTOModel> listUser = new List<UserDTOModel>();
            var results =  _repository.GetAll().AsEnumerable();
            foreach (var item in results)
            {
                listUser.Add(new UserDTOModel(item));
            }
            return listUser;
        }

        public async Task<UserDTOModel?> GetUserById(string id)
        {
            var result =await _userManager.FindByIdAsync(id);
            if (result == null)
                return null;
            return new UserDTOModel(result);
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
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                CreatedDate = DateTime.Now
            };
            //await _userManager.AddToRoleAsync(newuser, "User");
            return await  _userManager.CreateAsync(newuser, user.Password);
        }

        public async Task<bool> UpdateUser(string id, UpdateUserRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;
            user.DisplayName = request.DisplayName;
            user.Adress = request.Adress;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.DateofBirth = request.DateOfBirth;
            user.UpdatedDate = DateTime.Now;
            user.Sex = request.Sex;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<bool> DeleteUser(string Id)
        {
            var user =await _userManager.FindByIdAsync(Id);
            if (user == null)
                return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
