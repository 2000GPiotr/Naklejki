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
    public class LabelStatusTests
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
            var _labelStatusRepository = new LabelStatusRepository(_dbContext);

            var status1 = new LabelStatus { Symbol = "s1", Description = "Description 1" };
            var status2 = new LabelStatus { Symbol = "s2", Description = "Description 2" };

            await _dbContext.LabelStatus.AddRangeAsync(status1, status2);
            await _dbContext.SaveChangesAsync();

            // Act
            var statuses = await _labelStatusRepository.GetAllLabelStatus();

            // Assert
            Assert.Equal(2, statuses.Count);
            Assert.Contains(status1, statuses);
            Assert.Contains(status2, statuses);
        }

        [Fact]
        public async Task GetBySymbolTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetBySymbolTest)));

            // Arrange
            var _labelStatusRepository = new LabelStatusRepository(_dbContext);

            var status1 = new LabelStatus { Symbol = "s1", Description = "Description 1" };

            await _dbContext.LabelStatus.AddAsync(status1);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _labelStatusRepository.GetLabelStatusBySymbol(status1.Symbol);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(status1.Symbol, result.Symbol);
            Assert.Equal(status1.Description, result.Description);
        }
    }
}
