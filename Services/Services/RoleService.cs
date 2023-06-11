using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoleService : IRolesService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService( IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return roles;
        }

        public async Task<Roles> GetRolesById(int id)
        {
            var role = await _roleRepository.GetRoleById(id);
            return role;
        }
    }
}
