using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.DataTransferModels.Roles;
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
        private readonly IMapper _mapper;
        public RoleService( IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            var toReturn = _mapper.Map<List<RoleDto>>(roles);
            return toReturn;
        }

        public async Task<RoleDto> GetRolesById(int id)
        {
            var role = await _roleRepository.GetRoleById(id);

            if (role == null)
                throw new Exception("Wrong Role Id");

            var toReturn = _mapper.Map<RoleDto>(role);
            return toReturn;
        }
    }
}
