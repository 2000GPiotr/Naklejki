using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<RoleDto> GetRoleById(int Id);
        Task<bool> CreateRole(RoleDto RoleDto);
        Task<bool> UpdateRoleById(int Id, RoleDto RoleDto);
        Task<RoleDto> DeleteRoleById(int Id);
    }
}
