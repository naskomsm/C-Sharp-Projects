namespace Tweeter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TweetController : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }
    }
}