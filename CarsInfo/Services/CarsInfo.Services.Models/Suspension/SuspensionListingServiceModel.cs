namespace CarsInfo.Services.Models.Suspension
{
    using CarsInfo.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Suspension;

    public class SuspensionListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(10, PriceMaxRange)]
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
