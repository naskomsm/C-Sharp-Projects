namespace Sabv.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Sabv.Data.Models.Extras;
    using Sabv.Services.Data;

    public class ExtrasSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetRequiredService<IExtrasService>();

            await SeedRoleAsync(service);
        }

        private static async Task SeedRoleAsync(IExtrasService extrasService)
        {
            await extrasService.AddComfortAsync(new Comfort()
            {
                ACC = true,
                LightSensor = true,
                EPS = true,
                SeatHeat = true,
                USB = true,
                Navigation = false,
                Steptronic = false,
                BordComputer = true,
                Keyless = false,
                CreatedOn = DateTime.UtcNow,
                Airmatic = false,
                ASS = true,
                Bluetooth = true,
                DVD = false,
                ElectricMirrors = true,
                ElectricWindows = true,
            });

            await extrasService.AddExteriorAsync(new Exterior()
            {
                CreatedOn = DateTime.UtcNow,
                FourDoors = true,
                LED = true,
                Rims = false,
                Metalic = false,
            });

            await extrasService.AddOtherAsync(new Other()
            {
                AllWheelDrive = true,
                Service = true,
                LongBase = false,
                CreatedOn = DateTime.UtcNow,
            });

            await extrasService.AddSafetyAsync(new Safety()
            {
                ASR = true,
                CreatedOn = DateTime.UtcNow,
                ABS = true,
                DBS = true,
                Airbags = true,
                AFL = true,
                ASC = false,
                EBD = true,
                HDC = true,
                ESP = true,
                Distronic = false,
                DSA = false,
                BAS = false,
                TPMS = true,
                Isofix = true,
                PDC = true,
            });
        }
    }
}
