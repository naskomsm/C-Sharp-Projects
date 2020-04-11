namespace Sabv.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
           
            StreamReader reader;
            try
            {
                reader = new StreamReader(GlobalConstants.Seeder.WebJsonPath);
            }
            catch (Exception)
            {
                reader = new StreamReader(GlobalConstants.Seeder.TestsJsonPath);
            }

            using (reader)
            {
                var json = reader.ReadToEnd();
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                foreach (var car in cars)
                {
                    await service.AddAsync(car.Name);
                }
            }
        }

        public class Car
        {
            public string Name { get; set; }

            public ICollection<string> Models { get; set; } = new HashSet<string>();
        }
    }
}
