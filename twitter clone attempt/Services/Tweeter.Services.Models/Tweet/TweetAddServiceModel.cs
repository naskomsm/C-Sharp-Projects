namespace Tweeter.Services.Models.Tweet
{
    using System;
    using Tweeter.Data.Models;

    public class TweetAddServiceModel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime TimePosted { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }

        public string Description { get; set; }
    }
}
