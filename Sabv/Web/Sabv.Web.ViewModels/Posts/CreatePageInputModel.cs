﻿namespace Sabv.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Sabv.Common;

    public class CreatePageInputModel
    {
        [Required]
        public string PostCategory { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public int Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Modification should not be empty!")]
        public string Modification { get; set; }

        [Required]
        public string EngineType { get; set; }

        [Required]
        [Range(GlobalConstants.Post.MinHorsepower, GlobalConstants.Post.MaxHorsepower, ErrorMessage = "Value should be between {0} and {1}")]
        public int Horsepower { get; set; }

        [Required]
        public int Eurostandard { get; set; }

        [Required]
        public string TransmissionType { get; set; }

        [Required]
        public string VehicleCategory { get; set; }

        [Required]
        [Range(GlobalConstants.Post.MinPrice, GlobalConstants.Post.MaxPrice, ErrorMessage = "Value should be between {0} and {1}")]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        [Range(GlobalConstants.Post.MinMileage, double.MaxValue, ErrorMessage = "Value should be between {0} and {1}")]
        public int Mileage { get; set; }

        public string Description { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
