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

    public class VehicleCategoriesServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.VehicleCategories.Add(new VehicleCategory());
            dbContext.VehicleCategories.Add(new VehicleCategory());
            dbContext.VehicleCategories.Add(new VehicleCategory());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var service = new VehicleCategoriesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task GetByNameShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetByNameShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var service = new VehicleCategoriesService(repository);

            await service.AddAsync("Sedan");

            Assert.Equal("Sedan", service.GetVehicleCategoryByName("Sedan").Name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetByNameShouldThrowArgumentNullForInvalidName(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetByNameShouldThrowArgumentNullForInvalidName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var service = new VehicleCategoriesService(repository);

            Assert.Throws<ArgumentNullException>(() => service.GetVehicleCategoryByName(name));
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var service = new VehicleCategoriesService(repository);

            Assert.Empty(service.GetAll());

            await service.AddAsync("Sedan");

            Assert.Single(service.GetAll());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowArgumentNullForInvalidName(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentNullForInvalidName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<VehicleCategory>(dbContext);
            var service = new VehicleCategoriesService(repository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name));
        }
    }
}
