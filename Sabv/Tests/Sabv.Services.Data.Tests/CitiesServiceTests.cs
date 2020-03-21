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

    public class CitiesServiceTests
    {
        [Theory]
        [InlineData("Stara Zagora")]
        [InlineData("Sofia")]
        public async Task GetByNameShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);
            await service.AddAsync(name);

            Assert.Equal(name, service.GetCityByName(name).Name);
        }

        [Theory]
        [InlineData("Stara Zagora")]
        [InlineData("Sofia")]
        public async Task AddAsyncShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);
            await service.AddAsync(name);
            Assert.True(repository.All().Any(x => x.Name == name));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetByNameShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);

            Assert.Throws<ArgumentNullException>(() => service.GetCityByName(name));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name));
        }

        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAll").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Cities.Add(new City());
            dbContext.Cities.Add(new City());
            dbContext.Cities.Add(new City());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<City>(dbContext);
            var service = new CitiesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }
    }
}
