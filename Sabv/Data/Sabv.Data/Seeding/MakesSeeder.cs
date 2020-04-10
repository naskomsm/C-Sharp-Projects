namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Sabv.Common;
    using Sabv.Services.Data;

    public class MakesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Makes.Any())
            {
                return;
            }

            var service = serviceProvider.GetRequiredService<IMakesService>();

            var cars = JsonConvert.DeserializeObject<List<Car>>(GlobalConstants.Seeder.Json);
            foreach (var car in cars)
            {
                await service.AddAsync(car.Name);
            }
        }

        public class Car
        {
            public string Name { get; set; }

            public ICollection<string> Models { get; set; } = new HashSet<string>();
        }
    }
}
