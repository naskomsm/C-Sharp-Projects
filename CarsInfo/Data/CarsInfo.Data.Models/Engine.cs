namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Engine;
    using System.Collections.Generic;

    public class Engine
    {
        public int Id { get; set; }

        public Position Position { get; set; }

        public int Volume { get; set; }

        public int MaxPowerIn { get; set; }

        public int Torque { get; set; }

        public FuelInjection FuelInjection { get; set; }

        public Turbine Turbine { get; set; }

        public Cylinders Cylinders { get; set; }

        public double CompressionRatio { get; set; }

        public int NumberOfValvesPerCylinder { get; set; }

        public FuelType FuelType { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
