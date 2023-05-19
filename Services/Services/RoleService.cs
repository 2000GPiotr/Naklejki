using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
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
        private readonly LabelDbContext _dbContext;
        public RoleService(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            var roles = await _dbContext
                .Roles
                .ToListAsync();
            return roles;
        }

        public async Task<Roles> GetRolesById(int id)
        {
            var role = await _dbContext
                .Roles
                .FirstOrDefaultAsync(r => r.Id == id);
            
            return role;
        }
    }
}
