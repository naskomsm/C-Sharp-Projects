namespace CarsInfo.Services.Models.Brakes
{
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Brakes;

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
        public string Description { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
