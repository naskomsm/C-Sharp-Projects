namespace Sabv.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Sabv.Data;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Web.ViewModels.Category;
    using Xunit;

    public class CategoriesServiceTests
    {
        [Fact]
        public async Task GetByNameShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GetByName").Options;
            var dbContext = new ApplicationDbContext(options);
            await dbContext.Categories.AddAsync(new Category() { Name = "Cars" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Jeeps" });
            await dbContext.Categories.AddAsync(new Category() { Name = "Buses" });
            await dbContext.SaveChangesAsync();

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            Assert.Equal("Cars", service.GetCategoryByName("Cars").Name);
        }

        [Fact]
        public async Task AddAsyncShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AddAsync").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync("Name", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "random descr");
            await service.AddAsync("Name 2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "random descr 2");
            Assert.Equal(2, service.GetAll().Count());
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

        [Fact]
        public async Task GetAllTemplateShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "GetAllTemplate").Options;
            var dbContext = new ApplicationDbContext(options);
            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);

            await service.AddAsync("Name", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "random descr");
            await service.AddAsync("Name 2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "random descr 2");
            await service.AddAsync("Name 3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "random descr 3");

            var templates = service.GetAll<CategoryViewModel>();

            Assert.Equal(3, templates.Count());
        }
    }
}
