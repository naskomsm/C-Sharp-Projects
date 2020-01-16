using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tweeter.Services.Models.Tweet;
using Tweeter.Web.Models;

namespace Tweeter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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

            return View(tweets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Explore()
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

            return View(tweets);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
