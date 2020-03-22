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

    public class CategoriesServiceTests
    {
        [Theory]
        [InlineData("Cars and Jeeps")]
        [InlineData("Buses")]
        public async Task GetByNameShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByName").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync(name, new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");

            Assert.Equal(name, service.GetCategoryByName(name).Name);
        }

        [Theory]
        [InlineData("Cars and Jeeps")]
        [InlineData("Buses")]
        public async Task AddAsyncShouldWork(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync(name, new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            Assert.True(repository.All().Any(x => x.Name == name));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task AddAsyncShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddAsync(name, new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetByNameShouldThrowNullException(string name)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            Assert.Throws<ArgumentNullException>(() => service.GetCategoryByName(name));
        }

        [Fact]
        public async Task GetAllShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAll").Options;
            var dbContext = new ApplicationDbContext(options);
            dbContext.Categories.Add(new Category());
            dbContext.Categories.Add(new Category());
            dbContext.Categories.Add(new Category());
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            Assert.Equal(3, service.GetAll().Count());
        }
    }
}
