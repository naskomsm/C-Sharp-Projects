namespace Tweeter.ConsoleApp
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using Tweeter.Data;
    using Tweeter.Services.Implementations;
    using Tweeter.Services.Models.Tweet;

    public class Program
    {
        public static void Main()
        {
            using var data = new TweeterDbContext();
            data.Database.Migrate();

            var userService = new UserService(data);
            var tweetService = new TweetService(data);
            var followingService = new FollowingService(data);


            var users = data.Users.ToList();
            //SeedTweets(data, tweetService);

            //followingService.AddFollowing(2, 1);
        }

        private static void SeedTweets(TweeterDbContext data, TweetService tweetService)
        {
            var firstTweetModel = new TweetAddServiceModel()
            {
                UserId = 1,
                User = data.Users.FirstOrDefault(x => x.Id == 1),
                Content = "Some content bro",
                Likes = 45,
                Shares = 10,
                TimePosted = DateTime.Now
            };

            var secondTweetModel = new TweetAddServiceModel()
            {
                UserId = 1,
                User = data.Users.FirstOrDefault(x => x.Id == 1),
                Content = "Again SOME NEW AKSDNASKDN content bro",
                Likes = 25,
                Shares = 40,
                TimePosted = DateTime.Now
            };

            var thirdTweetModel = new TweetAddServiceModel()
            {
                UserId = 2,
                User = data.Users.FirstOrDefault(x => x.Id == 2),
                Content = "AAAAAAAAAAAAAAAAAAAAAA",
                Likes = 15,
                Shares = 10,
                TimePosted = DateTime.Now
            };

            tweetService.Add(firstTweetModel);
            tweetService.Add(secondTweetModel);
            tweetService.Add(thirdTweetModel);
        }
    }
}
