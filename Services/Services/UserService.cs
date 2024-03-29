﻿using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(
            IMapper mapper, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> CreateUser(CreateUserDto userDto)
        {
            var newUser = _mapper.Map<User>(userDto);

            var roles = new List<Roles>();

            foreach(var id in userDto.RolesId)
            {
                var role = await _roleRepository.GetRoleById(id);

                if (role == null)
                    throw new Exception("Wrong Role Id");

                roles.Add(role);
            }

            newUser.Roles = roles;

            await _userRepository.AddUser(newUser);

            var toReturn =_mapper.Map<UserDto>(newUser);

            return toReturn;
        }

        public async Task<UserDto> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                throw new Exception("Wrong User Id");

            var toReturn = _mapper.Map<UserDto>(user);

            await _userRepository.DeleteUser(user);

            return toReturn;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            var toReturn = _mapper.Map<List<UserDto>>(users);

            return toReturn;
        }

        public async Task<UserDto> UpdateUser(UpdateUserDto userDto, int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
                throw new Exception("Wrong user id");

            _mapper.Map(userDto, user);

            if(!String.IsNullOrEmpty(userDto.Password))
                PasswordHelper.UpdatePassword(user.Password, userDto.Password);

            user.Roles.Clear();
            foreach (var roleId in userDto.RolesId)
            {
                var role = await _roleRepository.GetRoleById(roleId);

                if (role == null)
                    throw new Exception("Wrong Role Id");

                user.Roles.Add(role);
            }
            user.Id = id;
            await _userRepository.UpdateUser(user);

            var toReturn = _mapper.Map<UserDto>(user);

            return toReturn;
        }
    }
}
