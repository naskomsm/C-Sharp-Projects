namespace SellAndBuyVehicles.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckText()
        {
            return View();
        }
    }
}