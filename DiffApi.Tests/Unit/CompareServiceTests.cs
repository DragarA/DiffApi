using DiffApi.Entities;
using DiffApi.Services;

namespace DiffApi.Tests.Unit
{
    public class CompareServiceTests
    {
        [Fact]
        public Task Compare_ShouldReturnEquals()
        {
            var service = new CompareService();

            var entity = new DiffData
            {
                Id = 1,
                LeftValue = "AAAAAA==",
                RightValue = "AAAAAA=="
            };

            var result = service.Compare(entity);

            Assert.NotNull(result);
            Assert.Null(result.Diffs);
            Assert.Equal("Equals", result.DiffResultType);
            return Task.CompletedTask;
        }

        [Fact]
        public Task Compare_ShouldReturnContentDoNotMatch()
        {
            var service = new CompareService();

            var entity = new DiffData
            {
                Id = 1,
                LeftValue = "AAAAAA==",
                RightValue = "AQABAQ=="
            };

            var result = service.Compare(entity);

            Assert.NotNull(result);
            Assert.NotNull(result.Diffs);
            Assert.Equal(2, result.Diffs.Count);
            Assert.Equal(0, result.Diffs[0].Offset);
            Assert.Equal(1, result.Diffs[0].Length);
            Assert.Equal(2, result.Diffs[1].Offset);
            Assert.Equal(2, result.Diffs[1].Length);

            Assert.Equal("ContentDoNotMatch", result.DiffResultType);
            return Task.CompletedTask;
        }

        [Fact]
        public Task Compare_ShouldReturnSizeDoNotMatch()
        {
            var service = new CompareService();

            var entity = new DiffData
            {
                Id = 1,
                LeftValue = "AAAAAA==",
                RightValue = "AAA="
            };

            var result = service.Compare(entity);

            Assert.NotNull(result);
            Assert.Null(result.Diffs);
            Assert.Equal("SizeDoNotMatch", result.DiffResultType);

            return Task.CompletedTask;
        }
    }
}

