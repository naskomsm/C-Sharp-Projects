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

        [HttpGet]
        public IActionResult AddPictures()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPictures(string arg)
        {

            return this.View();
        }
    }
}