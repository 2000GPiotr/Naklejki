using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore;
using Services.DataTransferModels.Login;
using Services.DataTransferModels.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly LabelDbContext _dbContext;
        private readonly IMapper _mapper;
        public LoginService(LabelDbContext labelDbContext, IMapper mapper)
        {
            _dbContext =  labelDbContext;
            _mapper = mapper;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefault(u => u.Login == loginDto.login);

            if (user == null)
                throw new Exception();

            if (user.Password.Hash == loginDto.password)
                return _mapper.Map<UserDto>(user);

            return null;
        }
    }
}
