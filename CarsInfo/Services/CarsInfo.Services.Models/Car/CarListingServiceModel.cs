namespace CarsInfo.Services.Models.Car
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Car;
    using Data.Models;
    using Image = Data.Models.Image;

    public class CarListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(BrandLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(GenerationLength)]
        public string Generation { get; set; }

        [Required]
        [Range(20000, MaxPrice)]
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
