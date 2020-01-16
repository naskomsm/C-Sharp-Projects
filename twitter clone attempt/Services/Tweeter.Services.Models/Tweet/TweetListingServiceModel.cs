namespace Tweeter.Services.Models.Tweet
{
    using System;
    using System.Collections.Generic;
    using Tweeter.Data.Models;

    public class TweetListingServiceModel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime TimePosted { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public string Description { get; set; }
    }
}
