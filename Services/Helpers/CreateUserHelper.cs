using Database.Entities;
using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class CreateUserHelper
    {
        public static async Task<User> CreateUser(CreateUserDto userDto)
        {
            var newUser = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Roles = userDto.Roles
            };

            return newUser;
        }

        private static Password CreatePassword(string password)
        {
            return new Password()
            {
                Round = 0,
                Salt = "",
                Hash = password
            };
        }
    }
}
