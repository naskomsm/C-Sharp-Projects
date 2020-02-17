﻿namespace Sabv.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Sabv.Web.ViewModels;
    using Sabv.Web.ViewModels.Posts;

    public class DataSetsService : IDataSetsService
    {
        public async Task<DataSetsViewModel> GetAllDataSets()
        {
            var jsonStringCategories = await File.ReadAllTextAsync("./Datasets/Categories.json");
            var jsonStringCities = await File.ReadAllTextAsync("./Datasets/Cities.json");
            var jsonStringMakes = await File.ReadAllTextAsync("./Datasets/Makes.json");
            var jsonStringYears = await File.ReadAllTextAsync("./Datasets/Years.json");
            var jsonStringColors = await File.ReadAllTextAsync("./Datasets/Colors.json");
            var jsonStringCarTypeCategories = await File.ReadAllTextAsync("./Datasets/CarTypeCategories.json");
            var jsonStringCarFeatures = await File.ReadAllTextAsync("./Datasets/CarFeatures.json");

            var parsedDataCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCategories);
            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataMakes = JsonConvert.DeserializeObject<string[]>(jsonStringMakes);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataCarTypeCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCarTypeCategories);
            var parsedDataCarFeatures = JsonConvert.DeserializeObject<VehicleFeatures[]>(jsonStringCarFeatures);

            var model = new DataSetsViewModel()
            {
                Categories = parsedDataCategories,
                Cities = parsedDataCities,
                Makes = parsedDataMakes,
                Years = parsedDataYears,
                Colors = parsedDataColors,
                Features = parsedDataCarFeatures[0],
                CarTypeCategories = parsedDataCarTypeCategories,
            };

            return model;
        }
    }
}
