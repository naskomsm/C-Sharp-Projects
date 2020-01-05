namespace CarsInfo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class DataValidation
    {
        public static class Car 
        {
            public const int BrandLength = 20;
            public const int ModelLength = 20;
            public const int GenerationLength = 20;
            public const int ColorLength = 25;
            public const int MinimumYear = 1900;
            public const int MaximumYear = 2500;
            public const int MaximumLength = 10000;
            public const int MaximumWidth = 5000;
            public const int MaximumHeight = 8000;
            public const int MaximumWeight = 5000;
            public const int MaximumMaxWeight = 10000;
        }

        public static class Category
        {
            public const int NameLength = 20;
            public const int DescriptionLength = 2000;
        }

        public static class Engine
        {
            public const int MaxCylindersDiameter = 150;
            public const int MaxCylindersStroke = 150;
            public const int MinCylindersCount = 3;
            public const int MaxCylindersCount = 16;
            public const int MaxVolume = 10000;
            public const int MaximumMaxPowerIn = 10000;
            public const int MaxTorque = 2000;
            public const int MaxCompressionRatio = 30;
        }

        public static class Image
        {
            public const int TitleLength = 20;
        }

        public static class Suspension
        {
            public const int CarMadeForLength = 20;
        }

        public static class User
        {
            public const int EmailMaxLength = 100;
        }

        public static class Wheels
        {
            public const int NameLength = 20;
            public const int MaxWeight = 30;
            public const int ColorLength = 25;
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
