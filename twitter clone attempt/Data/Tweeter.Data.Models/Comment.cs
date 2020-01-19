namespace Tweeter.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Comment;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Shares { get; set; }

        [Required]
        public int TweetId { get; set; }

        [Required]
        public Tweet Tweet { get; set; }
    }
}
