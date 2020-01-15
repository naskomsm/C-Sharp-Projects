namespace Tweeter.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime Joined { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }

        public ICollection<User> Following = new HashSet<User>();

        public ICollection<User> Followers = new HashSet<User>();

        public ICollection<Tweet> Tweets { get; set; } = new HashSet<Tweet>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Tweet> Booksmarks = new HashSet<Tweet>();
    }
}
