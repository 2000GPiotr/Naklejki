using AutoMapper;
using Database.Entities;
using Moq;
using Repository.Interfaces;
using Services.DataTransferModels.Document;
using Services.DataTransferModels.User;
using Services.Services;

namespace TestsServices
{
    public class DocumentHeaderTests //TODO
    {
        [Fact]
        public async Task GetAllDocumentHeaderTests()
        {
            // Arrange
            var headers = new List<DocumentHeader>()
            {
                new DocumentHeader()
                {
                    Id = 1,
                    Number = 1,
                    Date = DateTime.Now,
                    User = null,
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentHeader()
                {
                    Id = 2,
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    User = null,
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D1",
                        Description = "desc2"
                    },
                },
            };
            var headersDto = new List<DocumentDto>()
            {
                new DocumentDto()
                {
                    Number = 1,
                    Date = DateTime.Now,
                    User = null,
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentDto()
                {
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    User = null,
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D1",
                        Description = "desc2"
                    },
                }
            };

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetAllDocuments())
                .ReturnsAsync(headers);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<DocumentDto>>(headers))
                .Returns(headersDto);

            var userRepositoryMock = new Mock<IUserRepository>();

            var itemRepositoryMock = new Mock<IItemRepository>();

            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var _documentHeaderService = new DocumentHeaderService(mapperMock.Object, documentHeaderRepositoryMock.Object, userRepositoryMock.Object, itemRepositoryMock.Object, documentTypeRepositoryMock.Object);

            // Act
            var result = await _documentHeaderService.GetAllDocuments();

