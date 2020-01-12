namespace CarsInfo.Services.Models.Suspension
{
    using CarsInfo.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Suspension;

    public class SuspensionInfoServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [Range(10, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(CarMadeForLength)]
        public string CarBrandMadeFor { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
