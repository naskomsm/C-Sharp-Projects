namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Engine;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    using static DataValidation.Engine;

    public class Engine
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionLength)]
        public string Description { get; set; }

        public Position Position { get; set; }

        [Required]
        [Range(150000,PriceMaxRange)]
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
        public CylindersPosition CylindersPosition { get; set; }

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
        public FuelInjection FuelInjection { get; set; }

        [Required]
        public Turbine Turbine { get; set; }

        [Required]
        [Range(0, MaxCompressionRatio)]
        public double CompressionRatio { get; set; }

        [Required]
        public int NumberOfValvesPerCylinder { get; set; }

        [Required]
        public int ImageId { get; set; }

        public Image Image { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public ICollection<EngineOrder> Orders { get; set; } = new HashSet<EngineOrder>();
    }
}
