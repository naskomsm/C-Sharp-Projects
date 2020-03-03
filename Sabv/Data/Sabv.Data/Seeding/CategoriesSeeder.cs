namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Categories;
    using Sabv.Services.Data;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetRequiredService<ICategoryService>();

            await SeedRoleAsync(service);
        }

        private static async Task SeedRoleAsync(ICategoryService categoryService)
        {
            await categoryService.AddAsync(new Category
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Автомобили и джипове",
            });

            await categoryService.AddAsync(new Category
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Автобуси",
            });

            await categoryService.AddAsync(new Category
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Мотори",
            });

            await categoryService.AddAsync(new Category
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Лодки",
            });
        }
    }
}
