namespace CarsInfo.Services.Implementations
{
    using CarsInfo.Data;
    using CarsInfo.Data.Models.Enums.Order;

    public class OrderService
    {
        private readonly CarsInfoDbContext data;

        public OrderService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void CompleteOrder(int orderId)
        {
            var order = this.data.Orders.Find(orderId);
            order.Status = OrderStatus.Pending;
            this.data.SaveChanges();
        }
    }
}
