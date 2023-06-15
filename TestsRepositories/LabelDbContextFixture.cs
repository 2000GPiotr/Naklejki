using Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;

namespace RepositoryTests
{
    public class LabelRepositoryTestsFixture : IDisposable
    {
        public LabelDbContext DbContext { get; }
        public ILabelTypeRepository LabelTypeRepository { get; }

        public LabelRepositoryTestsFixture()
        {
            var options = new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            DbContext = new LabelDbContext(options);
            LabelTypeRepository = new LabelTypeRepository(DbContext);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }

}