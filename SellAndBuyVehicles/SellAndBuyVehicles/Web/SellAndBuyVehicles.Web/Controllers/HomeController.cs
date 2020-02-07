namespace SellAndBuyVehicles.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SellAndBuyVehicles.Web.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var jsonStringCategories = System.IO.File.ReadAllText("./Datasets/Categories.json");
            var jsonStringCities = System.IO.File.ReadAllText("./Datasets/Cities.json");
            var jsonStringMakes = System.IO.File.ReadAllText("./Datasets/Makes.json");
            var jsonStringYears = System.IO.File.ReadAllText("./Datasets/Years.json");
          

            var parsedDataCategories = JsonConvert.DeserializeObject<string[]>(jsonStringCategories);
            var parsedDataCities = JsonConvert.DeserializeObject<string[]>(jsonStringCities);
            var parsedDataMakes = JsonConvert.DeserializeObject<string[]>(jsonStringMakes);
            var parsedDataYears = JsonConvert.DeserializeObject<string[]>(jsonStringYears);
           

            var model = new HomePageViewModel()
            {
                Categories = parsedDataCategories,
                Cities = parsedDataCities,
                Makes = parsedDataMakes,
                Years = parsedDataYears
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
