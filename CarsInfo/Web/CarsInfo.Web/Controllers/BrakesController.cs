namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using CarsInfo.Web.Models.Brakes;
    using Microsoft.AspNetCore.Mvc;

    public class BrakesController : Controller
    {
        private readonly IBrakesService brakes;

        public BrakesController(IBrakesService brakes)
        {
            this.brakes = brakes;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allBrakes = this.brakes.All(page);
            var totalBrakes = this.brakes.Total();

            var model = new AllBrakesViewModel()
            {
                Brakes = allBrakes,
                Total = totalBrakes,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var brakes = this.brakes.BrakesInfo(id);

            return View(brakes);
        }

    }
}