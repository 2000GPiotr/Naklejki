using Database;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public static class DocumentHeaderSeeder
    {
        private static List<User> users = UserSeeder.CreateUsers();
        private static List<DocumentType> types = DocumentTypeSeeder.CreateDocumentTypes();

        private static List<DocumentHeader> headers = new List<DocumentHeader>
        {
            new DocumentHeader
            {
                Id = 1,
                Description = "Desc 1",
                Year = 2023,
                Number = 1,
                Date = DateTime.Now,
                User = users[0],
                DocumentType = types[0],
            },
            new DocumentHeader
            {
                Id = 2,
                Description = "Desc 2",
                Year = 2023,
                Number = 2,
                Date = DateTime.Now,
                User = users[0],
                DocumentType = types[0],
            },
            new DocumentHeader
            {
                Id = 3,
                Description = "Desc 3",
                Year = 2023,
                Number = 3,
                Date = DateTime.Now,
                User = users[1],
                DocumentType = types[2],
            },
            new DocumentHeader
            {
                Id = 4,
                Description = "Desc 4",
                Year = 2023,
                Number = 4,
                Date = DateTime.Now,
                User = users[2],
                DocumentType = types[2],
            },
            new DocumentHeader
            {
                Id = 5,
                Description = "Desc 5",
                Year = 2023,
                Number = 5,
                Date = DateTime.Now,
                User = users[1],
                DocumentType = types[1],
            },
        };

        public static void SeedDocumentHeaders(LabelDbContext dbContext)
        {
            dbContext.Users.AddRange(users);
            dbContext.DocumentTypes.AddRange(types);
            dbContext.DocumentHeaders.AddRange(headers);
        }
    }
}
