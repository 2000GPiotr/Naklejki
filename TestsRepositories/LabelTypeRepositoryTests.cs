using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryTests
{
    public class LabelTypeRepositoryTests : IClassFixture<LabelRepositoryTestsFixture>
    {
        private readonly LabelDbContext _dbContext;
        private readonly ILabelTypeRepository _labelTypeRepository;

        public LabelTypeRepositoryTests(LabelRepositoryTestsFixture dbContextFixture)
        {
            _dbContext = dbContextFixture.DbContext;
            _labelTypeRepository = dbContextFixture.LabelTypeRepository;
        }

        [Fact]
        public async Task AddTest()
        {
            // Arrange
            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };

            // Act
            await _labelTypeRepository.AddLabelType(labelType);

            // Assert
            var addedLabelType = await _dbContext
                .LabelTypes
                .FirstOrDefaultAsync(l => l.Symbol == labelType.Symbol);
            Assert.NotNull(addedLabelType);
        }
    }
}
