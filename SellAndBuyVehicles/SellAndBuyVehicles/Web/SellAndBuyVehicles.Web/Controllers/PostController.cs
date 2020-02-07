namespace SellAndBuyVehicles.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SellAndBuyVehicles.Web.Models;

    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var jsonStringCategories = System.IO.File.ReadAllText("./Datasets/Categories.json");
            var jsonStringCities = System.IO.File.ReadAllText("./Datasets/Cities.json");
            var jsonStringMakes = System.IO.File.ReadAllText("./Datasets/Makes.json");
            var jsonStringYears = System.IO.File.ReadAllText("./Datasets/Years.json");
            var jsonStringColors = System.IO.File.ReadAllText("./Datasets/Colors.json");
            var jsonStringCarTypeCategories = System.IO.File.ReadAllText("./Datasets/CarTypeCategories.json");
            var jsonStringCarFeatures = System.IO.File.ReadAllText("./Datasets/CarFeatures.json");

            var parsedDataCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCategories);
            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataMakes = JsonConvert.DeserializeObject<string[]>(jsonStringMakes);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataCarTypeCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCarTypeCategories);
            var parsedDataCarFeatures = JsonConvert.DeserializeObject<CarFeatures[]>(jsonStringCarFeatures);

            var model = new SearchPageViewModel()
            {
                Categories = parsedDataCategories,
                Cities = parsedDataCities,
                Makes = parsedDataMakes,
                Years = parsedDataYears,
                Colors = parsedDataColors,
                Features = parsedDataCarFeatures[0],
                CarTypeCategory = parsedDataCarTypeCategories
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var jsonStringCategories = System.IO.File.ReadAllText("./Datasets/Categories.json");
            var jsonStringCities = System.IO.File.ReadAllText("./Datasets/Cities.json");
            var jsonStringMakes = System.IO.File.ReadAllText("./Datasets/Makes.json");
            var jsonStringYears = System.IO.File.ReadAllText("./Datasets/Years.json");
            var jsonStringColors = System.IO.File.ReadAllText("./Datasets/Colors.json");
            var jsonStringCarTypeCategories = System.IO.File.ReadAllText("./Datasets/CarTypeCategories.json");
            var jsonStringCarFeatures = System.IO.File.ReadAllText("./Datasets/CarFeatures.json");

            var parsedDataCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCategories);
            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataMakes = JsonConvert.DeserializeObject<string[]>(jsonStringMakes);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
            var parsedDataColors = JsonConvert.DeserializeObject<string[]>(jsonStringColors);
            var parsedDataCarTypeCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCarTypeCategories);
            var parsedDataCarFeatures = JsonConvert.DeserializeObject<CarFeatures[]>(jsonStringCarFeatures);

            var model = new SearchPageViewModel()
            {
                Categories = parsedDataCategories,
                Cities = parsedDataCities,
                Makes = parsedDataMakes,
                Years = parsedDataYears,
                Colors = parsedDataColors,
                Features = parsedDataCarFeatures[0],
                CarTypeCategory = parsedDataCarTypeCategories
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult CheckText()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPictures()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPictures(string arg)
        {

            return this.View();
        }
    }
}