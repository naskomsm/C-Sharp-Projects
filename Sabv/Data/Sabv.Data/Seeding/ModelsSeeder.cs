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

    public class ModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Models.Any())
            {
                return;
            }

            var modelsService = serviceProvider.GetRequiredService<IModelsService>();
            var makesService = serviceProvider.GetRequiredService<IMakesService>();

            try
            {
                using StreamReader r = new StreamReader(GlobalConstants.OriginalJsonPath);
                string json = r.ReadToEnd();
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                foreach (var car in cars)
                {
                    var make = makesService.GetMakeByName(car.Name);

                    foreach (var model in car.Models)
                    {
                        await modelsService.AddAsync(model, make);
                    }
                }
            }
            catch (Exception)
            {
                using StreamReader r = new StreamReader(GlobalConstants.TestJsonPath);
                string json = r.ReadToEnd();
                var cars = JsonConvert.DeserializeObject<List<Car>>(json);
                foreach (var car in cars)
                {
                    var make = makesService.GetMakeByName(car.Name);

                    foreach (var model in car.Models)
                    {
                        await modelsService.AddAsync(model, make);
                    }
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
