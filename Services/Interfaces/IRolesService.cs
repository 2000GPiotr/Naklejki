using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRolesById(int id);
    }
}
