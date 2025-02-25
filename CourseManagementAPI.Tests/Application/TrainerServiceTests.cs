using AutoMapper;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Application.Services;
using CourseManagementAPI.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Tests.Application
{
    public class TrainerServiceTests
    {
        private readonly Mock<ITrainerRepository> _trainerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock; 
        private readonly TrainerService _trainerService;

        public TrainerServiceTests()
        {
            _trainerRepositoryMock = new Mock<ITrainerRepository>();
            _mapperMock = new Mock<IMapper>();

            _trainerService = new TrainerService(_trainerRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetTrainerByIdAsync_ReturnsTrainer_WhenTrainerExists()
        {
            var trainerId = "1";
            var trainer = new Trainer { Id = trainerId, UserName = "khaledtarek" };

            _trainerRepositoryMock.Setup(repo => repo.GetTrainerByIdAsync(trainerId))
                .ReturnsAsync(trainer);

            var result = await _trainerService.GetTrainerByIdAsync(trainerId);

            Assert.NotNull(result);
            Assert.Equal(trainerId, result.Id);
            Assert.Equal("khaledtarek", result.UserName);
        }

        [Fact]
        public async Task GetTrainerByIdAsync_ReturnsNull_WhenTrainerDoesNotExist()
        {            var trainerId = "non-existent-id";
            _trainerRepositoryMock.Setup(repo => repo.GetTrainerByIdAsync(trainerId))
                                  .ReturnsAsync((Trainer?)null);
            var result = await _trainerService.GetTrainerByIdAsync(trainerId);


            Assert.Null(result);
        }
        


    }
}
