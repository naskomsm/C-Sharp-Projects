namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data;

    public class VehicleCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.VehicleCategories.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<IVehicleCategoriesService>();

            var categoriesNames = new List<string>()
            {
               "Van",
               "Jeep",
               "Convertible",
               "Combi",
               "Coupe",
               "Minivan",
               "Pickup",
               "Sedan",
               "Stretch limousine",
               "Hatchback",
            };

            foreach (var name in categoriesNames)
            {
                await service.AddAsync(name);
            }
        }
    }
}
