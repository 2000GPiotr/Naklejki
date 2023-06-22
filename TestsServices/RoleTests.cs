using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Database.Entities;
using Moq;
using Repository.Interfaces;
using Services.DataTransferModels.Roles;
using Services.Services;
using Xunit;

namespace TestsServices
{
    public class RoleServiceTests
    {
        [Fact]
        public async Task GetAllTests()
        {
            // Arrange
            var roles = new List<Roles>
        {
            new Roles { Id = 1, Nazwa = "Role1", Description = "Description1" },
            new Roles { Id = 2, Nazwa = "Role2", Description = "Description2" }
        };
            var roleDtos = new List<RoleDto>
        {
            new RoleDto { Id = 1, Nazwa = "Role1", Description = "Description1" },
            new RoleDto { Id = 2, Nazwa = "Role2", Description = "Description2" }
        };

            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repository => repository.GetAllRoles())
                .ReturnsAsync(roles);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<RoleDto>>(roles))
                .Returns(roleDtos);

            var roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await roleService.GetAllRoles();

            // Assert
            Assert.Equal(roleDtos, result);
            roleRepositoryMock.Verify(repository => repository.GetAllRoles(), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<RoleDto>>(roles), Times.Once);
        }

        [Fact]
        public async Task GetRolesById_MainPath()
        {
            // Arrange
            int roleId = 1;
            var role = new Roles { Id = roleId, Nazwa = "Role1", Description = "Description1" };
            var roleDto = new RoleDto { Id = roleId, Nazwa = "Role1", Description = "Description1" };

            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repository => repository.GetRoleById(roleId))
                              .ReturnsAsync(role);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<RoleDto>(role))
                      .Returns(roleDto);

            var roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await roleService.GetRolesById(roleId);

            // Assert
            Assert.Equal(roleDto, result);
            roleRepositoryMock.Verify(repository => repository.GetRoleById(roleId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<RoleDto>(role), Times.Once);
        }

        [Fact]
        public async Task GetRolesByIdTest_NullFromRepository()
        {
            // Arrange
            int roleId = 1;
            Roles role = null;

            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repository => repository.GetRoleById(roleId))
                              .ReturnsAsync(role);

            var mapperMock = new Mock<IMapper>();

            var roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await roleService.GetRolesById(roleId));
            roleRepositoryMock.Verify(repository => repository.GetRoleById(roleId), Times.Once);
            mapperMock.VerifyNoOtherCalls();
        }
    }
}
