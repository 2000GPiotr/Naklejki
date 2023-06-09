using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
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
        public LoginService(LabelDbContext labelDbContext, IMapper mapper)
        {
            _dbContext =  labelDbContext;
            _mapper = mapper;
        }

        private async Task<string> CreateJWT(UserDto user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey###123@@@superSecretKey###123@@@"));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
                // Role itp.
            };

            var token = new JwtSecurityToken(
            "http://localhost:5021", // Twój emisariusz (issuer) - zmień na swój emisariusz
            "http://localhost:3000", // Twój odbiorca (audience) - zmień na swój odbiorca
            claims,
            expires: DateTime.UtcNow.AddMinutes(60), // Czas wygaśnięcia tokenu
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

            return "Super Secret Token";
            //var token = await CreateJWT(_mapper.Map<UserDto>(user));
            //return token;
        }

        private bool CheckPassword(Password userPassword, string givenPassword)
        {
            using(var hmac = new HMACSHA512(userPassword.Salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(givenPassword));
                //foreach (var b in userPassword.Salt)
                //    Debug.WriteLine(b);
                //foreach (var b in hmac.Key)
                //    Debug.WriteLine(b);
                return computedHash.SequenceEqual(userPassword.Hash);                
            }
        }
    }
}
