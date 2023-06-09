using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels.Roles;
using Services.DataTransferModels.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly LabelDbContext _dbContext;
        private readonly IRolesService _rolesService;
        private readonly IMapper _mapper;
        
        public UserService(LabelDbContext dbContext, IRolesService rolesService, IMapper mapper)
        {
            _dbContext = dbContext;
            _rolesService = rolesService;
            _mapper = mapper;
        }

        public static Password CreatePassword(string plainPassword)
        {
            var password = new Password();

            using(var hmac = new HMACSHA512())
            {
                password.Salt = hmac.Key;
                password.Hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainPassword));
                password.Round = 1;
                //foreach(var b in password.Salt)
                //    Debug.WriteLine(b);
                //foreach(var b in hmac.Key)
                //    Debug.WriteLine(b);
            }
            return password;
        }

        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            var password = CreatePassword(userDto.Password);
            var newUser = _mapper.Map<User>(userDto);
            //newUser.Password = password;

            var roles = new List<Roles>();

            foreach(var id in userDto.RolesId)
            {
                var role = await _rolesService
                    .GetRolesById(id);
                roles.Add(role);
            }

            newUser.Roles = roles;

            await _dbContext.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            var toReturn =_mapper.Map<UserDto>(newUser);
            toReturn.Roles = _mapper.Map<List<RoleDto>>(roles);

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

            var toReturn = _mapper.Map<UserDto>(user);
            foreach (var role in user.Roles)
            {
                var newRoleDto = new RoleDto() { Id = role.Id, Nazwa = role.Nazwa, Description = role.Description };
                toReturn.Roles.Add(newRoleDto);
            }

            _dbContext.Users.Remove(user);
            _dbContext.Passwords.Remove(user.Password);
            await _dbContext.SaveChangesAsync();

            return toReturn;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _dbContext
                .Users
                .Include(u => u.Roles)
                .ToListAsync();

            var toReturn = _mapper.Map<List<UserDto>>(users);

            return toReturn;
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

            user = _mapper.Map(userDto, user);

            if(!String.IsNullOrEmpty(userDto.Password))
            {
                var newPassword = CreatePassword(userDto.Password);
                user.Password.Salt = newPassword.Salt;
                user.Password.Hash = newPassword.Hash;
                user.Password.Round = newPassword.Round;

                //   user.Password = CreatePassword(userDto.Password);
            }

            user.Roles.Clear();
            foreach (var roleId in userDto.RolesId)
            {
                var role = await _rolesService.GetRolesById(roleId);
                user.Roles.Add(role);
            }

            await _dbContext.SaveChangesAsync();

            var toReturn = _mapper.Map<UserDto>(user);

            return toReturn;
        }
    }
}
