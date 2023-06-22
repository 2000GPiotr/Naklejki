
using AutoMapper;
using Database.Entities;
using Moq;
using Repository.Interfaces;
using Services.DataTransferModels.Roles;
using Services.DataTransferModels.User;
using Services.Services;

namespace TestsServices
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IRoleRepository> _roleRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_mapperMock.Object, _userRepositoryMock.Object, _roleRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateUserTest_MainPath()
        {
            // Arrange
            var userDto = new CreateUserDto
            {
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = "password123",
                RolesId = new List<int> { 1, 2 }
            };

            var user = new User
            {
                Id = 1,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            var roles = new List<Roles>
            {
                new Roles { Id = 1, Nazwa = "Role1", Description = "Description1" },
                new Roles { Id = 2, Nazwa = "Role2", Description = "Description2" }
            };

            var userDtoResult = new UserDto
            {
                Id = 1,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Roles = new List<RoleDto>
                {
                    new RoleDto { Id = 1, Nazwa = "Role1", Description = "Description1" },
                    new RoleDto { Id = 2, Nazwa = "Role2", Description = "Description2" }
                }
            };

            _mapperMock.Setup(mapper => mapper.Map<User>(userDto))
                .Returns(user);
            _roleRepositoryMock.Setup(repo => repo.GetRoleById(It.IsAny<int>()))
                .ReturnsAsync(roles[0]);
            _userRepositoryMock.Setup(repo => repo.AddUser(user))
                .Verifiable();
            _mapperMock.Setup(mapper => mapper.Map<UserDto>(user))
                .Returns(userDtoResult);

            // Act
            var result = await _userService.CreateUser(userDto);

            // Assert
            Assert.Equal(userDtoResult, result);
            _userRepositoryMock.Verify(repo => repo.AddUser(user), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(user), Times.Once);
        }

        [Fact]
        public async Task CreateUserTest_NullRoleFromRepository()
        {
            // Arrange
            var userDto = new CreateUserDto
            {
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = "password123",
                RolesId = new List<int> { 1, 2 }
            };

            var user = new User
            {
                Id = 1,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            _mapperMock.Setup(mapper => mapper.Map<User>(userDto))
                .Returns(user);
            _roleRepositoryMock.Setup(repo => repo.GetRoleById(It.IsAny<int>()))
                .ReturnsAsync((Roles)null);

            // Act
            Task CreateUserAction() => _userService.CreateUser(userDto);

            // Assert
            await Assert.ThrowsAsync<Exception>(CreateUserAction);
            _userRepositoryMock.Verify(repo => repo.AddUser(user), Times.Never);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(user), Times.Never);
        }

        [Fact]
        public async Task DeleteUserTest_MainPath()
        {
            // Arrange
            int userId = 1;
            var user = new User
            { 
                Id = userId, 
                Login = "user1", 
                Name = "John", 
                Surname = "Kowalski" 
            };
            var userDtoResult = new UserDto { Id = userId, Login = "user1", Name = "John", Surname = "Kowalski" };

            _userRepositoryMock.Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(user);
            _userRepositoryMock.Setup(repo => repo.DeleteUser(user))
                .Verifiable();
            _mapperMock.Setup(mapper => mapper.Map<UserDto>(user))
                .Returns(userDtoResult);

            // Act
            var result = await _userService.DeleteUser(userId);

            // Assert
            Assert.Equal(userDtoResult, result);
            _userRepositoryMock.Verify(repo => repo.DeleteUser(user), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(user), Times.Once);
        }

        [Fact]
        public async Task DeleteUserTest_NullFromRepository()
        {
            // Arrange
            int userId = 1;

            _userRepositoryMock.Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync((User)null);

            // Act
            Task DeleteUserAction() => _userService.DeleteUser(userId);

            // Assert
            await Assert.ThrowsAsync<Exception>(DeleteUserAction);
            _userRepositoryMock.Verify(repo => repo.DeleteUser(It.IsAny<User>()), Times.Never);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task GetAllUsersTest()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Login = "user1", Name = "John", Surname = "Kowalski" },
                new User { Id = 2, Login = "user2", Name = "Jane", Surname = "Smith" }
            };

            var userDtoResults = new List<UserDto>
            {
                new UserDto { Id = 1, Login = "user1", Name = "John", Surname = "Kowalski" },
                new UserDto { Id = 2, Login = "user2", Name = "Jane", Surname = "Smith" }
            };

            _userRepositoryMock.Setup(repo => repo.GetAllUsers())
                .ReturnsAsync(users);
            _mapperMock.Setup(mapper => mapper.Map<List<UserDto>>(users))
                .Returns(userDtoResults);

            // Act
            var result = await _userService.GetAllUsers();

            // Assert
            Assert.Equal(userDtoResults, result);
            _userRepositoryMock.Verify(repo => repo.GetAllUsers(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<UserDto>>(users), Times.Once);
        }

        [Fact]
        public async Task UpdateUserTest_MainPath()
        {
            // Arrange
            int userId = 1;
            var userDto = new UpdateUserDto
            {
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = "password123",
                RolesId = new List<int> { 1, 2 }
            };

            var user = new User
            {
                Id = userId,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } },
                Roles = new List<Roles> { new Roles { Id = 3, Nazwa = "Role3", Description = "Description3" } }
            };

            var roles = new List<Roles>
            {
                new Roles { Id = 1, Nazwa = "Role1", Description = "Description1" },
                new Roles { Id = 2, Nazwa = "Role2", Description = "Description2" }
            };

            var updatedUserDtoResult = new UserDto
            {
                Id = userId,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Roles = new List<RoleDto>
                {
                    new RoleDto { Id = 1, Nazwa = "Role1", Description = "Description1" },
                    new RoleDto { Id = 2, Nazwa = "Role2", Description = "Description2" }
                }
            };

            _userRepositoryMock.Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(user);
            _mapperMock.Setup(mapper => mapper.Map(userDto, user));
            _roleRepositoryMock.Setup(repo => repo.GetRoleById(It.IsAny<int>()))
                .ReturnsAsync(roles[0]);
            _userRepositoryMock.Setup(repo => repo.UpdateUser(user))
                .Returns(Task.CompletedTask);
            _mapperMock.Setup(mapper => mapper.Map<UserDto>(user))
                .Returns(updatedUserDtoResult);

            // Act
            var result = await _userService.UpdateUser(userDto, userId);

            // Assert
            Assert.Equal(updatedUserDtoResult, result);
            _userRepositoryMock.Verify(repo => repo.UpdateUser(user), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(user), Times.Once);
        }

        [Fact]
        public async Task UpdateUserTest_NullFromRepository()
        {
            // Arrange
            int userId = 1;
            var userDto = new UpdateUserDto
            {
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = "password123",
                RolesId = new List<int> { 1, 2 }
            };

            _userRepositoryMock.Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync((User)null);

            // Act
            Task UpdateUserAction() => _userService.UpdateUser(userDto, userId);

            // Assert
            await Assert.ThrowsAsync<Exception>(UpdateUserAction);
            _userRepositoryMock.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Never);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task UpdateUserTest_NullRoleFromRepository()
        {
            // Arrange
            int userId = 1;
            var userDto = new UpdateUserDto
            {
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = "password123",
                RolesId = new List<int> { 1, 2 }
            };

            var user = new User
            {
                Id = userId,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } },
                Roles = new List<Roles> { new Roles { Id = 3, Nazwa = "Role3", Description = "Description3" } }
            };

            _userRepositoryMock.Setup(repo => repo.GetUserById(userId))
                .ReturnsAsync(user);
            _roleRepositoryMock.Setup(repo => repo.GetRoleById(It.IsAny<int>()))
                .ReturnsAsync((Roles)null);

            // Act
            Task UpdateUserAction() => _userService.UpdateUser(userDto, userId);

            // Assert
            await Assert.ThrowsAsync<Exception>(UpdateUserAction);
            _userRepositoryMock.Verify(repo => repo.UpdateUser(It.IsAny<User>()), Times.Never);
            _mapperMock.Verify(mapper => mapper.Map<UserDto>(It.IsAny<User>()), Times.Never);
        }
    }

}
