namespace CarsInfo.Data.Models
{
    public class BrakesOrder
    {
        public int BrakesId { get; set; }

        public Brakes Brakes { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
