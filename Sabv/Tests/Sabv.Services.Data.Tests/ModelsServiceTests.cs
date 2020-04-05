namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Web.ViewModels.Models;
    using Xunit;

    public class ModelsServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Models.Add(new Model());
            dbContext.Models.Add(new Model());
            dbContext.Models.Add(new Model());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task GetAllGenericShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllGenericShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Models.Add(new Model() { Name = "1", MakeId = 1 });
            dbContext.Models.Add(new Model() { Name = "2", MakeId = 2 });
            dbContext.Models.Add(new Model() { Name = "3", MakeId = 3 });
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);
            Assert.Equal(3, service.GetAll<ModelsReturnModel>().Count());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowNullExceptionForInvalidName(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowNullExceptionForInvalidName").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name, new Make()));
        }

        [Fact]
        public async Task AddAsyncShouldThrowNullExceptionForInvalidMake()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowNullExceptionForInvalidMake").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync("M5", null));
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);

            Assert.Empty(service.GetAll());

            await service.AddAsync("M5", new Make());

            Assert.Single(service.GetAll());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetModelByNameShouldThrowNullExceptionForInvalidName(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowNullExceptionForInvalidName").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);

            Assert.Throws<ArgumentNullException>(() => service.GetModelByName(name));
        }

        [Fact]
        public async Task GetModelByNameShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "GetModelByNameShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Model>(dbContext);
            var service = new ModelsService(repository);

            await service.AddAsync("M5", new Make());

            Assert.Equal("M5", service.GetModelByName("M5").Name);
        }
    }
}
