namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Xunit;

    public class ImagesServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Images.Add(new Image());
            dbContext.Images.Add(new Image());
            dbContext.Images.Add(new Image());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task GetAllGenericShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllGenericShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Images.Add(new Image());
            dbContext.Images.Add(new Image());
            dbContext.Images.Add(new Image());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);
            Assert.Equal(3, service.GetAll<Image>().Count());
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);

            Assert.Empty(service.GetAll());

            await service.AddAsync("random string");

            Assert.Single(service.GetAll());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowArgumentNullForInvalidUrl(string url)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentNullForInvalidUrl").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(url));
        }

        [Fact]
        public async Task GetImageByUrlShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetImageByUrlShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);

            await service.AddAsync("random string");

            Assert.Equal("random string", service.GetImageByUrl("random string").Url);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetImageByUrlShouldThrowArgumentNullForInvalidUrl(string url)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentNullForInvalidUrl").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Image>(dbContext);
            var service = new ImagesService(repository);

            Assert.Throws<ArgumentNullException>(() => service.GetImageByUrl(url));
        }
    }
}
