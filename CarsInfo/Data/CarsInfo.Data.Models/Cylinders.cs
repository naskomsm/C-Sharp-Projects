namespace CarsInfo.Data.Models
{
    using Enums.Cylinders;

    public class Cylinders
    {
        public int Id { get; set; }

        public Position Positon { get; set; }

        public int Count { get; set; }

        public double Diameter { get; set; }

        public double Stroke { get; set; }

        public int EngineId { get; set; }

        public Engine Engine { get; set; }
    }
}
