namespace SellAndBuyVehicles.Data.Models
{
    public static class DataValidation
    {
        public static class PostCategory
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
        }

        public static class VehicleCategory
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
        }

        public static class Post
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;

            public const int MinPrice = 200;
            public const int MaxPrice = 5000000;

            public const int MaxDescriptionLength = 10000;

            public const int MinTownLength = 3;
            public const int MaxTownLength = 20;
        }

        public static class BaseClass
        {
            public const int MinHorsePower = 50;
            public const int MaxHorsePower = 2000;

            public const int MinMileage = 100;
            public const int MaxMileage = 1500000;

            public const int MinColorLength = 3;
            public const int MaxColorLength = 15;

            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
        }

        public static class Picture
        {
            public const int MaxTitleLength = 50;
        }
    }
}
