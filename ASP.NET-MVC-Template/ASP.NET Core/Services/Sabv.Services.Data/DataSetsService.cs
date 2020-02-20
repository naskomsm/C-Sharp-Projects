namespace Sabv.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Datasets.Models;

    public class DataSetsService : IDataSetsService
    {
        public async Task<DataSetsViewModel> GetDataForHomePageAsync()
        {
            var jsonStringCities = await File.ReadAllTextAsync("./Datasets/Cities.json");
            var jsonStringYears = await File.ReadAllTextAsync("./Datasets/Years.json");

            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);

            var model = new DataSetsViewModel()
            {
                Cities = parsedDataCities,
                Years = parsedDataYears,
            };

            return model;
        }

        public async Task<DataSetsViewModel> GetDataForSearchAndCreatePageAsync()
        {
            var jsonStringCities = await File.ReadAllTextAsync("./Datasets/Cities.json");
            var jsonStringYears = await File.ReadAllTextAsync("./Datasets/Years.json");
            var jsonStringColors = await File.ReadAllTextAsync("./Datasets/Colors.json");
            var jsonStringCarFeatures = await File.ReadAllTextAsync("./Datasets/CarFeatures.json");

            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataCarFeatures = JsonConvert.DeserializeObject<VehicleFeatures[]>(jsonStringCarFeatures);

            var model = new DataSetsViewModel()
            {
                Cities = parsedDataCities,
                Years = parsedDataYears,
                Colors = parsedDataColors,
                Features = parsedDataCarFeatures[0],
            };

            return model;
        }
    }
}
