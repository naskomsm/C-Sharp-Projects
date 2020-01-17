namespace Tweeter.Services.Implementations
{
    using System;
    using Tweeter.Data;
    using System.Linq;
    using Tweeter.Data.Models;
    using Tweeter.Services.Models.Tweet;

    public class TweetService : ITweetService
    {
        private readonly TweeterDbContext data;

        public TweetService(TweeterDbContext data)
        {
            this.data = data;
        }

        public void Add(TweetAddServiceModel model)
        {
            // Validation

            var tweet = new Tweet()
            {
                UserId = model.UserId,
                User = model.User,
                Description = model.Description,
                Likes = model.Likes,
                Shares = model.Shares,
                TimePosted = model.TimePosted
            };

            this.data.Tweets.Add(tweet);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Tweets.Any(x => x.Id == id);
        }

        public bool Remove(int id)
        {
            if(!this.data.Tweets.Any(x => x.Id == id))
            {
                return false;
            }

            var tweet = this.data.Tweets.FirstOrDefault(x => x.Id == id);
            this.data.Tweets.Remove(tweet);
            this.data.SaveChanges();

            return true;
        }
    }
}
