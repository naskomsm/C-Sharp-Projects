namespace CarsInfo.Services.Models.Brakes
{
    using System.ComponentModel.DataAnnotations;
    using CarsInfo.Data.Models;

    public class BrakesInfoServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Used { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
