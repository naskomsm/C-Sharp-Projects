namespace Tweeter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Tweeter.Services;
    using Tweeter.Services.Models.Tweet;
    using Tweeter.Services.Models.User;
    using Tweeter.Web.Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService users;
        private readonly ITweetService tweets;

        public HomeController(ILogger<HomeController> logger, IUserService users, ITweetService tweets)
        {
            _logger = logger;
            this.users = users;
            this.tweets = tweets;
        }

        public IActionResult Index()
        {
            var email = User.Identity.Name;
            var tweets = new List<TweetListingServiceModel>();

            if (email != null)
            {
                if (!this.users.UsersEmails().Any(x => x == email))
                {
                    var userModel = new UserAddServiceModel()
                    {
                        Email = email,
                        Joined = DateTime.Now
                    };

                    this.users.Add(userModel);
                }

                tweets = (List<TweetListingServiceModel>)this.tweets.GetUserTweetsByEmail(email);
                tweets.AddRange((List<TweetListingServiceModel>)this.tweets.GetUserFollowingTweets(email));
            }

            return View(tweets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Explore()
        {
            var tweets = new List<TweetListingServiceModel>();
            var email = User.Identity.Name;

            if (email != null)
            {
                tweets = (List<TweetListingServiceModel>)this.tweets.GetAll();
            }

            return View(tweets);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
