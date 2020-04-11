namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreatePageViewModel
    {
        [Required]
        public string Category { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Required]
        public string Make { get; set; }

        public List<SelectListItem> Makes { get; set; }

        [Required]
        public string VehicleCategory { get; set; }

        public List<SelectListItem> VehicleCategories { get; set; }

        [Required]
        public string Color { get; set; }

        public List<SelectListItem> Colors { get; set; }

        [Required]
        public string City { get; set; }

        public List<SelectListItem> Cities { get; set; }

        [Required]
        public string EngineType { get; set; }

        public List<SelectListItem> EngineTypes { get; set; }

        [Required]
        public string Eurostandard { get; set; }

        public List<SelectListItem> Eurostandards { get; set; }

        [Required]
        public string TransmissionType { get; set; }

        public List<SelectListItem> TransmissionTypes { get; set; }

        [Required]
        public string Currency { get; set; }

        public List<SelectListItem> Currencies { get; set; }

        [Required]
        public int Year { get; set; }

        public List<SelectListItem> Years { get; set; }

        [Required(ErrorMessage = "You must upload at least 1 image.")]
        public string File { get; set; }

        [Required(ErrorMessage = "Modification is required.")]
        public string Modification { get; set; }

        [Required]
        [Range(20, 3000, ErrorMessage = "Enter horsepower between 20 and 3000.")]
        public int Horsepower { get; set; }

        [Required]
        [Range(200, 10000000, ErrorMessage = "Enter price between 200 and 10000000.")]
        public double Price { get; set; }

        [Required]
        [Range(5, 1000000, ErrorMessage = "Enter mileage between 5 and 1000000.")]
        public int Mileage { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
