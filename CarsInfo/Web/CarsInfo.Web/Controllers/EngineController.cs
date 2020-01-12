namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using CarsInfo.Web.Models.Engine;
    using Microsoft.AspNetCore.Mvc;

    public class EngineController : Controller
    {
        private readonly IEngineService engines;

        public EngineController(IEngineService engine)
        {
            this.engines = engine;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allEngines = this.engines.All(page);
            var totalEngines = this.engines.Total();

            var model = new AllEngineViewModel()
            {
                Engines = allEngines,
                Total = totalEngines,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var engines = this.engines.EngineInfo(id);

            return View(engines);
        }
    }
}