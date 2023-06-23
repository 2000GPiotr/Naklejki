using AutoMapper;
using Database.Entities;
using Moq;
using Repository.Interfaces;
using Services.DataTransferModels.LabelStatus;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsServices
{
    public class LabelStatusTests
    {
        [Fact]
        public async Task GetAllTests()
        {
            //Arrange
            var statuses = new List<LabelStatus>
            {
                new LabelStatus{ Symbol = "s1", Description = "Description1"},
                new LabelStatus{ Symbol = "s2", Description = "Description2"},
                new LabelStatus{ Symbol = "s3", Description = "Description3"}
            };
            var statusesDto = new List<LabelStatusDto>
            {
                new LabelStatusDto{ Symbol = "s1", Description = "Description1"},
                new LabelStatusDto{ Symbol = "s2", Description = "Description2"},
                new LabelStatusDto{ Symbol = "s3", Description = "Description3"}
            };

            var labelStatusRepositoryMock = new Mock<ILabelStatusRepository>();
            labelStatusRepositoryMock.Setup(repository => repository.GetAllLabelStatus())
                .ReturnsAsync(statuses);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<List<LabelStatusDto>>(statuses))
                .Returns(statusesDto);

            var _labelStatusService = new LabelStatusService(labelStatusRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await _labelStatusService.GetLabelStatuses();

            // Assert
            Assert.Equal(statusesDto, result);
            labelStatusRepositoryMock.Verify(repository => repository.GetAllLabelStatus(), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<List<LabelStatusDto>>(statuses), Times.Once);
        }

        [Fact]
        public async Task GetLabelStatusesBySymbol_MainPath()
        {
            // Arrange
            var symbol = "s1";
            var status = new LabelStatus { Symbol = "s1", Description = "Description1" };
            var statusDto = new LabelStatusDto { Symbol = "s1", Description = "Description1" };

            var labelStatusRepositoryMock = new Mock<ILabelStatusRepository>();
            labelStatusRepositoryMock.Setup(repository => repository.GetLabelStatusBySymbol(symbol))
                .ReturnsAsync(status);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(mapper => mapper.Map<LabelStatusDto>(status))
                .Returns(statusDto);

            var _labelStatusService = new LabelStatusService(labelStatusRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await _labelStatusService.GetLabelStatusBySymbol(symbol);

            // Assert
            Assert.Equal(statusDto, result);
            labelStatusRepositoryMock.Verify(repository => repository.GetLabelStatusBySymbol(symbol), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelStatusDto>(status), Times.Once);
        }

        [Fact]
        public async Task GetLabelStatusesBySymbol_NullFromRepository()
        {
            // Arrange
            var symbol = "nonExistingSymbol";

            var labelStatusRepositoryMock = new Mock<ILabelStatusRepository>();
            labelStatusRepositoryMock.Setup(repository => repository.GetLabelStatusBySymbol(symbol))
                .ReturnsAsync((LabelStatus)null);

            var mapperMock = new Mock<IMapper>();

            var _labelStatusService = new LabelStatusService(labelStatusRepositoryMock.Object, mapperMock.Object);

            // Act
            var act = async () => await _labelStatusService.GetLabelStatusBySymbol(symbol);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            labelStatusRepositoryMock.Verify(repository => repository.GetLabelStatusBySymbol(symbol), Times.Once);
            mapperMock.Verify(mapper => mapper.Map<LabelStatusDto>(It.IsAny<LabelStatus>()), Times.Never);
        }
    }
}
