using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DataTransferModels.Login;
using Services.DataTransferModels.User;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly LabelDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginService(LabelDbContext labelDbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext =  labelDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        private string CreateJWT(UserDto user)
        {
            var tokenKey = _configuration.GetSection("AppSettings:TokenKey").Value;

            if (string.IsNullOrEmpty(tokenKey))
                throw new Exception("Token key not found");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            user.Roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.Nazwa)));

            var token = new JwtSecurityToken(            
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            
            var user = await _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.Login == loginDto.Login);

            if (user == null)
                throw new Exception("User not found");

            if (!CheckPassword(user.Password, loginDto.Password))
            {
                throw new Exception("Wrong password");
            }

            var token = CreateJWT(_mapper.Map<UserDto>(user));
            return token;
        }

        private static bool CheckPassword(Password userPassword, string givenPassword)
        {
            using(var hmac = new HMACSHA512(userPassword.Salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(givenPassword));
                return computedHash.SequenceEqual(userPassword.Hash);                
            }
        }
    }
}
