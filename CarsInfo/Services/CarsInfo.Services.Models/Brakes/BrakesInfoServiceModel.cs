namespace CarsInfo.Services.Models.Brakes
{
    using Image = Data.Models.Image;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation;
    using static Data.Models.DataValidation.Brakes;

    public class BrakesInfoServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Range(10, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        public string Used { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
