namespace Tweeter.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Tweet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime TimePosted { get; set; }

        public int Likes { get; set; }

        public int Shares { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public string Description { get; set; }
    }
}
