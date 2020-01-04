namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Car;

    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Generation { get; set; }

        public string Color { get; set; }

        public int YearStart { get; set; }

        public int? YearEnd { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        // In MM
        public int Length { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        // Combined
        public double FuelConsumption { get; set; }

        public double Weight { get; set; }

        public double MaxWeight { get; set; }

        // EURO
        public EmissionStandard EmissionStandard { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int EngineId { get; set; }
        
        public Engine Engine { get; set; }

        public int BrakesId { get; set; }

        public Brakes Brakes { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }
    }
}
