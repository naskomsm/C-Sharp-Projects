﻿namespace Tweeter.Services.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Tweeter.Data.Models;

    public class UserInfoServiceModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Joined { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }

        public ICollection<Tweet> Tweets { get; set; } = new HashSet<Tweet>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Tweet> Booksmarks = new HashSet<Tweet>();
    }
}