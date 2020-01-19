namespace Tweeter.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class DataValidation
    {
        public static class Tweet
        {
            public const int ContentMaxLength = 10000;
        }

        public static class Comment 
        {
            public const int ContentMaxLength = 6000;
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
