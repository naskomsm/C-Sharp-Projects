﻿namespace CarsInfo.Services.Models.Engine
{
    using CarsInfo.Data.Models.Enums.Engine;
    using System.ComponentModel.DataAnnotations;

    using static Data.Models.DataValidation;
    using static Data.Models.DataValidation.Engine;

    using Image = Data.Models.Image;

    public class EngineAddServiceModel
    {
        [Required]
        public Position Position { get; set; }

        [Required]
        [Range(0, MaxCylindersDiameter)]
        public double CylindersDiameter { get; set; }

        [Required]
        [Range(0, MaxCylindersStroke)]
        public double CylindersStroke { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        [Required]
        [Range(150000, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, MaxCylindersCount)]
        public int CylindersCount { get; set; }

        [Required]
        public CylindersPosition CylindersPosition { get; set; }

        [Required]
        [Range(0, MaxVolume)]
        public int Volume { get; set; }

        [Required]
        [Range(0, MaximumMaxPowerIn)]
        public int MaxPowerIn { get; set; }

        [Required]
        [Range(0, MaxTorque)]
        public int Torque { get; set; }

        [Required]
        public FuelInjection FuelInjection { get; set; }

        [Required]
        public Turbine Turbine { get; set; }

        [Required]
        [Range(0, MaxCompressionRatio)]
        public double CompressionRatio { get; set; }

        [Required]
        public int NumberOfValvesPerCylinder { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}
