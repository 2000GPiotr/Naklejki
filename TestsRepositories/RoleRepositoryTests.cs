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
    public class RoleRepositoryTests
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetAllTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetAllTest)));

            // Arrange
            var _rolesRepository = new RoleRepository(_dbContext);

            var role1 = new Roles { Id = 1, Name = "Role1", Description = "Description1" };
            var role2 = new Roles { Id = 2, Name = "Role2", Description = "Description2" };
            await _dbContext.Roles.AddRangeAsync(role1, role2);
            await _dbContext.SaveChangesAsync();

            // Act
            var roles = await _rolesRepository.GetAllRoles();

            // Assert
            Assert.Equal(2, roles.Count);
            Assert.Contains(role1, roles);
            Assert.Contains(role2, roles);
        }

        [Fact]
        public async Task GetRoleByIdTest_MainPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetRoleByIdTest_MainPath)));

            // Arrange
            var _roleRepository = new RoleRepository(_dbContext);

            var role = new Roles { Id = 1, Name = "Role1", Description = "Description1" };
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _roleRepository.GetRoleById(role.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(role.Id, result.Id);
            Assert.Equal(role.Name, result.Name);
            Assert.Equal(role.Description, result.Description);
        }

        [Fact]
        public async Task GetRoleByIdTest_NoDataPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetRoleByIdTest_NoDataPath)));

            // Arrange
            var _roleRepository = new RoleRepository(_dbContext);

            var roleId = 999;

            // Act
            var result = await _roleRepository.GetRoleById(roleId);

            // Assert
            Assert.Null(result);
        }


    }
}
