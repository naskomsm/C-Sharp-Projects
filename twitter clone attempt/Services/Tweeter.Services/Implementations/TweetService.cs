namespace Tweeter.Services.Implementations
{
    using Tweeter.Data;
    using System.Linq;
    using Tweeter.Data.Models;
    using Tweeter.Services.Models.Tweet;
    using System.Collections.Generic;
    using System;

    public class TweetService : ITweetService
    {
        private readonly TweeterDbContext data;

        public TweetService(TweeterDbContext data)
        {
            this.data = data;
        }

        public void Add(TweetAddServiceModel model)
        {
            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var tweet = new Tweet()
            {
                UserId = model.UserId,
                User = model.User,
                Content = model.Content,
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

        public ICollection<TweetListingServiceModel> GetAll()
        {
            return this.data.Tweets.Select(t => new TweetListingServiceModel
            {
                User = t.User,
                Content = t.Content,
                Comments = t.Comments,
                Likes = t.Likes,
                Shares = t.Shares,
                TimePosted = t.TimePosted,
                UserId = t.UserId
            }).ToList();
        }

        public ICollection<TweetListingServiceModel> GetUserFollowingTweets(string email)
        {
            var userId = this.data.Users.Where(x => x.Email == email).Select(x => x.Id).FirstOrDefault();
            var followingIds = this.data.Followings.Where(x => x.UserId == userId).Select(x => x.FollowerId).ToList();

            var followingTweets = new List<TweetListingServiceModel>();

            foreach (var id in followingIds.Distinct())
            {
                var followerTweets = this.data.Tweets
                    .Where(x => x.UserId == id)
                    .Select(x => new TweetListingServiceModel 
                    {
                        Comments = x.Comments,
                        Content = x.Content,
                        Likes = x.Likes,
                        Shares = x.Shares,
                        TimePosted = x.TimePosted,
                        User = x.User,
                        UserId = x.UserId
                    })
                    .ToList();

                foreach (var tweet in followerTweets)
                {
                    followingTweets.Add(tweet);
                }
            }

            return followingTweets;
        }

        public ICollection<TweetListingServiceModel> GetUserTweetsByEmail(string email)
        {
            return this.data.Tweets
                .Where(x => x.User.Email == email)
                .Select(t => new TweetListingServiceModel
                {
                    User = t.User,
                    Content = t.Content,
                    Comments = t.Comments,
                    Likes = t.Likes,
                    Shares = t.Shares,
                    TimePosted = t.TimePosted,
                    UserId = t.UserId
                }).ToList();
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
