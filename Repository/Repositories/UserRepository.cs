using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LabelDbContext _dbContext;

        public UserRepository(LabelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserById(int userId)
        {
            return await _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            var user = await _dbContext
                .Users
                .Include(u => u.Roles)
                .Include(u => u.Password)
                .FirstOrDefaultAsync(u => u.Login == login);
        
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext
                .Users
                .Include(u => u.Roles)
                .ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            _dbContext.Users.Remove(user);
            _dbContext.Passwords.Remove(user.Password);
            await _dbContext.SaveChangesAsync();
        }
    }

}
