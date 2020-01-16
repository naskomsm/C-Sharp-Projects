namespace Tweeter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View("~/Views/UserInfo/Profile.cshtml");
        }
    }
}