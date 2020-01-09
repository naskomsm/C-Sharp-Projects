namespace CarsInfo.Services.Models.Brakes
{
    using CarsInfo.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Brakes;

    public class BrakesListingServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Range(10, PriceMaxRange)]
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
