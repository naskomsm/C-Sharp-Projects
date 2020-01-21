namespace Tweeter.Services
{
    using System.Collections.Generic;

    public interface IFollowingService
    {
        void AddFollowing(int userId, int followerId);

        void RemoveFollowing(int userId, int followerId);

        int GetUserFollowingsCount(int followerId);

        int GetUserFollowersCount(int userId);

        List<int> GetAllUsersToFollow(int followerId);
    }
}
