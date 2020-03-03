namespace Sabv.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Models;
    using Sabv.Services.Data;

    public class ModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var modelsService = serviceProvider.GetRequiredService<IModelsService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();

            await SeedRoleAsync(modelsService, makesService);
        }

        private static async Task SeedRoleAsync(IModelsService modelsService, IMakesService makesService)
        {
            var bmwId = makesService.GetAll().FirstOrDefault(x => x.Name == "BMW").Id;
            var audiId = makesService.GetAll().FirstOrDefault(x => x.Name == "Audi").Id;
            var opelId = makesService.GetAll().FirstOrDefault(x => x.Name == "Opel").Id;

            await modelsService.AddAsync(new Model()
            {
                CreatedOn = DateTime.UtcNow,
                MakeId = bmwId,
                Name = "M5",
            });

            await modelsService.AddAsync(new Model()
            {
                CreatedOn = DateTime.UtcNow,
                MakeId = audiId,
                Name = "RS7",
            });

            await modelsService.AddAsync(new Model()
            {
                CreatedOn = DateTime.UtcNow,
                MakeId = opelId,
                Name = "Astra",
            });
        }
    }
}
