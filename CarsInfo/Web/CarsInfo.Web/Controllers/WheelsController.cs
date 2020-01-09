namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using Microsoft.AspNetCore.Mvc;

    public class WheelsController : Controller
    {
        private readonly IWheelsService wheels;

        public WheelsController(IWheelsService wheels)
        {
            this.wheels = wheels;
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
