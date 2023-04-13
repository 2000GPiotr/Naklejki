using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels;
using Services.Helpers;
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
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public UserService(LabelDbContext dbContext, IMapper mapper, IPasswordService passwordService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<User> CreateUser(CreateUserDto userDto)
        {
            var newUser = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Roles = userDto.Roles//,
                
                //Hash = userDto.Hash,
                //Salt = "",
                //Round = 0
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<UserDto> DeleteUserById(int id)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new Exception(String.Format("Brak uzytkownika o id: {1}", id));
            }

            var toReturn = new UserDto()
            {
                Name = user.Name,
                Surname = user.Surname,
                Roles = user.Roles
            };

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return toReturn;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _dbContext
                .Users
                .ToList();
            
            var toReturn = new List<UserDto>();

            foreach(var user in users)
            {
                toReturn.Add(new UserDto()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Roles = user.Roles,
                });
            }

            return toReturn;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if(user == null)
            {
                throw new Exception(String.Format("Brak uzytkownika o id: {1}", id));
            }

            var toReturn = new UserDto()
            {
                Name = user.Name,
                Surname = user.Surname,
                Roles = user.Roles
            };

            return toReturn;
        }

        public async Task<User> UpdateUserById(int id, UserDto userDto)
        {
            var user = await _dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == id);

            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Roles = userDto.Roles;

            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
