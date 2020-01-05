namespace CarsInfo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation.Image;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleLength)]
        public string ImageTitle { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<Brakes> Brakes { get; set; } = new HashSet<Brakes>();

        public ICollection<Wheels> Wheels { get; set; } = new HashSet<Wheels>();

        public ICollection<Suspension> Suspensions { get; set; } = new HashSet<Suspension>();
    }
}
