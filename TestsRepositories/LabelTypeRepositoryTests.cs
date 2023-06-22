using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRepositories
{
    public class LabelTypeTestsNew
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        private readonly DbContextOptions<LabelDbContext> options = new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;


        [Fact]
        public async Task AddTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(AddTest)));
            
            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);
            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };

            // Act
            await _labelTypeRepository.AddLabelType(labelType);

            // Assert
            var addedLabelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == labelType.Symbol);
            Assert.NotNull(addedLabelType);
        }

        [Fact]
        public async Task DeleteTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(DeleteTest)));

            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);
            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            await _dbContext.LabelTypes.AddAsync(labelType);
            await _dbContext.SaveChangesAsync();

            // Act
            await _labelTypeRepository.DeleteLabelType(labelType);

            // Assert
            var deletedLabelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == labelType.Symbol);
            Assert.Null(deletedLabelType);
        }

        [Fact]
        public async Task GetAllTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetAllTest)));

            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);

            var labelType1 = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            var labelType2 = new LabelType { Symbol = "S2", Description = "Desc 2", Count = 966 };
            await _dbContext.LabelTypes.AddRangeAsync(labelType1, labelType2);
            await _dbContext.SaveChangesAsync();

            // Act
            var labelTypes = await _labelTypeRepository.GetAllLabelTypes();

            // Assert
            Assert.Equal(2, labelTypes.Count);
            Assert.Contains(labelType1, labelTypes);
            Assert.Contains(labelType2, labelTypes);
        }

        [Fact]
        public async Task GetBySymbolTest_MainPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetBySymbolTest_MainPath)));

            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);

            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            await _dbContext.LabelTypes.AddAsync(labelType);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _labelTypeRepository.GetLabelTypeBySymbol(labelType.Symbol);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(labelType.Symbol, result.Symbol);
            Assert.Equal(labelType.Description, result.Description);
            Assert.Equal(labelType.Count, result.Count);
        }

        [Fact]
        public async Task GetBySymbolTest_NoDataPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetBySymbolTest_NoDataPath)));

            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);

            var symbol = "NonExistingSymbol";

            // Act
            var result = await _labelTypeRepository.GetLabelTypeBySymbol(symbol);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(UpdateTest)));

            // Arrange
            var _labelTypeRepository = new LabelTypeRepository(_dbContext);

            var addLabelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            var expectedLabelType = new LabelType { Symbol = "S1", Description = "Updated Desc", Count = 966 };

            await _dbContext.LabelTypes.AddAsync(addLabelType);
            await _dbContext.SaveChangesAsync();

            var labelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == "S1");

            labelType.Description = expectedLabelType.Description;
            labelType.Count = expectedLabelType.Count;

            // Act
            await _labelTypeRepository.UpdateLabelType(labelType);

            // Assert
            var result = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == labelType.Symbol);
            Assert.NotNull(result);
            Assert.Equal(expectedLabelType.Description, result.Description);
            Assert.Equal(expectedLabelType.Count, result.Count);
        }
    }
}
