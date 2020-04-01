namespace Sabv.Data.Models
{
    public class UserLikes
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
