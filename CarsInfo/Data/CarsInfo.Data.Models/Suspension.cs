namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Suspension;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using static DataValidation.Suspension;

    public class Suspension
    {
        public int Id { get; set; }

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

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<SuspensionOrder> Orders { get; set; } = new HashSet<SuspensionOrder>();
    }
}
