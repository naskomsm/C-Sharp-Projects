namespace CarsInfo.Data.Models
{
    public class EngineOrder
    {
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
