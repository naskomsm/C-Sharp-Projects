namespace CarsInfo.Web.Controllers
{
    using System.Diagnostics;
    using CarsInfo.Services;
    using CarsInfo.Web.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IBrakesService brakes;

        public HomeController(IBrakesService brakes)
        {
            this.brakes = brakes;
        }

        public IActionResult Index()
        {
            var allBrakes = this.brakes.AllInfo();
            return View(allBrakes);
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
