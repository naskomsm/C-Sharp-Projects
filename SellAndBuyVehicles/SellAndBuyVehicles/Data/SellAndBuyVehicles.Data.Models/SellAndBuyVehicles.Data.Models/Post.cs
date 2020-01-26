namespace SellAndBuyVehicles.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.Post;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Invalid phone number!")]
        public string PhoneNumber { get; set; }

        public BaseVehicle Vehicle { get; set; }

        [Required]
        [MinLength(MinTownLength)]
        [MaxLength(MaxTownLength)]
        public string Town { get; set; }

        public bool GPS { get; set; }

        public bool ABS { get; set; }

        public bool TractionControl { get; set; }

        public bool Parktronic { get; set; }

        public bool StartStopFunction { get; set; }

        public bool AirSuspension { get; set; }

        public bool ClimateControl { get; set; }

        public bool ThreeDoors { get; set; }

        public bool FiveDoors { get; set; }

        public bool AllWheelDrive { get; set; }

        public bool Barter { get; set; }

        public bool Tuned { get; set; }

        public bool RainSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool USBAudio { get; set; }

        public bool Airbags { get; set; }

        public int PostCategoryId { get; set; }

        public PostCategory PostCategory { get; set; }

        public ICollection<PostPicture> PostsPictures { get; set; } = new HashSet<PostPicture>();
    }
}
