namespace CarsInfo.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using CarsInfo.Services;
    using CarsInfo.Web.Models;
    using CarsInfo.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IBrakesService brakes;
        private readonly IWheelsService wheels;
        private readonly ISuspensionService suspensions;
        private readonly IEngineService engines;
        //private readonly ICarService cars;

        public HomeController(IBrakesService brakes, IWheelsService wheels, ISuspensionService suspensions, IEngineService engines)
        {
            this.brakes = brakes;
            this.wheels = wheels;
            this.suspensions = suspensions;
            this.engines = engines;
        }

        public IActionResult Index()
        {
            var firstTwoBrakes = this.brakes.AllInfo().Take(2); // what if count is 0 ?

            var model = new HomeViewModel()
            {
                Brakes = firstTwoBrakes,
                Suspension = suspensions.AllInfo().FirstOrDefault(),
                Wheels = wheels.AllInfo().FirstOrDefault()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
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
