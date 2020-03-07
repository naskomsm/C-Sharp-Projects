namespace Sabv.Services.Data
{
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Sabv.Common;
    using Sabv.Data.Models;

    public class JsonService : IJsonService
    {
        public async Task WriteInJsonMakesAsync(Model[] models)
        {
            var settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            string json = JsonConvert.SerializeObject(models, settings);
            string content = await System.IO.File.ReadAllTextAsync(GlobalConstants.MakesAndModelsJsonPath);
            if (!content.Contains(json))
            {
                await System.IO.File.WriteAllTextAsync(GlobalConstants.MakesAndModelsJsonPath, json);
            }
        }
    }
}
