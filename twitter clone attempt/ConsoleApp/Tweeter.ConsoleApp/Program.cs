namespace Tweeter.ConsoleApp
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Net;
    using Tweeter.Data;
    using Tweeter.Services.Implementations;
    using Tweeter.Services.Models.Picture;
    using Tweeter.Services.Models.Tweet;

    public class Program
    {
        public static void Main()
        {
            using var data = new TweeterDbContext();
            data.Database.Migrate();

            //var userService = new UserService(data);
            //var tweetService = new TweetService(data);
            //var followingService = new FollowingService(data);
            //var pictureService = new PictureService(data);

            //var atanasUser = data.Users.FirstOrDefault(x => x.Id == 2);
            //var danielUser = data.Users.FirstOrDefault(x => x.Id == 4);
            //var vanesaUser = data.Users.FirstOrDefault(x => x.Id == 3);

            //atanasUser.Picture = data.Pictures.FirstOrDefault(x => x.Id == 1);
            //atanasUser.PictureId = 1;

            //danielUser.Picture = data.Pictures.FirstOrDefault(x => x.Id == 2);
            //danielUser.PictureId = 2;

            //vanesaUser.Picture = data.Pictures.FirstOrDefault(x => x.Id == 3);
            //vanesaUser.PictureId = 3;

            //data.SaveChanges();

            // SeedPictures(data, pictureService)
            //SeedTweets(data, tweetService);
            //followingService.AddFollowing(2, 1);
        }

        private static void SeedTweets(TweeterDbContext data, TweetService tweetService)
        {
            var firstTweetModel = new TweetAddServiceModel()
            {
                UserId = 1,
                User = data.Users.FirstOrDefault(x => x.Id == 1),
                Content = "Some content bro",
                Likes = 45,
                Shares = 10,
                TimePosted = DateTime.Now
            };

            var secondTweetModel = new TweetAddServiceModel()
            {
                UserId = 1,
                User = data.Users.FirstOrDefault(x => x.Id == 1),
                Content = "Again SOME NEW AKSDNASKDN content bro",
                Likes = 25,
                Shares = 40,
                TimePosted = DateTime.Now
            };

            var thirdTweetModel = new TweetAddServiceModel()
            {
                UserId = 2,
                User = data.Users.FirstOrDefault(x => x.Id == 2),
                Content = "AAAAAAAAAAAAAAAAAAAAAA",
                Likes = 15,
                Shares = 10,
                TimePosted = DateTime.Now
            };

            tweetService.Add(firstTweetModel);
            tweetService.Add(secondTweetModel);
            tweetService.Add(thirdTweetModel);
        }

        private static void SeedPictures(TweeterDbContext data, PictureService pictureService)
        {
            WebClient wc = new WebClient();
            var atanasBytes = wc.DownloadData("https://scontent.fsof10-1.fna.fbcdn.net/v/t31.0-8/s960x960/26024058_1683907335007850_306910126634697292_o.jpg?_nc_cat=102&_nc_ohc=RBVBgciJaUoAX-9oJjx&_nc_ht=scontent.fsof10-1.fna&_nc_tp=1002&oh=a9a4d299d285458c1efe5eed98dfa141&oe=5E95DB45");
            var danielBytes = wc.DownloadData("https://scontent.fsof10-1.fna.fbcdn.net/v/t1.0-9/p960x960/67678450_2382833248702350_1320545900551995392_o.jpg?_nc_cat=111&_nc_ohc=RKBgntGwqmQAX-ayw0a&_nc_ht=scontent.fsof10-1.fna&_nc_tp=1002&oh=27f02faf9da24dfff6d29dc31ec98112&oe=5ECF59E5");
            var vanesaBytes = wc.DownloadData("https://scontent.fsof10-1.fna.fbcdn.net/v/t1.0-9/52384575_1985658598156127_5348430204278669312_n.jpg?_nc_cat=104&_nc_ohc=TpJexoMTJm4AX9rDQCV&_nc_ht=scontent.fsof10-1.fna&oh=8c3ccdd282f27c7bc89f2086de5b9bc7&oe=5ED48483");

            var atanasPictureModel = new PictureAddServiceModel()
            {
                ImageTitle = "atanas",
                ImageData = atanasBytes
            };

            // id - 2
            var danielPictureModel = new PictureAddServiceModel()
            {
                ImageTitle = "daniel",
                ImageData = danielBytes
            };

            // id - 3
            var vanesaPictureModel = new PictureAddServiceModel()
            {
                ImageTitle = "vanesa",
                ImageData = vanesaBytes
            };

            pictureService.Add(atanasPictureModel);
            pictureService.Add(danielPictureModel);
            pictureService.Add(vanesaPictureModel);

        }
    }
}
