namespace CarsInfo.Services.Models.Engine
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Models.DataValidation;
    using static Data.Models.DataValidation.Engine;

    using Image = Data.Models.Image;

    public class EngineInfoServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        public string Position { get; set; }

        [Required]
        [Range(150000, PriceMaxRange)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, MaxCylindersDiameter)]
        public double CylindersDiameter { get; set; }

        [Required]
        [Range(0, MaxCylindersStroke)]
        public double CylindersStroke { get; set; }

        [Required]
        [Range(3, MaxCylindersCount)]
        public int CylindersCount { get; set; }

        [Required]
        public string CylindersPosition { get; set; }

        [Required]
        [Range(0, MaxVolume)]
        public int Volume { get; set; }

        [Required]
        [Range(0, MaximumMaxPowerIn)]
        public int MaxPowerIn { get; set; }

        [Required]
        [Range(100, MaxTorque)]
        public int Torque { get; set; }

        [Required]
        public string FuelInjection { get; set; }

        [Required]
        public string Turbine { get; set; }

        [Required]
        [Range(0, MaxCompressionRatio)]
        public double CompressionRatio { get; set; }

        [Required]
        public int NumberOfValvesPerCylinder { get; set; }

        [Required]
        public int ImageId { get; set; }

        public Image Image { get; set; }

        [Required]
        public string FuelType { get; set; }
    }
}
