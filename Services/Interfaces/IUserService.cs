using Database.Entities;
using Services.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<User> CreateUser(CreateUserDto userDto);
        Task<User> UpdateUserById(int id, UserDto userDto);
        Task<UserDto> DeleteUserById(int Id);
    }
}
