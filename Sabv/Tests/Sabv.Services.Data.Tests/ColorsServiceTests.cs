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

    public class ColorsServiceTests
    {
        [Theory]
        [InlineData("Blue")]
        [InlineData("Red")]
        public async Task GetByNameShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Color>(dbContext);
            var service = new ColorService(repository);
            await service.AddAsync(name);

            Assert.Equal(name, service.GetColorByName(name).Name);
        }

        [Theory]
        [InlineData("Black")]
        [InlineData("White")]
        public async Task AddAsyncShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Color>(dbContext);
            var service = new ColorService(repository);
            await service.AddAsync(name);
            Assert.True(repository.All().Any(x => x.Name == name));
        }

        [Theory]
        [InlineData(null)]
        public async Task AddAsyncShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Color>(dbContext);
            var service = new ColorService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name));
        }

        [Theory]
        [InlineData(null)]
        public void GetByNameShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Color>(dbContext);
            var service = new ColorService(repository);
            Assert.Throws<ArgumentNullException>(() => service.GetColorByName(name));
        }

        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAll").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Colors.Add(new Color());
            dbContext.Colors.Add(new Color());
            dbContext.Colors.Add(new Color());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Color>(dbContext);
            var service = new ColorService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }
    }
}
