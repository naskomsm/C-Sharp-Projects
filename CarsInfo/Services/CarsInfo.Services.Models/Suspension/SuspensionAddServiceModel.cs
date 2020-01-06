namespace CarsInfo.Services.Models.Suspension
{
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Suspension;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Suspension;

    public class SuspensionAddServiceModel
    {
        [Required]
        public SuspensionType Type { get; set; }

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
