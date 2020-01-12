namespace CarsInfo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using static DataValidation;
    using static DataValidation.Category;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<Suspension> Suspensions { get; set; } = new HashSet<Suspension>();
    }
}
