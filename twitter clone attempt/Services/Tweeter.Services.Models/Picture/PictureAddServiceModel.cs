using System.ComponentModel.DataAnnotations;

namespace Tweeter.Services.Models.Picture
{
    public class PictureAddServiceModel
    {
        public string ImageTitle { get; set; }

        [Required]
        public byte[] ImageData { get; set; }
    }
}
