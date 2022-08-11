using DTO.RoleDTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<RoleModel> _roleManager;
        public RoleServices(RoleManager<RoleModel> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<RoleDTOModel> GetRoles()
        {
            var results = _roleManager.Roles;
            var roles = new List<RoleDTOModel>();
            foreach (var item in results)
            {
                var role = new RoleDTOModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreatedDate = item.CreatedDate,
                    UpdateedDate = item.UpdatedDate
                };
                roles.Add(role);
            }
            return roles;
        }

        public async Task<bool> CreateRole(CreateRoleRequest request)
        {
            var role = new RoleModel
            {
                Name = request.Name,
                CreatedDate = DateTime.Now
            };
           var result =await  _roleManager.CreateAsync(role);
           return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string id)
        {
            var role = _roleManager.Roles.Select(x => x.Id == id).OfType<RoleModel>().First();
            if (role == null)
                return false;
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoles(string[] ids)
        {
            foreach (var id in ids)
            {
                _roleManager.Roles.ToList().RemoveAll(x => x.Id == id);
                
            }
            //var result =await _roleManager.

            throw new NotImplementedException();
        }

        public IEnumerable<RoleDTOModel> FilterRole(FilterRoleRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTOModel> GetRoleById(string id)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> UpdateRole(UpdateRoleRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
