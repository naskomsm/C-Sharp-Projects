namespace Tweeter.Data.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime TimePosted { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }

        public int TweetId { get; set; }

        public Tweet Tweet { get; set; }
    }
}
