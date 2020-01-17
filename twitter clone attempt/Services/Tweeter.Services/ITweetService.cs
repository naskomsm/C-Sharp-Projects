namespace Tweeter.Services
{
    using Tweeter.Services.Models.Tweet;

    public interface ITweetService
    {
        bool Exists(int id);

        void Add(TweetAddServiceModel model);

        bool Remove(int id);
    }
}
