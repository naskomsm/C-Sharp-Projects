namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            var postsService = serviceProvider.GetRequiredService<IPostsService>();

            var categoriesService = serviceProvider.GetRequiredService<ICategoriesService>();
            var vehicleCategoriesService = serviceProvider.GetRequiredService<IVehicleCategoriesService>();
            var colorsService = serviceProvider.GetRequiredService<IColorService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();
            var modelsService = serviceProvider.GetRequiredService<IModelsService>();
            var citiesService = serviceProvider.GetRequiredService<ICitiesService>();
            var imagesService = serviceProvider.GetRequiredService<IImagesService>();

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var categories = categoriesService.GetAll().ToArray();
            var cities = citiesService.GetAll().ToArray();
            var vehicleCategories = vehicleCategoriesService.GetAll().ToArray();
            var colors = colorsService.GetAll().ToArray();
            var makes = makesService.GetAll().ToArray();
            var models = modelsService.GetAll().ToArray();
            var images = imagesService.GetAll().Skip(4).ToArray();

            var user = await userManager.FindByNameAsync("naskokolev00@gmail.com");

            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                var category = categories[random.Next(1, categories.Length - 1)];
                var city = cities[random.Next(1, cities.Length - 1)];
                var make = makes[random.Next(1, makes.Length - 1)];
                var model = models[random.Next(1, models.Length - 1)];
                var vehicleCategory = vehicleCategories[random.Next(1, vehicleCategories.Length - 1)];
                var color = colors[random.Next(1, colors.Length - 1)];

                var postToAdd = new Post()
                {
                    Category = category,
                    CategoryId = category.Id,
                    City = city,
                    CityId = city.Id,
                    Make = make,
                    MakeId = make.Id,
                    Model = model,
                    ModelId = model.Id,
                    User = user,
                    UserId = user.Id,
                    VehicleCategory = vehicleCategory,
                    VehicleCategoryId = vehicleCategory.Id,
                    Color = color,
                    ColorId = color.Id,
                    Condition = (Condition)random.Next(1, 2),
                    Currency = (Currency)random.Next(1, 3),
                    Horsepower = random.Next(300, 900),
                    Description = "No description",
                    Mileage = random.Next(5000, 950000),
                    Email = "emailFromForm@abv.bg",
                    PhoneNumber = "0899115617",
                    Price = random.Next(1000, 100000),
                    TransmissionType = (TransmissionType)random.Next(1, 2),
                    Eurostandard = (Eurostandard)random.Next(1, 6),
                    EngineType = (EngineType)random.Next(1, 4),
                    ManufactureDate = DateTime.UtcNow.AddYears(random.Next(5, 15)),
                    Name = make.Name + " " + model.Name,
                };

                await postsService.AddAsync(postToAdd);
            }

            await dbContext.SaveChangesAsync();

            var allPosts = postsService.GetAll().ToList();

            for (int i = 0; i < allPosts.Count; i++)
            {
                var image = images[i];
                var post = allPosts[i];

                var postImage = new PostImage()
                {
                    Image = image,
                    ImageId = image.Id,
                    Post = post,
                    PostId = post.Id,
                };

                post.Images.Add(postImage);
            }
        }
    }
}
