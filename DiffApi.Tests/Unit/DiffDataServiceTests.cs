using System;
using DiffApi.Entities;
using DiffApi.Repositories;
using DiffApi.Services;
using Moq;

namespace DiffApi.Tests.Unit
{
    public class DiffDataServiceTests
    {
        [Fact]
        public async Task SaveDiffData_ShouldSaveEntity()
        {
            var mockRepository = new Mock<IDiffDataRepository>();
            var service = new DiffDataService(mockRepository.Object);

            await service.CreateOrUpdate(1, Utils.DiffSideEnum.Left, "Value");

            mockRepository.Verify(repo => repo.Save(It.IsAny<DiffData>()), Times.Once);
        }

        [Fact]
        public async Task GetDiffData_ShouldReturnEntity()
        {
            var mockRepository = new Mock<IDiffDataRepository>();
            var service = new DiffDataService(mockRepository.Object);
            var entity = new DiffData
            {
                Id = 1,
                LeftValue = "Left",
                RightValue = "Right"
            };

            mockRepository.Setup(repo => repo.Get(entity.Id)).ReturnsAsync(entity);


            var result = await service.GetById(entity.Id);

            mockRepository.Verify(repo => repo.Get(entity.Id), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal(entity.LeftValue, result.LeftValue);
            Assert.Equal(entity.RightValue, result.RightValue);
        }
    }

}