﻿namespace CarsInfo.Services.Models.Wheels
{
    using CarsInfo.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Data.Models.DataValidation.Wheels;

    public class WheelsListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ColorLength)]
        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
