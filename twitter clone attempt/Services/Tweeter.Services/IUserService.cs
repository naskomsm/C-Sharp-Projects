namespace Tweeter.Services
{
    using System.Collections.Generic;
    using Tweeter.Services.Models.Tweet;
    using Tweeter.Services.Models.User;

    public interface IUserService
    {
        bool Exists(int id);

        void Add(UserAddServiceModel model);

        bool Remove(int id);

        ICollection<string> UsersEmails();

        ICollection<TweetListingServiceModel> Tweets(string email);
    }
}
