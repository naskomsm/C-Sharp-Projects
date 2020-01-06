namespace CarsInfo.Services.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.User;
    
    public class UserAddServiceModel
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
    }
}
