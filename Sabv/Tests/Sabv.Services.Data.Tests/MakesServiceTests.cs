namespace Sabv.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Services.Mapping;
    using Xunit;

    public class MakesServiceTests
    {
        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Makes.Add(new Make());
            dbContext.Makes.Add(new Make());
            dbContext.Makes.Add(new Make());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }

        [Fact]
        public async Task GetAllGenericShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllGenericShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Makes.Add(new Make());
            dbContext.Makes.Add(new Make());
            dbContext.Makes.Add(new Make());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            Assert.Equal(3, service.GetAll<Make>().Count());
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            await service.AddAsync("BMW");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowArgumentNull(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentNull").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name));
        }

        [Fact]
        public async Task AddAsyncShouldThrowArgumentForExistingEntity()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "AddAsyncShouldThrowArgumentForExistingEntity").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            await service.AddAsync("BMW");
            await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync("BMW"));
        }

        [Fact]
        public async Task GetMakeByIdShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "GetMakeByIdShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            await service.AddAsync("BMW");
            Assert.Equal("BMW", service.GetMakeById(1).Name);
        }

        [Fact]
        public void GetMakeByIdShouldThrowErrorForNotExistingMake()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "GetMakeByIdShouldThrowErrorForNotExistingMake").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            Assert.Throws<ArgumentNullException>(() => service.GetMakeById(1));
        }

        [Fact]
        public async Task GetMakeByNameShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "GetMakeByNameShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            await service.AddAsync("BMW");
            Assert.Equal("BMW", service.GetMakeByName("BMW").Name);
        }

        [Fact]
        public void GetMakeByNameShouldThrowErrorForNotExistingMake()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "GetMakeByIdShouldThrowErrorForNotExistingMake").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Make>(dbContext);
            var service = new MakesService(repository);
            Assert.Throws<ArgumentNullException>(() => service.GetMakeByName("BMW"));
        }
    }
}
