namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Sabv.Common;
    using Sabv.Web.Infrastructure.CustomAttributes;

    public class CreatePageInputModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Post category should be selected!")]
        public string PostCategory { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Make should be selected!")]
        public int? Make { get; set; }

        [Required(ErrorMessage = "Model should be selected!")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Modification should not be empty!")]
        [StringLength(100)]
        public string Modification { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Engine type should be selected!")]
        public string EngineType { get; set; }

        [Required(ErrorMessage = "Horsepower should be set!")]
        [Range(GlobalConstants.Post.MinHorsepower, GlobalConstants.Post.MaxHorsepower, ErrorMessage = "Value should be between {0} and {1}")]
        public int? Horsepower { get; set; }

        [Required(ErrorMessage = "Eurostandard should be selected!")]
        public int? Eurostandard { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Transmission type should be selected!")]
        public string TransmissionType { get; set; }

        [Required(ErrorMessage = "Vehicle category should be selected!")]
        public string VehicleCategory { get; set; }

        [Required(ErrorMessage = "Price should be set!")]
        [Range(GlobalConstants.Post.MinPrice, GlobalConstants.Post.MaxPrice, ErrorMessage = "Value should be between {0} and {1}")]
        public decimal? Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Currency should be selected!")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Year should be selected!")]
        public int? Year { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Color should be selected!")]
        public string Color { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Town should be set!")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Mileage should be set!")]
        [Range(GlobalConstants.Post.MinMileage, double.MaxValue, ErrorMessage = "Value should be between {0} and {1}")]
        public int? Mileage { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Phone number should be set!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email should be set!")]
        [EmailAddress]
        public string Email { get; set; }

        [NotNullOrEmptyCollectionAttribute(ErrorMessage = "Uploaded images must be between 1 and 10")]
        public ICollection<IFormFile> Files { get; set; }
    }
}
