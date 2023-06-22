using Database.Entities;
using Services.DataTransferModels.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRolesService
    {
        Task<List<RoleDto>> GetAllRoles();
        Task<RoleDto> GetRolesById(int id);
    }
}
