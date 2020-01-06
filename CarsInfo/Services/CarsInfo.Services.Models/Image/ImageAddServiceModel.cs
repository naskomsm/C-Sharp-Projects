namespace CarsInfo.Services.Models.Image
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Image;

    public class ImageAddServiceModel
    {
        [Required]
        [MaxLength(TitleLength)]
        public string ImageTitle { get; set; }

        [Required]
        public byte[] ImageData { get; set; }
    }
}
