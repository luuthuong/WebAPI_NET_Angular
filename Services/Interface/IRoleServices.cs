using DTO.RoleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IRoleServices
    {
        IEnumerable<RoleDTOModel> GetRoles();
        IEnumerable<RoleDTOModel> FilterRole(FilterRoleRequest request);
        Task<RoleDTOModel> GetRoleById(string id);
        Task<bool> CreateRole(CreateRoleRequest request);
        Task<bool> UpdateRole(UpdateRoleRequest request);
        Task<bool> DeleteRole(string id);
        Task<bool> DeleteRoles(string[] ids);
    }
}
