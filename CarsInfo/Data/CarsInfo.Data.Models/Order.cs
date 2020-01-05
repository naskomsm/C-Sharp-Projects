namespace CarsInfo.Data.Models
{
    using CarsInfo.Data.Models.Enums.Order;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public OrderStatus Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<CarOrder> Cars { get; set; } = new HashSet<CarOrder>();

        public ICollection<EngineOrder> Engines { get; set; } = new HashSet<EngineOrder>();

        public ICollection<BrakesOrder> Brakes { get; set; } = new HashSet<BrakesOrder>();

        public ICollection<WheelsOrder> Wheels { get; set; } = new HashSet<WheelsOrder>();

        public ICollection<SuspensionOrder> Suspensions { get; set; } = new HashSet<SuspensionOrder>();
    }
}
