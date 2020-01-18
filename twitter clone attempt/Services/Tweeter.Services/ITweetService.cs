namespace Tweeter.Services
{
    using System.Collections.Generic;
    using Tweeter.Services.Models.Tweet;

    public interface ITweetService
    {
        bool Exists(int id);

        void Add(TweetAddServiceModel model);

        bool Remove(int id);

        ICollection<TweetListingServiceModel> GetAll();
    }
}
