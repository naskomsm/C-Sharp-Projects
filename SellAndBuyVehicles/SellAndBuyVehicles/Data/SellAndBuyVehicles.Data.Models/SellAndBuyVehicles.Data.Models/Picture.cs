namespace SellAndBuyVehicles.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Picture;

    public class Picture
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string ImageTitle { get; set; }

        public ICollection<PostPicture> PostsPictures { get; set; } = new HashSet<PostPicture>();
    }
}
