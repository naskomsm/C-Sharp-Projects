namespace Tweeter.Data.Models
{
    public class Following
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FollowerId { get; set; }
    }
}
