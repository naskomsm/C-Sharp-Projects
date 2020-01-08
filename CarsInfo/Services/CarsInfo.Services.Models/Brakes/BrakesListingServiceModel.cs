namespace CarsInfo.Services.Models.Brakes
{
    using CarsInfo.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class BrakesListingServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
