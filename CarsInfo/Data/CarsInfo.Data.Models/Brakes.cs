namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Brakes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Brakes;

    public class Brakes
    {
        public int Id { get; set; }

        [Required]
        public BrakesType Type { get; set; }
        
        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Range(35, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        public bool Used { get; set; }

        [Required]
        public string Description { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<BrakesOrder> Orders { get; set; } = new HashSet<BrakesOrder>();
    }
}
