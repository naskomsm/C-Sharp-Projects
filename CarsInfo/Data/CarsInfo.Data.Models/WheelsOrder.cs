namespace CarsInfo.Data.Models
{
    public class WheelsOrder
    {
        public int WheelsId { get; set; }

        public Wheels Wheels { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
