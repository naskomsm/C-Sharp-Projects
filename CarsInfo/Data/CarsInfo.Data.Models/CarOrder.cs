namespace CarsInfo.Data.Models
{
    public class CarOrder
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
