namespace Tweeter.Web.Models
{
    using System.Collections.Generic;
    using Tweeter.Services.Models.Tweet;
    using Tweeter.Services.Models.User;

    public class IndexViewModel
    {
        public IEnumerable<TweetListingServiceModel> Tweets { get; set; }

        public UserInfoServiceModel CurrentUser { get; set; }

        public int FollowingCount { get; set; }

        public int FollowersCount { get; set; }

        public IEnumerable<UserInfoServiceModel> UsersToFollow { get; set; }
    }
}
