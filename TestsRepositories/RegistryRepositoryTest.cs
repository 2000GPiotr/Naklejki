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
    public class RegistryRepositoryTest
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        // TODO

        [Fact]
        public async Task UpdateTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(UpdateTest)));

            // Arrange
            var _registryRepository = new RegistryRepository(_dbContext);

            var addRegistryItems = new List<RegistryItem>()
            {
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1234",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Dostepna"
                },
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1235",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Dostepna"
                },
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1236",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Dostepna"
                }
            };

            var expectedRegistryItems = new List<RegistryItem>()
            {
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1234",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Wydana"
                },
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1235",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Wydana"
                },
                new RegistryItem()
                {
                    LabelNumberPrefix = "ab",
                    LabelNumber = "1236",
                    LabelNumberSufix = "",
                    LabelTypeId = "M10",
                    UserId = 33,
                    LabelEndTime = DateTime.Now,
                    LabelStatusId = "Wydana"
                }
            };

            await _dbContext.Registry.AddRangeAsync(addRegistryItems);
            await _dbContext.SaveChangesAsync();

            // Act
            var registryItems = _dbContext
                .Registry
                .ToList();

            foreach(var item in registryItems)
            {
                item.LabelStatusId = "Wydana";
            }
            await _registryRepository.UpdateManyRegistryItems(registryItems);

            // Assert
            var result = await _dbContext
                .Registry
                .ToListAsync();

            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.Equal("Wydana", item.LabelStatusId));
        }
    }
}
