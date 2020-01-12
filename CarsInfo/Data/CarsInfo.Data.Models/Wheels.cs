namespace CarsInfo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    using static DataValidation.Wheels;

    public class Wheels
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        public bool Used { get; set; }

        [Required]
        [Range(200, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(10, MaxWeight)]
        public double Weight { get; set; }

        [Required]
        [MaxLength(ColorLength)]
        public string Color { get; set; }

        [Required]
        public string FrontAxleSize { get; set; }

        [Required]
        public string RearAxleSize { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<WheelsOrder> Orders { get; set; } = new HashSet<WheelsOrder>();
    }
}
