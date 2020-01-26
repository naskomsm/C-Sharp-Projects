namespace SellAndBuyVehicles.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.PostCategory;

    public class PostCategory
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
