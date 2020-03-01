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
            var jsonStringCities = await File.ReadAllTextAsync("wwwroot/datasets/Cities.json");
            var jsonStringYears = await File.ReadAllTextAsync("wwwroot/datasets/Years.json");

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
            var jsonStringCities = await File.ReadAllTextAsync("wwwroot/datasets/Cities.json");
            var jsonStringYears = await File.ReadAllTextAsync("wwwroot/datasets/Years.json");
            var jsonStringColors = await File.ReadAllTextAsync("wwwroot/datasets/Colors.json");
            var jsonStringCarFeatures = await File.ReadAllTextAsync("wwwroot/datasets/CarFeatures.json");
            var jsonStringMonths = await File.ReadAllTextAsync("wwwroot/datasets/Months.json");

            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataMonths = JsonConvert.DeserializeObject<string[]>(jsonStringMonths);
            var parsedDataCarFeatures = JsonConvert.DeserializeObject<VehicleFeatures[]>(jsonStringCarFeatures);

            var model = new DataSetsViewModel()
            {
                Cities = parsedDataCities,
                Years = parsedDataYears,
                Colors = parsedDataColors,
                Features = parsedDataCarFeatures[0],
                Months = parsedDataMonths,
            };

            return model;
        }
    }
}
