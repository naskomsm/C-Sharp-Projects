namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Makes;
    using Sabv.Services.Data;

    public class MakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetRequiredService<IMakesService>();

            await SeedRoleAsync(service);
        }

        private static async Task SeedRoleAsync(IMakesService makesService)
        {
            await makesService.AddAsync(new Make()
            {
                Name = "BMW",
                CreatedOn = DateTime.UtcNow,
            });

            await makesService.AddAsync(new Make()
            {
                Name = "Audi",
                CreatedOn = DateTime.UtcNow,
            });

            await makesService.AddAsync(new Make()
            {
                Name = "Mercedes",
                CreatedOn = DateTime.UtcNow,
            });

            await makesService.AddAsync(new Make()
            {
                Name = "Opel",
                CreatedOn = DateTime.UtcNow,
            });
        }
    }
}
