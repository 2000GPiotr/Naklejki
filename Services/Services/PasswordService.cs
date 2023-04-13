using Database;
using Database.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly LabelDbContext _dbContext;
        public PasswordService(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Password> CreatePassword(string password)
        {
            var newPassword = new Password() //TODO
            {
                Round = 0,
                Salt = "",
                Hash = password
            };

            await _dbContext.AddAsync(newPassword);
            await _dbContext.SaveChangesAsync();

            return newPassword;
        }
    }
}
