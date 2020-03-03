namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Cities;
    using Sabv.Services.Data;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetRequiredService<ICitiesService>();

            await SeedRoleAsync(service);
        }

        private static async Task SeedRoleAsync(ICitiesService citiesService)
        {
            await citiesService.AddAsync(new City
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Стара Загора",
            });

            await citiesService.AddAsync(new City
            {
                CreatedOn = DateTime.UtcNow,
                Name = "София",
            });

            await citiesService.AddAsync(new City
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Бургас",
            });

            await citiesService.AddAsync(new City
            {
                CreatedOn = DateTime.UtcNow,
                Name = "Варна",
            });
        }
    }
}
