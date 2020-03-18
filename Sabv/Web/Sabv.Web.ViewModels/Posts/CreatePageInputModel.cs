namespace Sabv.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Sabv.Common;

    public class CreatePageInputModel
    {
        [Required(ErrorMessage = "Post category should be selected!")]
        public string PostCategory { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Make should be selected!")]
        public int? Make { get; set; }

        [Required(ErrorMessage = "Model should be selected!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Modification should not be empty!")]
        [StringLength(100)]
        public string Modification { get; set; }

        [Required(ErrorMessage = "Engine type should be selected!")]
        public string EngineType { get; set; }

        [Required(ErrorMessage = "Horsepower should be set!")]
        [Range(GlobalConstants.Post.MinHorsepower, GlobalConstants.Post.MaxHorsepower, ErrorMessage = "Value should be between {0} and {1}")]
        public int? Horsepower { get; set; }

        [Required(ErrorMessage = "Eurostandard should be selected!")]
        public int? Eurostandard { get; set; }

        [Required(ErrorMessage = "Transmission type should be selected!")]
        public string TransmissionType { get; set; }

        [Required(ErrorMessage = "Vehicle category should be selected!")]
        public string VehicleCategory { get; set; }

        [Required(ErrorMessage = "Price should be set!")]
        [Range(GlobalConstants.Post.MinPrice, GlobalConstants.Post.MaxPrice, ErrorMessage = "Value should be between {0} and {1}")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Currency should be selected!")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Year should be selected!")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Color should be selected!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Town should be set!")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Mileage should be set!")]
        [Range(GlobalConstants.Post.MinMileage, double.MaxValue, ErrorMessage = "Value should be between {0} and {1}")]
        public int? Mileage { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Phone number should be set!")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email should be set!")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
