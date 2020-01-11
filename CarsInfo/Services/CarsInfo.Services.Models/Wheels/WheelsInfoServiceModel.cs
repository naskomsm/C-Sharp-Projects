﻿namespace CarsInfo.Services.Models.Wheels
{
    using System.ComponentModel.DataAnnotations;
    using CarsInfo.Data.Models;

    using static Data.Models.DataValidation.Wheels;
    
    public class WheelsInfoServiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        public string Used { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, MaxWeight)]
        public double Weight { get; set; }

        [Required]
        [MaxLength(ColorLength)]
        public string Color { get; set; }

        [Required]
        public string FrontAxleSize { get; set; }

        [Required]
        public string RearAxleSize { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
