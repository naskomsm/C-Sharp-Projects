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
        private readonly IFollowingService followings;

        public HomeController(ILogger<HomeController> logger, IUserService users, ITweetService tweets, IFollowingService followingService)
        {
            _logger = logger;
            this.users = users;
            this.tweets = tweets;
            this.followings = followingService;
        }

        public IActionResult Index()
        {
            var email = User.Identity.Name;

            var indexViewModel = new IndexViewModel();

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

                var tweets = (List<TweetListingServiceModel>)this.tweets.GetUserTweetsByEmail(email);
                tweets.AddRange((List<TweetListingServiceModel>)this.tweets.GetUserFollowingTweets(email));
                
                var currentUser = this.users.GetUserByEmail(email);
                var followingsCount = this.followings.GetUserFollowingsCount(currentUser.Id);
                var followersCount = this.followings.GetUserFollowersCount(currentUser.Id);
                var usersToFollowIds = this.followings.GetAllUsersToFollow(currentUser.Id);
                var usersToFollow = this.users.GetAllUsers().Where(x => usersToFollowIds.Contains(x.Id)).ToList();

                indexViewModel.Tweets = tweets;
                indexViewModel.CurrentUser = currentUser;
                indexViewModel.FollowersCount = followersCount;
                indexViewModel.FollowingCount = followingsCount;
                indexViewModel.UsersToFollow = usersToFollow;
            }

            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Explore()
        {
            var tweets = new List<TweetListingServiceModel>();
            tweets = (List<TweetListingServiceModel>)this.tweets.GetAll();
            
            return View(tweets);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
