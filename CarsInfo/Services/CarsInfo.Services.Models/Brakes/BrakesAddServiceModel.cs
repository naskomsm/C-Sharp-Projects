namespace CarsInfo.Services.Models.Brakes
{
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.ComponentModel.DataAnnotations;

    public class BrakesAddServiceModel
    {
        [Required]
        public BrakesType Type { get; set; }

        [Required]
        public bool Used { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
