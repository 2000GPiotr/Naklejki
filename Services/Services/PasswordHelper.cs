using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public static class PasswordHelper
    {
        public static void UpdatePassword(Password password, string plainPassword)
        {
            using (var hmac = new HMACSHA512())
            {
                password.Salt = hmac.Key;
                password.Hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainPassword));
                password.Round = 1;
            }
        }

        public static Password CreatePassword(string plainPassword)
        {
            var password = new Password();

            using (var hmac = new HMACSHA512())
            {
                password.Salt = hmac.Key;
                password.Hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainPassword));
                password.Round = 1;
            }
            return password;
        }
    }
}
