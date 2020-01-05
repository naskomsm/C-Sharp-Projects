namespace CarsInfo.Data.Models
{
    public class SuspensionOrder
    {
        public int SuspensionId { get; set; }

        public Suspension Suspension { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
