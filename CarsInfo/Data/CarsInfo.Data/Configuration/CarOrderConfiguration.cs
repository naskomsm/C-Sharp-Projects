namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarOrderConfiguration : IEntityTypeConfiguration<CarOrder>
    {
        public void Configure(EntityTypeBuilder<CarOrder> carOrder)
        {
            carOrder.HasKey(key => new { key.CarId, key.OrderId });

            carOrder
                .HasOne(co => co.Car)
                .WithMany(c => c.Orders)
                .HasForeignKey(co => co.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            carOrder
                .HasOne(co => co.Order)
                .WithMany(o => o.Cars)
                .HasForeignKey(co => co.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
