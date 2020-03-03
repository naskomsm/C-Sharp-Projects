namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Categories;
    using Sabv.Services.Data;

    public class VehicleCategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetRequiredService<IVehicleCategoryService>();

            await SeedRoleAsync(service);
        }

        private static async Task SeedRoleAsync(IVehicleCategoryService vehicleCategoryService)
        {
            await vehicleCategoryService.AddAsync(new VehicleCategory()
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Седан",
            });

            await vehicleCategoryService.AddAsync(new VehicleCategory()
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Кабрио",
            });

            await vehicleCategoryService.AddAsync(new VehicleCategory()
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Комби",
            });

            await vehicleCategoryService.AddAsync(new VehicleCategory()
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Купе",
            });
        }
    }
}
