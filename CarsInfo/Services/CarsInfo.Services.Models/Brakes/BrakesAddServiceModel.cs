namespace CarsInfo.Services.Models.Brakes
{
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation;
    using static Data.Models.DataValidation.Brakes;
    using Image = Data.Models.Image;

    public class BrakesAddServiceModel
    {
        [Required]
        public BrakesType Type { get; set; }

        [Required]
        public bool Used { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Range(10, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
