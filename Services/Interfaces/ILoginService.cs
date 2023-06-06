using Services.DataTransferModels.Login;
using Services.DataTransferModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserDto> Login(LoginDto loginDto);
    }
}
