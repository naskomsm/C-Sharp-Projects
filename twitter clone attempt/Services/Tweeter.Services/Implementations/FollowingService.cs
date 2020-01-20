namespace Tweeter.Services.Implementations
{
    using System.Linq;
    using Tweeter.Data;
    using Tweeter.Data.Models;

    public class FollowingService : IFollowingService
    {
        private readonly TweeterDbContext data;

        public FollowingService(TweeterDbContext data)
        {
            this.data = data;
        }

        public void AddFollowing(int userId, int followerId)
        {
            var following = new Following()
            {
                UserId = userId,
                FollowerId = followerId
            };

            this.data.Followings.Add(following);
            this.data.SaveChanges();
        }

        public void RemoveFollowing(int userId, int followerId)
        {
            var following = this.data.Followings.FirstOrDefault(x => x.UserId == userId && x.FollowerId == followerId);
            this.data.Followings.Remove(following);
            this.data.SaveChanges();
        }
    }
}
