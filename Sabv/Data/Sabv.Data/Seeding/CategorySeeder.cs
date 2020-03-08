namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categoriesService = serviceProvider.GetRequiredService<ICategoriesService>();
            var cloudinaryService = serviceProvider.GetRequiredService<ICloudinaryService>();

            var categories = new List<(string Name, string ImageUrl)>()
            {
                ("Cars and jeeps", "https://previews.123rf.com/images/igoun/igoun1810/igoun181000081/109842072-car-vector-icon-isolated-simple-front-car-logo-illustration-sign.jpg"),
                ("Buses", "https://previews.123rf.com/images/aayam4d/aayam4d1901/aayam4d190100220/126178120-bus-icon-bus-vector-art-illustration.jpg"),
                ("Trucks",  "https://getdrawings.com/vectors/delivery-truck-vector-free-download-9.png"),
                ("Motorcycles", "https://image.freepik.com/free-vector/motorcycle-vector-logo_20448-45.jpg"),
            };

            foreach (var (name, imageUrl) in categories)
            {
                var image = await cloudinaryService.UploadAsync(imageUrl);
                await categoriesService.AddAsync(name, image);
            }
        }
    }
}
