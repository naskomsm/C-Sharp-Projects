namespace CarsInfo.Services.Models.User
{
    using System.ComponentModel.DataAnnotations;

    public class UserAddServiceModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
