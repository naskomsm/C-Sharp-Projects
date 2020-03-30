namespace Sabv.Data.Tests
{
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Sabv.Data.Models;
    using Sabv.Data.Repositories;
    using Sabv.Data.Seeding;
    using Sabv.Services.Data;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SeedingTests : BaseClass
    {
        [Fact]
        public async Task CategoySeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "CategoySeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            
            var categoriesRepository = new EfDeletableEntityRepository<Category>(dbContext);
            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ICategoriesService)))
                .Returns(new CategoriesService(categoriesRepository));

            var imagesService = new ImagesService(imagesRepository);
            Account cloudinaryCredentials = new Account(
             this.Configuration["Cloudinary:CloudName"],
             this.Configuration["Cloudinary:ApiKey"],
             this.Configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            serviceProvider
                .Setup(x => x.GetService(typeof(ICloudinaryService)))
                .Returns(new CloudinaryService(cloudinary, imagesService));

            var seeder = new CategorySeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);

            Assert.NotEmpty(dbContext.Categories);
        }

        [Fact]
        public async Task CitiesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "CitiesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var citiesRepository = new EfDeletableEntityRepository<City>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(ICitiesService)))
                .Returns(new CitiesService(citiesRepository));

            var seeder = new CitiesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Cities);
        }

        [Fact]
        public async Task ColorsSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "ColorSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var colorsRepository = new EfDeletableEntityRepository<Color>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IColorService)))
                .Returns(new ColorService(colorsRepository));

            var seeder = new ColorSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Colors);
        }

        [Fact]
        public async Task ImagesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "ImagesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);

            var imagesRepository = new EfDeletableEntityRepository<Image>(dbContext);

            Account cloudinaryCredentials = new Account(
             this.Configuration["Cloudinary:CloudName"],
             this.Configuration["Cloudinary:ApiKey"],
             this.Configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(cloudinaryCredentials);

            var imagesService = new ImagesService(imagesRepository);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IImagesService)))
                .Returns(imagesService);

            serviceProvider
                .Setup(x => x.GetService(typeof(ICloudinaryService)))
                .Returns(new CloudinaryService(cloudinary, imagesService));

            var seeder = new ImagesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);

            Assert.NotEmpty(dbContext.Images);
        }

        [Fact]
        public async Task MakesSeederShouldWork()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "MakesSeederShouldWork").Options;
            var dbContext = new ApplicationDbContext(options);
            var makesRepository = new EfDeletableEntityRepository<Make>(dbContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider
                .Setup(x => x.GetService(typeof(IMakesService)))
                .Returns(new MakesService(makesRepository));

            var seeder = new MakesSeeder();
            await seeder.SeedAsync(dbContext, serviceProvider.Object);
            Assert.NotEmpty(dbContext.Makes);
        }
    }
}
