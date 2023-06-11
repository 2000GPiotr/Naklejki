using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly LabelDbContext _dbContext;
        public RoleRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            return await _dbContext
                .Roles
                .ToListAsync();
        }

        public async Task<Roles?> GetRoleById(int id)
        {
            return await _dbContext
                .Roles
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
