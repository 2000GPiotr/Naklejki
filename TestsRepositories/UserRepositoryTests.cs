using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRepositories
{
    public class UserRepositoryTests
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetUserByIdTest_MainPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetUserByIdTest_MainPath)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var userId = 1;
            var user = new User
            {
                Id = 1,
                Login = "login1",
                Name = "Jan",
                Surname = "Kowalski",
                Roles = new List<Roles>(),
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();


            // Act
            var result = await userRepository.GetUserById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Surname, result.Surname);
        }

        [Fact]
        public async Task GetUserByIdTest_NoDataPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetUserByIdTest_NoDataPath)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);
            var userId = 1410;

            // Act
            var result = await userRepository.GetUserById(userId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserByLoginTest_MainPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetUserByLoginTest_MainPath)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var userLogin = "login1";
            var user = new User
            {
                Id = 1,
                Login = "login1",
                Name = "Jan",
                Surname = "Kowalski",
                Roles = new List<Roles>(),
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();


            // Act
            var result = await userRepository.GetUserByLogin(userLogin);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Login, result.Login);
            Assert.Equal(user.Name, result.Name);
            Assert.Equal(user.Surname, result.Surname);
        }

        [Fact]
        public async Task GetUserByLoginTest_NoDataPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetUserByLoginTest_NoDataPath)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);
            var userLogin = "alaMakota";

            // Act
            var result = await userRepository.GetUserByLogin(userLogin);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllUsersTest()
        {
            var _dbContext = new LabelDbContext(CreateOptions(nameof(GetAllUsersTest)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var users = new List<User>
            {
                new User { Id = 1, Login = "login1", Name = "Jan", Surname = "Kowalski",
                    Roles = new List<Roles>(),
                    Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
                },
                new User { Id = 2, Login = "login2", Name = "Anna", Surname = "Nowak",
                    Roles = new List<Roles>(),
                    Password = new Password { Id = 2, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
                },
                new User { Id = 3, Login = "login3", Name = "Ala", Surname = "Makota",
                    Roles = new List<Roles>(),
                    Password = new Password { Id = 3, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
                }
            };

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await userRepository.GetAllUsers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count);

            foreach (var user in users)
                Assert.Contains(user, result);
        }

        [Fact]
        public async Task AddUserTest_MainPath()
        {
            var _dbContext = new LabelDbContext(CreateOptions(nameof(AddUserTest_MainPath)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var user = new User
            {
                Id = 1,
                Login = "login1",
                Name = "Jan",
                Surname = "Kowalski",
                Roles = new List<Roles>(),
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            // Act
            await userRepository.AddUser(user);

            // Assert
            Assert.Single(_dbContext.Users);

            var addedUser = await _dbContext
                .Users.FirstOrDefaultAsync();
            Assert.NotNull(addedUser);
            Assert.Equal(user.Id, addedUser.Id);
            Assert.Equal(user.Login, addedUser.Login);
            Assert.Equal(user.Name, addedUser.Name);
            Assert.Equal(user.Surname, addedUser.Surname);
        }

        [Fact]
        public async Task UpdateUserTest()
        {
            var _dbContext = new LabelDbContext(CreateOptions(nameof(UpdateUserTest)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var user = new User
            {
                Id = 1,
                Login = "login1",
                Name = "Jan",
                Surname = "Kowalski",
                Roles = new List<Roles>(),
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            // Act
            user.Name = "Updated Name";
            await userRepository.UpdateUser(user);

            // Assert
            var updatedUser = await _dbContext
                .Users.FirstOrDefaultAsync();

            Assert.NotNull(updatedUser);
            Assert.Equal(user.Id, updatedUser.Id);
            Assert.Equal(user.Login, updatedUser.Login);
            Assert.Equal(user.Name, updatedUser.Name);
            Assert.Equal(user.Surname, updatedUser.Surname);
        }

        [Fact]
        public async Task DeleteUserTest()
        {
            var _dbContext = new LabelDbContext(CreateOptions(nameof(UpdateUserTest)));

            // Arrange
            var userRepository = new UserRepository(_dbContext);

            var user = new User
            {
                Id = 1,
                Login = "login1",
                Name = "Jan",
                Surname = "Kowalski",
                Roles = new List<Roles>(),
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            // Act
            await userRepository.DeleteUser(user);

            // Assert
            Assert.Empty(_dbContext.Users);
        }
    }
}
