namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;
    using Sabv.Services.Data.Contracts;

    public class VehicleCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var vehicleCategoriesService = serviceProvider.GetRequiredService<IVehicleTypeCategoriesService>();
            await SeedVehicleCategoriesAsync(vehicleCategoriesService);
        }

        private static async Task SeedVehicleCategoriesAsync(IVehicleTypeCategoriesService vehicleTypeCategoriesService)
        {
            await vehicleTypeCategoriesService.AddAsync("Седан");
            await vehicleTypeCategoriesService.AddAsync("Комби");
            await vehicleTypeCategoriesService.AddAsync("Джип");
            await vehicleTypeCategoriesService.AddAsync("Кабрио");
        }
    }
}
