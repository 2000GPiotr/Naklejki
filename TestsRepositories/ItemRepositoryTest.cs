using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRepositories
{
    public class ItemRepositoryTest
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        //TODO
    }
}
