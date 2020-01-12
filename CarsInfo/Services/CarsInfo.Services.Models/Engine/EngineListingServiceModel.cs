namespace CarsInfo.Services.Models.Engine
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Engine;

    using Image = Data.Models.Image;

    public class EngineListingServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [Range(150000, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, MaxCylindersCount)]
        public int CylindersCount { get; set; }

        [Required]
        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
