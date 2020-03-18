﻿namespace Sabv.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Sabv";
        public const string SystemEmail = "naskokolev00@gmail.com";
        public const string BaseCloudinaryLink = "https://res.cloudinary.com/det4b1n4l/image/upload/";
        public const string MakesAndModelsJsonPath = "wwwroot/datasets/MakesAndItsModels.json";

        public static class Post
        {
            public const int MinHorsepower = 5;
            public const int MaxHorsepower = 3000;
            public const int MinPrice = 200;
            public const int MaxPrice = 10000000;
            public const int MinMileage = 5;
        }

        public static class User
        {
            public const string AdminRole = "Admin";
            public const string ModeratorRole = "Moderator";
            public const string UserRole = "User";
            public const string DefaultPassword = "123456";
            public const int DefaultImageIndex = 3;
        }
    }
}
