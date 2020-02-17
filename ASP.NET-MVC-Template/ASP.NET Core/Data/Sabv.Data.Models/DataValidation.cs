namespace Sabv.Data.Models
{
    public class DataValidation
    {
        public static class Common
        {
            // Validate this in constructor -> public const int MaxNameLength = 3;
            public const int MaxLength = 50;
        }

        public static class Post
        {
            public const int MinPrice = 200;
            public const int MaxPrice = 5000000;
            public const int MaxDescriptionLength = 10000;
            public const int MinHorsePower = 30;
            public const int MaxHorsePower = 2000;
            public const int MinMileage = 5;
            public const int MaxMileage = 1500000;
            public const int MaxColorLength = 15;
        }
    }
}
