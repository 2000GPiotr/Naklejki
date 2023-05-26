using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels.Roles;
using Services.DataTransferModels.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly LabelDbContext _dbContext;
        private readonly IRolesService _rolesService;
        public UserService(LabelDbContext dbContext, IRolesService rolesService)
        {
            _dbContext = dbContext;
            _rolesService = rolesService;
        }

        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            var newUser = new User() { Login = userDto.Login, Name = userDto.Name, Surname = userDto.Surname};
            var newPassword = new Password() { Hash = userDto.Password, Round=0, Salt = "" };
            var roles = new List<Roles>();

            foreach(var id in userDto.RolesId)
            {
                var role = await _rolesService
                    .GetRolesById(id);
                roles.Add(role);
            }

            newUser.Roles = roles;
            newUser.Password = newPassword;

            await _dbContext.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            var toReturn = new UserDto() { Id = newUser.Id, Login = newUser.Login, Name = newUser.Name, Surname = newUser.Surname};
            toReturn.Roles = new List<RoleDto>();
            foreach(var role in roles)
            {
                var newRoleDto = new RoleDto() { Id = role.Id, Nazwa = role.Nazwa, Description = role.Description };
                toReturn.Roles.Add(newRoleDto);
            }

            return toReturn;
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            var user = await _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception();

            var toReturn = new UserDto() { Name = user.Name, Id = user.Id, Surname = user.Surname, Login = user.Login, Roles = new List<RoleDto>() };
            foreach (var role in user.Roles)
            {
                var newRoleDto = new RoleDto() { Id = role.Id, Nazwa = role.Nazwa, Description = role.Description };
                toReturn.Roles.Add(newRoleDto);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return toReturn;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _dbContext
                .Users
                .Include(u => u.Roles)
                .ToListAsync();

            var toReturn = new List<UserDto>();

            foreach(var user in users)
            {
                var newUser = new UserDto()
                {
                    Name = user.Name,
                    Id = user.Id,
                    Surname = user.Surname,
                    Login = user.Login,
                    Roles = new List<RoleDto>()
                };

                foreach (var role in user.Roles)
                {
                    newUser.Roles.Add(new RoleDto() { Id = role.Id, Nazwa = role.Nazwa, Description = role.Description });
                }
                toReturn.Add(newUser);
            }

            return toReturn;
        }

        public Task<UpdateUserDto> GetUpdateUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> UpdateUser(UpdateUserDto userDto, int id)
        {
            var user = await _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new Exception();

            user.Login = userDto.Login;
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Roles = new List<Roles>();

            if (userDto.Password != "")
                user.Password.Hash = userDto.Password;

            foreach (var roleId in userDto.RolesId)
            {
                var role = await _rolesService.GetRolesById(roleId);
                user.Roles.Add(role);
            }

            await _dbContext.SaveChangesAsync();

            var toReturn = new UserDto() { Id = user.Id, Login = user.Login, Name = user.Name, Surname = user.Surname, Roles = new List<RoleDto>() };
            foreach (var role in user.Roles)
            {
                var newRoleDto = new RoleDto() { Id = role.Id, Nazwa = role.Nazwa, Description = role.Description };
                toReturn.Roles.Add(newRoleDto);
            }

            return toReturn;
        }
    }
}
