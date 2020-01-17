namespace Tweeter.ConsoleApp
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using Tweeter.Data;
    using Tweeter.Services.Implementations;
    using Tweeter.Services.Models.Tweet;
    using Tweeter.Services.Models.User;

    public class Program
    {
        public static void Main()
        {
            using var data = new TweeterDbContext();
            data.Database.Migrate();

            var userService = new UserService(data);
            var tweetService = new TweetService(data);

        }
    }
}
