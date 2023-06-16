using AutoMapper;
using Database.Entities;
using Moq;
using Repository.Interfaces;
using Services.DataTransferModels.LabelType;
using Services.Services;

namespace TestsServices
{
    public class LabelTypeTests
    {
        [Fact]
        public async Task CreateTest()
        {
            // Arrange
            var labelTypeDto = new LabelTypeDto { Symbol = "S3", Description = "Opis", Count = 1410 };
            var newLabelType = new LabelType { Symbol = "S3", Description = "Opis", Count = 1410 };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.AddLabelType(It.IsAny<LabelType>()))
                .Verifiable();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<LabelType>(labelTypeDto))
                .Returns(newLabelType);
            mapperMock.Setup(mapper => mapper.Map<LabelTypeDto>(newLabelType))
                .Returns(labelTypeDto);

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await labelTypeService.CreateLabelType(labelTypeDto);

            // Assert
            labelTypeRepositoryMock.Verify(repo => repo.AddLabelType(It.IsAny<LabelType>()), Times.Once);

            mapperMock.Verify(mapper => mapper.Map<LabelType>(labelTypeDto), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(newLabelType), Times.Once);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllTest()
        {
            // Arrange
            var labelTypes = new List<LabelType>
            {
                new LabelType { Symbol = "S1", Description = "S1 Desc", Count = 992 },
                new LabelType { Symbol = "S2", Description = "S2 Desc", Count = 966 },
                new LabelType { Symbol = "S3", Description = "S3 Desc", Count = 1025 }
            };

            var expectedLabelTypeDtos = new List<LabelTypeDto>
            {
                new LabelTypeDto { Symbol = "S1", Description = "S1 Desc", Count = 992 },
                new LabelTypeDto { Symbol = "S2", Description = "S2 Desc", Count = 966 },
                new LabelTypeDto { Symbol = "S3", Description = "S3 Desc", Count = 1025  }
            };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetAllLabelTypes())
                .ReturnsAsync(labelTypes);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<LabelTypeDto>>(labelTypes))
                .Returns(expectedLabelTypeDtos);

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await labelTypeService.GetAllLabelTypes();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedLabelTypeDtos, result);
            labelTypeRepositoryMock.Verify(repo => repo.GetAllLabelTypes(), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<LabelTypeDto>>(labelTypes), Times.Once);
        }

        [Fact]
        public async Task GetBySymbolTest_MainPath()
        {
            // Arrange
            var symbol = "S1";
            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            var expectedLabelTypeDto = new LabelTypeDto { Symbol = "S1", Description = "Desc 1", Count = 1410 };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync(labelType);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<LabelTypeDto>(labelType))
                .Returns(expectedLabelTypeDto);

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await labelTypeService.GetLabelTypeBySymbol(symbol);

            // Assert

            Assert.NotNull(result);
            Assert.Equal(expectedLabelTypeDto, result);
            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(labelType), Times.Once);
        }

        [Fact]
        public async Task GetBySymbolTest_NullFromRepository()
        {
            // Arrange
            var symbol = "NonExistingSymbol";

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync((LabelType)null);

            var mapperMock = new Mock<IMapper>();

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var act = async () => await labelTypeService.GetLabelTypeBySymbol(symbol);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);

            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(It.IsAny<LabelType>()), Times.Never);
        }

        [Fact]
        public async Task DeleteTest_MainPath()
        {
            // Arrange
            var symbol = "S1";
            var labelType = new LabelType { Symbol = "S1", Description = "Desc 1", Count = 1410 };
            var expectedLabelTypeDto = new LabelTypeDto { Symbol = "S1", Description = "Desc 1", Count = 1410 };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync(labelType);
            labelTypeRepositoryMock.Setup(repo => repo.DeleteLabelType(labelType))
                .Verifiable();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<LabelTypeDto>(It.IsAny<LabelType>()))
                .Returns(expectedLabelTypeDto);

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await labelTypeService.DeleteLabelTypeBySymbol(symbol);

            // Assert
            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            labelTypeRepositoryMock.Verify(repo => repo.DeleteLabelType(labelType), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(It.IsAny<LabelType>()), Times.Once);

            Assert.Equal(expectedLabelTypeDto, result);
        }

        [Fact]
        public async Task DeleteTest_NullFromRepository()
        {
            // Arrange
            string symbol = "NonExistingSymbol";

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync((LabelType)null);

            var mapperMock = new Mock<IMapper>();

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var act = async () => await labelTypeService.DeleteLabelTypeBySymbol(symbol);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);

            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            labelTypeRepositoryMock.Verify(repo => repo.DeleteLabelType(It.IsAny<LabelType>()), Times.Never);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(It.IsAny<LabelType>()), Times.Never);
        }

        [Fact]
        public async Task UpdateTest_MainPath()
        {
            // Arrange
            string symbol = "S1";
            var labelTypeDto = new UpdateLabelTypeDto { Description = "New Description", Count = 1410 };
            var existingLabelType = new LabelType { Symbol = "S1", Description = "Old Description", Count = 966 };
            var expectedLabelTypeDto = new LabelTypeDto { Symbol = "S1", Description = "New Description", Count = 1410 };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync(existingLabelType);
            labelTypeRepositoryMock.Setup(repo => repo.UpdateLabelType(existingLabelType))
                .Returns(Task.CompletedTask);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map(labelTypeDto, existingLabelType))
                .Verifiable();
            mapperMock.Setup(mapper => mapper.Map<LabelTypeDto>(existingLabelType))
                .Returns(expectedLabelTypeDto);

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await labelTypeService.UpdateLabelTypeBySymbol(symbol, labelTypeDto);

            // Assert
            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            labelTypeRepositoryMock.Verify(repo => repo.UpdateLabelType(existingLabelType), Times.Once);
            mapperMock.Verify(mapper => mapper.Map(labelTypeDto, existingLabelType), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(existingLabelType), Times.Once);

            Assert.Equal(expectedLabelTypeDto, result);
        }

        [Fact]
        public async Task UpdateTest_NullFromRepository()
        {
            // Arrange
            string symbol = "NonExistingSymbol";
            var labelTypeDto = new UpdateLabelTypeDto { Description = "New Description", Count = 1410 };

            var labelTypeRepositoryMock = new Mock<ILabelTypeRepository>();
            labelTypeRepositoryMock.Setup(repo => repo.GetLabelTypeBySymbol(symbol))
                .ReturnsAsync((LabelType)null);

            var mapperMock = new Mock<IMapper>();

            var labelTypeService = new LabelTypeService(labelTypeRepositoryMock.Object, mapperMock.Object);

            // Act
            var act = async () => await labelTypeService.UpdateLabelTypeBySymbol(symbol, labelTypeDto);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);

            labelTypeRepositoryMock.Verify(repo => repo.GetLabelTypeBySymbol(symbol), Times.Once);
            labelTypeRepositoryMock.Verify(repo => repo.UpdateLabelType(It.IsAny<LabelType>()), Times.Never);
            mapperMock.Verify(mapper => mapper.Map(It.IsAny<UpdateLabelTypeDto>(), It.IsAny<LabelType>()), Times.Never);
            mapperMock.Verify(mapper => mapper.Map<LabelTypeDto>(It.IsAny<LabelType>()), Times.Never);
        }

    }
}
