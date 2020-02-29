namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.MainInfos;

    public class MainInfoSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var additionalInfoService = serviceProvider.GetRequiredService<IMainInfoService>();
            await SeedMainInfoAsync(additionalInfoService);
        }

        private static async Task SeedMainInfoAsync(IMainInfoService mainInfoService)
        {
            var firstModel = new AddMainInfoModel()
            {
                Color = "Червено",
                EuroStandard = 1,
                EngineType = 0,
                Horsepower = 625,
                Mileage = 156444,
                TransmissionType = 0,
                VehicleCreatedOn = new DateTime(2000, 5, 6),
            };

            var secondModel = new AddMainInfoModel()
            {
                Color = "Черно",
                EuroStandard = 1,
                EngineType = 1,
                Horsepower = 860,
                Mileage = 250000,
                TransmissionType = 1,
                VehicleCreatedOn = new DateTime(2004, 5, 6),
            };

            await mainInfoService.AddAsync(firstModel);
            await mainInfoService.AddAsync(secondModel);
        }
    }
}
