namespace CarsInfo.Services.Models.Category
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation;
    using static Data.Models.DataValidation.Category;

    public class CategoryAddServiceModel
    {
        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionLength)]
        public string Description { get; set; }
    }
}
