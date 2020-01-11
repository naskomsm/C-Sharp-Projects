namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using CarsInfo.Web.Models.Wheels;
    using Microsoft.AspNetCore.Mvc;

    public class WheelsController : Controller
    {
        private readonly IWheelsService wheels;

        public WheelsController(IWheelsService wheels)
        {
            this.wheels = wheels;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allWheels = this.wheels.All(page);
            var totalWheels = this.wheels.Total();

            var model = new AllWheelsViewModel()
            {
                Wheels = allWheels,
                Total = totalWheels,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var brakes = this.wheels.WheelsInfo(id);

            return View(brakes);
        }
    }
}
