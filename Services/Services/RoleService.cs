using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly LabelDbContext _dbContext;
        private readonly IMapper _mapper;
        public RoleService(LabelDbContext bdContext, IMapper mapper)
        {
            _dbContext = bdContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateRole(RoleDto RoleDto)
        {
            var newRole = _mapper.Map<Roles>(RoleDto);
            
            await _dbContext.AddAsync(newRole);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<RoleDto> DeleteRoleById(int Id)
        {
            var role = await _dbContext
                .Roles
                .FirstOrDefaultAsync(x => x.Id == Id);

            if (role == null)
                throw new Exception(String.Format("No Role with Id: {0}", Id));

            var toReturn = _mapper.Map<RoleDto>(role);

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();

            return toReturn;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            var roles = await _dbContext
                .Roles
                .ToListAsync();

            var toReturn = new List<RoleDto>();

            foreach (var role in roles)
            {
                toReturn.Add(new RoleDto(role.Id, role.Name, role.Description));
            }

            return toReturn;
        }

        public async Task<RoleDto> GetRoleById(int Id)
        {
            var role = await _dbContext
                .Roles
                .FirstOrDefaultAsync(x => x.Id == Id);

            var toReturn = new RoleDto(role.Id, role.Name, role.Description);

            return toReturn;
        }

        public async Task<bool> UpdateRoleById(int Id, RoleDto RoleDto)
        {
            var role = await _dbContext
                .Roles
                .FirstOrDefaultAsync(x => x.Id == Id);

            role.Name = RoleDto.Name;
            role.Description = RoleDto.Description;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
