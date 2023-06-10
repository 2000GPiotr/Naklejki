using Services.DataTransferModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> CreateUser(CreateUserDto userDto);
        Task<UserDto> UpdateUser(UpdateUserDto userDto, int id);
        Task<UserDto> DeleteUser(int id);
    }
}
