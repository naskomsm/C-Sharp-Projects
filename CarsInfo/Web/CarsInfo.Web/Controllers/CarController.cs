namespace CarsInfo.Web.Controllers
{
    using System.Linq;
    using CarsInfo.Services;
    using CarsInfo.Web.Models.Car;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
    {
        private readonly ICarService cars;

        public CarController(ICarService cars)
        {
            this.cars = cars;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allCars = this.cars.All(page);
            var totalCars = this.cars.Total();

            var model = new AllCarsViewModel()
            {
                Cars = allCars,
                Total = totalCars,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var car = this.cars.CarInfo(id);

            return View(car);
        }
    }
}