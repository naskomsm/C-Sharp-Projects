namespace Sabv.Data.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Services.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class RepositoriesTests
    {
        [Fact]
        public async Task EfDeletableEntityRepoAllNoTrackingShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EfDeletableEntityRepoAllNoTrackingShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync("test", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            await service.AddAsync("test2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description2");
            await service.AddAsync("test3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description3");

            var categoryToDelete = service.GetCategoryByName("test3");
            repository.Delete(categoryToDelete);
            await repository.SaveChangesAsync();
            var result = repository.AllAsNoTracking().ToList();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task EfDeletableEntityRepoAllNoTrackingWithDeletedShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EfDeletableEntityRepoAllNoTrackingWithDeletedShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync("test", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            await service.AddAsync("test2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description2");
            await service.AddAsync("test3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description3");

            var categoryToDelete = service.GetCategoryByName("test3");
            repository.Delete(categoryToDelete);
            await repository.SaveChangesAsync();
            var result = repository.AllAsNoTrackingWithDeleted().ToList();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task EfDeletableEntityRepoAllWithDeletedShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EfDeletableEntityRepoAllWithDeletedShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);

            var service = new CategoriesService(repository);
            await service.AddAsync("test", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            await service.AddAsync("test2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description2");
            await service.AddAsync("test3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description3");

            var categoryToDelete = service.GetCategoryByName("test3");
            repository.Delete(categoryToDelete);
            await repository.SaveChangesAsync();
            var result = repository.AllWithDeleted().ToList();
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task EfDeletableEntityRepoGetByIdWithDeletedShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EfDeletableEntityRepoGetByIdWithDeletedShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync("test", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            await service.AddAsync("test2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description2");
            await service.AddAsync("test3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description3");

            var categoryToDelete = service.GetCategoryByName("test3");
            repository.Delete(categoryToDelete);
            await repository.SaveChangesAsync();

            var result = await repository.GetByIdWithDeletedAsync(3);
            Assert.Equal(3, result.Id);
            Assert.True(result.IsDeleted);
        }

        [Fact]
        public async Task EfDeletableEntityRepoUndeleteEntityShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "EfDeletableEntityRepoUndeleteEntityShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);
            await service.AddAsync("test", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description");
            await service.AddAsync("test2", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description2");
            await service.AddAsync("test3", new Image() { Url = "https://miau.bg/files/lib/600x350/agresive-cat1.jpg" }, "description3");

            var categoryToDelete = service.GetCategoryByName("test3");
            repository.Delete(categoryToDelete);
            await repository.SaveChangesAsync();

            var category = repository.AllWithDeleted().FirstOrDefault(x => x.Id == 3);
            repository.Undelete(category);
            await repository.SaveChangesAsync();
            var result = repository.All().ToList();
            Assert.Equal(3, result.Count);
        }
    }
}
