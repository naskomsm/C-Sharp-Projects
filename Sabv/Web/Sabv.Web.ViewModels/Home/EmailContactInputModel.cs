namespace Sabv.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class EmailContactInputModel
    {
        [Required]
        [MinLength(2)]
        public string FromName { get; set; }

        [Required]
        [EmailAddress]
        public string From { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
