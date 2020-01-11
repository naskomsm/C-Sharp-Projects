namespace CarsInfo.Web.Controllers
{
    using CarsInfo.Services;
    using CarsInfo.Web.Models.Suspension;
    using Microsoft.AspNetCore.Mvc;

    public class SuspensionController : Controller
    {
        private readonly ISuspensionService suspensions;

        public SuspensionController(ISuspensionService suspensions)
        {
            this.suspensions = suspensions;
        }

        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var allSuspensions = this.suspensions.All(page);
            var totalSuspensions = this.suspensions.Total();

            var model = new AllSuspensionViewModel()
            {
                Suspensions = allSuspensions,
                Total = totalSuspensions,
                CurrentPage = page
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var suspension = this.suspensions.SuspensionInfo(id);

            return View(suspension);
        }
    }
}