            // Assert
            Assert.Equal(headersDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetAllDocuments(), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<DocumentDto>>(headers), Times.Once);
        }

        [Fact]
        public async Task GetDocumentByIdTest_MainPath()
        {
            // Arrange
            var header = new DocumentHeader()
            {
                Id = 1,
                Number = 1,
                Date = DateTime.Now,
                User = null,
                Description = "abc",
                Year = 2020,
                DocumentType = new DocumentType()
                {
                    Symbol = "D2",
                    Description = "desc1"
                },
            };

            var headerDto = new DocumentDto()
            {
                Number = 1,
                Date = DateTime.Now,
                User = null,
                Description = "abc",
                Year = 2020,
                DocumentType = new DocumentTypeDto()
                {
                    Symbol = "D2",
                    Description = "desc1"
                },
            };

            var documentId = 1;

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentById(documentId))
                .ReturnsAsync(header);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<DocumentDto>(header))
                .Returns(headerDto);

            var userRepositoryMock = new Mock<IUserRepository>();

            var itemRepositoryMock = new Mock<IItemRepository>();

            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var _documentHeaderService = new DocumentHeaderService(mapperMock.Object, documentHeaderRepositoryMock.Object, userRepositoryMock.Object, itemRepositoryMock.Object, documentTypeRepositoryMock.Object);

            // Act
            var result = await _documentHeaderService.GetDocumentById(documentId);

            //Assert
            Assert.Equal(headerDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentById(documentId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(header), Times.Once);
        }

        [Fact]
        public async Task GetDocumentsByTypeTest_MainPath()
        {
            // Arrange
            var headers = new List<DocumentHeader>()
            {
                new DocumentHeader()
                {
                    Id = 1,
                    Number = 1,
                    Date = DateTime.Now,
                    User = null,
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentHeader()
                {
                    Id = 2,
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    User = null,
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
            };

            var headersDto = new List<DocumentDto>()
            {
                new DocumentDto()
                {
                    Number = 1,
                    Date = DateTime.Now,
                    User = null,
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentDto()
                {
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    User = null,
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                }
            };

            var symbol = "D2";

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentsByType(symbol))
                .ReturnsAsync(headers);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<DocumentDto>>(headers))
                .Returns(headersDto);

            var userRepositoryMock = new Mock<IUserRepository>();

            var itemRepositoryMock = new Mock<IItemRepository>();

            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var _documentHeaderService = new DocumentHeaderService(mapperMock.Object, documentHeaderRepositoryMock.Object, userRepositoryMock.Object, itemRepositoryMock.Object, documentTypeRepositoryMock.Object);

            // Act
            var result = await _documentHeaderService.GetDocumentsByType(symbol);

            //Assert
            Assert.Equal(headersDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentsByType(symbol), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<DocumentDto>>(headers), Times.Once);
        }

        [Fact]
        public async Task GetDocumentsByUserIdTest_MainPath()
        {
            // Arrange
            var headers = new List<DocumentHeader>()
            {
                new DocumentHeader()
                {
                    Id = 1,
                    Number = 1,
                    Date = DateTime.Now,
                    UserId = 1,
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentHeader()
                {
                    Id = 2,
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    UserId = 1,
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentType()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
            };

            var headersDto = new List<DocumentDto>()
            {
                new DocumentDto()
                {
                    Number = 1,
                    Date = DateTime.Now,
                    User = new UserDto(),
                    Description = "abc",
                    Year = 2020,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                },
                new DocumentDto()
                {
                    Number = 2,
                    Date = DateTime.Now.AddDays(1),
                    User = new UserDto(),
                    Description = "abc",
                    Year = 2021,
                    DocumentType = new DocumentTypeDto()
                    {
                        Symbol = "D2",
                        Description = "desc1"
                    },
                }
            };

            var userId = 1;

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentsByUserId(userId))
                .ReturnsAsync(headers);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<DocumentDto>>(headers))
                .Returns(headersDto);

            var userRepositoryMock = new Mock<IUserRepository>();

            var itemRepositoryMock = new Mock<IItemRepository>();

            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var _documentHeaderService = new DocumentHeaderService(mapperMock.Object, documentHeaderRepositoryMock.Object, userRepositoryMock.Object, itemRepositoryMock.Object, documentTypeRepositoryMock.Object);

            // Act
            var result = await _documentHeaderService.GetDocumentsByUserId(userId);

            //Assert
            Assert.Equal(headersDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentsByUserId(userId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<DocumentDto>>(headers), Times.Once);
        }

        [Fact]
        public async Task AddDocumentTest_MainPath()
        {
            // Arrange
            var itemRanges = new List<ItemRangeDto>()
            {
                new ItemRangeDto()
                {
                    FirstItem = new ItemDto()
                    {
                        LabelNumberPrefix = "A",
                        LabelNumber = "1",
                        LabelNumberSuffix = ""
                    },
                    LastItem = new ItemDto()
                    {
                        LabelNumberPrefix = "A",
                        LabelNumber = "3",
                        LabelNumberSuffix = ""
                    },
                    LabelTypeSymbol = "S2"
                },
                new ItemRangeDto()
                {
                    FirstItem = new ItemDto()
                    {
                        LabelNumberPrefix = "",
                        LabelNumber = "1",
                        LabelNumberSuffix = "B"
                    },
                    LastItem = new ItemDto()
                    {
                        LabelNumberPrefix = "",
                        LabelNumber = "4",
                        LabelNumberSuffix = "B"
                    },
                    LabelTypeSymbol = "S3"
                }
            };

            var addDocumentDto = new AddDocumentDto()
            {
                UserId = 1,
                DocumentTypeSymbol = "D2",
                ItemsList = itemRanges
            };

            var documentType = new DocumentType()
            {
                Symbol = "D2",
                Description = "desc1"
            };
                        
            var header = new DocumentHeader()
            {
                Id = 2,
                Number = 2,
                Date = DateTime.Now.AddDays(1),
                UserId = 1,
                Description = "abc",
                Year = 2021,
                DocumentType = documentType,
            };

            var user = new User
            {
                Id = 1,
                Login = "user1",
                Name = "John",
                Surname = "Kowalski",
                Password = new Password { Id = 1, Round = 1, Salt = new byte[] { 1, 2, 3 }, Hash = new byte[] { 4, 5, 6 } }
            };

            var headerDto = new DocumentDto()
            {
                Number = 2,
                Date = DateTime.Now.AddDays(1),
                User = null,
                Description = "abc",
                Year = 2021,
                DocumentType = null
            };

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.AddDocument(header))
                .Verifiable();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<DocumentHeader>(addDocumentDto))
                .Returns(header);
            mapperMock.Setup(mapper => mapper.Map<DocumentDto>(header))
                .Returns(headerDto);

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repository => repository.GetUserById(user.Id))
                .ReturnsAsync(user);

            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();
            documentTypeRepositoryMock.Setup(repository => repository.GetDocumentTypeBySymbol(documentType.Symbol))
                .ReturnsAsync(documentType);

            var itemRepositoryMock = new Mock<IItemRepository>();

            var _documentHeaderService = new DocumentHeaderService(mapperMock.Object, documentHeaderRepositoryMock.Object, userRepositoryMock.Object, itemRepositoryMock.Object, documentTypeRepositoryMock.Object);

            // Act
            var result = await _documentHeaderService.AddDocument(addDocumentDto);

            //Assert
            Assert.Equal(headerDto, result);
            mapperMock.Verify(mapper => mapper.Map<DocumentHeader>(addDocumentDto), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(header), Times.Once);
            userRepositoryMock.Verify(repository => repository.GetUserById(user.Id), Times.Once);
            documentTypeRepositoryMock.Verify(repository => repository.GetDocumentTypeBySymbol(documentType.Symbol), Times.Once);
            documentHeaderRepositoryMock.Verify(repository => repository.AddDocument(header), Times.Once);
        }

        [Fact]
        public async Task DeleteDocumentTest_MainPath()
        {
            // Arrange
            var documentId = 1;

            var header = new DocumentHeader()
            {
                Id = documentId,
            };
            var deletedDocumentDto = new DocumentDto();

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentById(documentId))
                .ReturnsAsync(header);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<DocumentDto>(header))
                .Returns(deletedDocumentDto);

            var userRepositoryMock = new Mock<IUserRepository>();
            var itemRepositoryMock = new Mock<IItemRepository>();
            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var documentHeaderService = new DocumentHeaderService(
                mapperMock.Object,
                documentHeaderRepositoryMock.Object,
                userRepositoryMock.Object,
                itemRepositoryMock.Object,
                documentTypeRepositoryMock.Object);

            // Act
            var result = await documentHeaderService.DeleteDocument(documentId);

            // Assert
            Assert.Equal(deletedDocumentDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentById(documentId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(header), Times.Once);
            documentHeaderRepositoryMock.Verify(repository => repository.DeleteDocument(header), Times.Once);
        }

        [Fact]
        public async Task DeleteDocumentTest_NullFtomRepository()
        {
            // Arrange
            var documentId = 1;

            DocumentHeader header = null;

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentById(documentId))
                .ReturnsAsync(header);

            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var itemRepositoryMock = new Mock<IItemRepository>();
            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var documentHeaderService = new DocumentHeaderService(
                mapperMock.Object,
                documentHeaderRepositoryMock.Object,
                userRepositoryMock.Object,
                itemRepositoryMock.Object,
                documentTypeRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await documentHeaderService.DeleteDocument(documentId));
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentById(documentId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(It.IsAny<DocumentHeader>()), Times.Never);
            documentHeaderRepositoryMock.Verify(repository => repository.DeleteDocument(It.IsAny<DocumentHeader>()), Times.Never);
        }

        [Fact]
        public async Task UpdateDocument_MainPath()
        {
            // Arrange
            var documentId = 1;
            var documentDto = new UpdateDocumentHeaderDto();

            var header = new DocumentHeader();

            var updatedDocumentDto = new DocumentDto();

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentById(documentId))
                .ReturnsAsync(header);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map(documentDto, header));

            mapperMock.Setup(mapper => mapper.Map<DocumentDto>(header))
                .Returns(updatedDocumentDto);

            var userRepositoryMock = new Mock<IUserRepository>();
            var itemRepositoryMock = new Mock<IItemRepository>();
            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var documentHeaderService = new DocumentHeaderService(
                mapperMock.Object,
                documentHeaderRepositoryMock.Object,
                userRepositoryMock.Object,
                itemRepositoryMock.Object,
                documentTypeRepositoryMock.Object);

            // Act
            var result = await documentHeaderService.UpdateDocument(documentDto, documentId);

            // Assert
            Assert.Equal(updatedDocumentDto, result);
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentById(documentId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map(documentDto, header), Times.Once);
            documentHeaderRepositoryMock.Verify(repository => repository.UpdateDocument(header), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(header), Times.Once);
        }

        [Fact]
        public async Task UpdateDocument_NullFromRepository()
        {
            // Arrange
            var documentId = 1;
            var documentDto = new UpdateDocumentHeaderDto();

            DocumentHeader header = null; // Simulate non-existing document

            var documentHeaderRepositoryMock = new Mock<IDocumentHeaderRepository>();
            documentHeaderRepositoryMock.Setup(repository => repository.GetDocumentById(documentId))
                .ReturnsAsync(header);

            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var itemRepositoryMock = new Mock<IItemRepository>();
            var documentTypeRepositoryMock = new Mock<IDocumentTypeRepository>();

            var documentHeaderService = new DocumentHeaderService(
                mapperMock.Object,
                documentHeaderRepositoryMock.Object,
                userRepositoryMock.Object,
                itemRepositoryMock.Object,
                documentTypeRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await documentHeaderService.UpdateDocument(documentDto, documentId));
            documentHeaderRepositoryMock.Verify(repository => repository.GetDocumentById(documentId), Times.Once);
            mapperMock.Verify(mapper => mapper.Map(documentDto, It.IsAny<DocumentHeader>()), Times.Never);
            documentHeaderRepositoryMock.Verify(repository => repository.UpdateDocument(It.IsAny<DocumentHeader>()), Times.Never);
            mapperMock.Verify(mapper => mapper.Map<DocumentDto>(It.IsAny<DocumentHeader>()), Times.Never);
        }
    }
}
