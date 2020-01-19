namespace Tweeter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Tweet;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Shares { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
