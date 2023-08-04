using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Seeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsRepositories
{
    public class DocumentHeaderRepositoryTests
    {
        DbContextOptions<LabelDbContext> CreateOptions(string dbName)
        {
            return new DbContextOptionsBuilder<LabelDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetDocumentById_MainPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetDocumentById_MainPath)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);
            
            var users = UserSeeder.CreateUsers();
            var types = DocumentTypeSeeder.CreateDocumentTypes();

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.DocumentTypes.AddRangeAsync(types);
            await _dbContext.SaveChangesAsync();

            var id = 1;

            var headers = new List<DocumentHeader>
            {
                new DocumentHeader
                {
                    Description = "Desc 1",
                    Year = 2023,
                    Number = 1,
                    Date = DateTime.Now,
                    User = users[0],
                    DocumentType = types[0],
                },
                new DocumentHeader
                {
                    Description = "Desc 2",
                    Year = 2023,
                    Number = 2,
                    Date = DateTime.Now,
                    User = users[0],
                    DocumentType = types[0],
                },
            };

            await _dbContext.DocumentHeaders.AddRangeAsync(headers);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await documentHeaderRepository.GetDocumentById(id);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.User);
            Assert.NotNull(result.DocumentType);
        }

        [Fact]
        public async Task GetDocumentById_NoDataPath()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetDocumentById_NoDataPath)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);
            var badId = 0;

            // Act
            var result = await documentHeaderRepository.GetDocumentById(badId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllDocumentsTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetAllDocumentsTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            //var users = UserSeeder.CreateUsers();
            //var types = DocumentTypeSeeder.CreateDocumentTypes();

            //await _dbContext.Users.AddRangeAsync(users); // Tworzy 9 instancji DocumentHeader i wprowadza je do bazy danych
            //await _dbContext.DocumentTypes.AddRangeAsync(types);
            //await _dbContext.SaveChangesAsync();

            var user = new User { Name = "Admin", Surname = "Admin", Login = "admin" };
            var type = new DocumentType { Symbol = "Przyjecie", Description = "Przyjęcie na stan" };

            var headers = new List<DocumentHeader>
            {
                new DocumentHeader
                {
                    Id = 1,
                    Description = "Desc 1",
                    Year = 2023,
                    Number = 1,
                    Date = DateTime.Now,
                    User = user,
                    DocumentType = type,
                },
                new DocumentHeader
                {
                    Id = 2,
                    Description = "Desc 2",
                    Year = 2023,
                    Number = 2,
                    Date = DateTime.Now,
                    User = user,
                    DocumentType = type,
                },
            };

            await _dbContext.DocumentHeaders.AddRangeAsync(headers);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await documentHeaderRepository.GetAllDocuments();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Count, headers.Count);
            foreach (var header in headers)
                Assert.Contains(header, result);
        }

        [Fact]
        public async Task GetAllDocumentsTest_EmptyList()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetAllDocumentsTest_EmptyList)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            // Act
            var result = await documentHeaderRepository.GetAllDocuments();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count == 0);
        }

        [Fact]
        public async Task GetDokumentsByUserIdTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetDokumentsByUserIdTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            var user1 = new User { Name = "Admin", Surname = "Admin", Login = "admin" };
            var type1 = new DocumentType { Symbol = "Przyjecie", Description = "Przyjęcie na stan" };
            var user2 = new User { Name = "User", Surname = "User", Login = "user" };
            var type2 = new DocumentType { Symbol = "Zwrot", Description = "Zwrot ze stanu" };

            List<DocumentHeader> headers = new List<DocumentHeader>
            {
                new DocumentHeader
                {
                    Description = "Desc 1",
                    Year = 2023,
                    Number = 1,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type1,
                },
                new DocumentHeader
                {
                    Description = "Desc 2",
                    Year = 2023,
                    Number = 2,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type1,
                },
                new DocumentHeader
                {
                    Description = "Desc 3",
                    Year = 2023,
                    Number = 3,
                    Date = DateTime.Now,
                    User = user2,
                    DocumentType = type2,
                },
                new DocumentHeader
                {
                    Description = "Desc 4",
                    Year = 2023,
                    Number = 4,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type2,
                },
                new DocumentHeader
                {
                    Description = "Desc 5",
                    Year = 2023,
                    Number = 5,
                    Date = DateTime.Now,
                    User = user2,
                    DocumentType = type2,
                },
            };

            await _dbContext.DocumentHeaders.AddRangeAsync(headers);
            await _dbContext.SaveChangesAsync();

            var userId1 = user1.Id;
            var userId2 = user2.Id;

            var count1 = headers.Where(h => h.User.Id == userId1).Count();
            var count2 = headers.Where(h => h.User.Id == userId2).Count();

            // Act
            var result1 = await documentHeaderRepository.GetDocumentsByUserId(userId1);
            var result2 = await documentHeaderRepository.GetDocumentsByUserId(userId2);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Count, count1);
            Assert.Equal(result2.Count, count2);
        }

        [Fact]
        public async Task GetDokumentsByTypeTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(GetDokumentsByTypeTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            var user1 = new User { Name = "Admin", Surname = "Admin", Login = "admin" };
            var type1 = new DocumentType { Symbol = "Przyjecie", Description = "Przyjęcie na stan" };
            var user2 = new User { Name = "User", Surname = "User", Login = "user" };
            var type2 = new DocumentType { Symbol = "Zwrot", Description = "Zwrot ze stanu" };

            List<DocumentHeader> headers = new List<DocumentHeader>
            {
                new DocumentHeader
                {
                    Description = "Desc 1",
                    Year = 2023,
                    Number = 1,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type1,
                },
                new DocumentHeader
                {
                    Description = "Desc 2",
                    Year = 2023,
                    Number = 2,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type1,
                },
                new DocumentHeader
                {
                    Description = "Desc 3",
                    Year = 2023,
                    Number = 3,
                    Date = DateTime.Now,
                    User = user2,
                    DocumentType = type2,
                },
                new DocumentHeader
                {
                    Description = "Desc 4",
                    Year = 2023,
                    Number = 4,
                    Date = DateTime.Now,
                    User = user1,
                    DocumentType = type2,
                },
                new DocumentHeader
                {
                    Description = "Desc 5",
                    Year = 2023,
                    Number = 5,
                    Date = DateTime.Now,
                    User = user2,
                    DocumentType = type2,
                },
            };

            await _dbContext.DocumentHeaders.AddRangeAsync(headers);
            await _dbContext.SaveChangesAsync();

            var typeId1 = type1.Symbol;
            var typeId2 = type2.Symbol;

            var count1 = headers.Where(h => h.DocumentType.Symbol == typeId1).Count();
            var count2 = headers.Where(h => h.DocumentType.Symbol == typeId2).Count();

            // Act
            var result1 = await documentHeaderRepository.GetDocumentsByType(typeId1);
            var result2 = await documentHeaderRepository.GetDocumentsByType(typeId2);

            // Assert
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.Equal(result1.Count, count1);
            Assert.Equal(result2.Count, count2);
        }

        [Fact]
        public async Task AddDocumentHeaderTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(AddDocumentHeaderTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            var users = UserSeeder.CreateUsers();
            var types = DocumentTypeSeeder.CreateDocumentTypes();

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.DocumentTypes.AddRangeAsync(types);
            await _dbContext.SaveChangesAsync();

            var documentHeader = new DocumentHeader
            {
                Description = "Desc 1",
                Year = 2023,
                Number = 1,
                Date = DateTime.Now,
                User = users[0],
                DocumentType = types[0],
            };

            // Act
            await documentHeaderRepository.AddDocument(documentHeader);

            // Assert
            Assert.Single(_dbContext.DocumentHeaders);
            var addedDocument = await _dbContext
                .DocumentHeaders.FirstOrDefaultAsync();
            Assert.NotNull(addedDocument);
        }

        [Fact]
        public async Task UpdateDocumentTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(UpdateDocumentTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            var user1 = new User { Name = "Admin", Surname = "Admin", Login = "admin" };
            var type1 = new DocumentType { Symbol = "Przyjecie", Description = "Przyjęcie na stan" };

            var documentHeader = new DocumentHeader
            {
                Description = "Desc 1",
                Year = 2023,
                Number = 1,
                Date = DateTime.Now,
                User = user1,
                DocumentType = type1,
            };

            await _dbContext.DocumentHeaders.AddAsync(documentHeader);
            await _dbContext.SaveChangesAsync();

            // Act
            documentHeader.Description = "New Description";
            documentHeader.Date = DateTime.Now.AddDays(2);
            await documentHeaderRepository.UpdateDocument(documentHeader);

            // Assert
            var updatedDocument = await _dbContext
                .DocumentHeaders.FirstOrDefaultAsync();
            Assert.NotNull(updatedDocument);
            Assert.Equal(documentHeader.Id, updatedDocument.Id);
            Assert.Equal(documentHeader.Date, updatedDocument.Date);
            Assert.Equal(documentHeader.Description, updatedDocument.Description);
            Assert.Equal(documentHeader.Year, updatedDocument.Year);
        }

        [Fact]
        public async Task DeleteDocumentTest()
        {
            using var _dbContext = new LabelDbContext(CreateOptions(nameof(DeleteDocumentTest)));

            // Arrange
            var documentHeaderRepository = new DocumentHeaderRepository(_dbContext);

            var users = UserSeeder.CreateUsers();
            var types = DocumentTypeSeeder.CreateDocumentTypes();

            await _dbContext.Users.AddRangeAsync(users);
            await _dbContext.DocumentTypes.AddRangeAsync(types);
            await _dbContext.SaveChangesAsync();

            var documentHeader = new DocumentHeader
            {
                Description = "Desc 1",
                Year = 2023,
                Number = 1,
                Date = DateTime.Now,
                User = users[0],
                DocumentType = types[0],
            };

            await _dbContext.DocumentHeaders.AddAsync(documentHeader);
            await _dbContext.SaveChangesAsync();

            // Act
            await documentHeaderRepository.DeleteDocument(documentHeader);

            // Assert
            var result = await _dbContext
                .DocumentHeaders.FirstOrDefaultAsync(h => h.Id == documentHeader.Id);
            Assert.Null(result);
        }
    }
}
