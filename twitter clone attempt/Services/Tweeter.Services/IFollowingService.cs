namespace Tweeter.Services
{
    public interface IFollowingService
    {
        void AddFollowing(int userId, int followerId);

        void RemoveFollowing(int userId, int followerId);
    }
}
