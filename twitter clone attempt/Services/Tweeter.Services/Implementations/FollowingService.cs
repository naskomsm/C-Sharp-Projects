namespace Tweeter.Services.Implementations
{
    using System.Collections.Generic;
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

        public List<int> GetAllUsersToFollow(int followerId)
        {
            var currentUserFollowingIds = this.data.Followings
                .Where(x => x.FollowerId == followerId)
                .Select(x => x.UserId)
                .ToList();

            var usersToFollowIds = this.data.Followings
                .Where(x => x.UserId != followerId)
                .Where(x => x.FollowerId != followerId)
                .Select(x => x.UserId)
                .ToList();

            foreach (var user in this.data.Users)
            {
                if (usersToFollowIds.Contains(user.Id) || currentUserFollowingIds.Contains(user.Id) || user.Id == followerId)
                {
                    continue;
                }

                usersToFollowIds.Add(user.Id);
            }

            return usersToFollowIds;
        }

        public int GetUserFollowersCount(int userId)
        {
            return this.data.Followings.Count(x => x.UserId == userId);
        }

        public int GetUserFollowingsCount(int followerId)
        {
            return this.data.Followings.Count(x => x.FollowerId == followerId);
        }

        public void RemoveFollowing(int userId, int followerId)
        {
            var following = this.data.Followings.FirstOrDefault(x => x.UserId == userId && x.FollowerId == followerId);
            this.data.Followings.Remove(following);
            this.data.SaveChanges();
        }
    }
}
