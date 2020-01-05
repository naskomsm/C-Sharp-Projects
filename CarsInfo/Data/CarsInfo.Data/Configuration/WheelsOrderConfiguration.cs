namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WheelsOrderConfiguration : IEntityTypeConfiguration<WheelsOrder>
    {
        public void Configure(EntityTypeBuilder<WheelsOrder> wheelsOrder)
        {
            wheelsOrder.HasKey(key => new { key.OrderId, key.WheelsId });

            wheelsOrder
                .HasOne(wo => wo.Wheels)
                .WithMany(w => w.Orders)
                .HasForeignKey(wo => wo.WheelsId)
                .OnDelete(DeleteBehavior.Restrict);

            wheelsOrder
               .HasOne(wo => wo.Order)
               .WithMany(o => o.Wheels)
               .HasForeignKey(wo => wo.OrderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
