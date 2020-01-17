namespace Tweeter.Web.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Tweeter.Services.Models.Tweet;

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {
            // TODO MAKE SERVICE AND FIX EVERYTHING
            var tweets = new List<TweetListingServiceModel>()
            {
                new TweetListingServiceModel()
                {
                    Description = "fist tweet",
                    Likes = 16,
                    Shares = 2,
                    TimePosted = DateTime.Now,
                    UserId = 1
                },
                new TweetListingServiceModel()
                {
                    Description = "second tweet",
                    Likes = 22,
                    Shares = 21,
                    TimePosted = DateTime.Now,
                    UserId = 1
                },
            };

            return View("~/Views/UserInfo/Profile.cshtml", tweets);
        }
    }
}