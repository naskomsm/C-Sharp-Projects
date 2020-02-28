namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.AdditionalInfos;

    public class AdditionalInfoSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var additionalInfoService = serviceProvider.GetRequiredService<IAdditionalInfoService>();
            await SeedAdditionalInfoAsync(additionalInfoService);
        }

        private static async Task SeedAdditionalInfoAsync(IAdditionalInfoService additionalInfoService)
        {
            var firstModel = new AddAdditionalInfoModel()
            {
                ABS = true,
                Barter = true,
                Parktronic = true,
                GPS = true,
                USBAudio = true,
                ClimateControl = true,
                FiveDoors = true,
                Airbags = true,
                Town = "Стara Загора",
            };

            var secondModel = new AddAdditionalInfoModel()
            {
                USBAudio = true,
                TractionControl = true,
                Airbags = true,
                Town = "София",
            };

            await additionalInfoService.AddAsync(firstModel);
            await additionalInfoService.AddAsync(secondModel);
        }
    }
}
