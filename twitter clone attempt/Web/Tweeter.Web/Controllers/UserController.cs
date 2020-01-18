namespace Tweeter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Tweeter.Services.Models.Tweet;

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {
            var tweets = new List<TweetListingServiceModel>();
            return View("~/Views/UserInfo/Profile.cshtml", tweets);
        }
    }
}