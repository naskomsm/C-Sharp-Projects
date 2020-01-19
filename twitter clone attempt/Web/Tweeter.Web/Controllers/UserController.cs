namespace Tweeter.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Tweeter.Services;
    using Tweeter.Services.Models.Tweet;

    public class UserController : Controller
    {
        private readonly ITweetService tweets;

        public UserController(ITweetService tweets)
        {
            this.tweets = tweets;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var tweets = new List<TweetListingServiceModel>();
            var email = User.Identity.Name;

            if (email != null)
            {
                tweets = (List<TweetListingServiceModel>)this.tweets.GetUserTweetsByEmail(email);
            }

            return View("~/Views/UserInfo/Profile.cshtml", tweets);
        }
    }
}