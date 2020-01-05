namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SuspensionOrderConfiguration : IEntityTypeConfiguration<SuspensionOrder>
    {
        public void Configure(EntityTypeBuilder<SuspensionOrder> suspensionOrder)
        {
            suspensionOrder.HasKey(key => new { key.OrderId, key.SuspensionId });

            suspensionOrder
                .HasOne(so => so.Suspension)
                .WithMany(s => s.Orders)
                .HasForeignKey(so => so.SuspensionId)
                .OnDelete(DeleteBehavior.Restrict);

            suspensionOrder
                .HasOne(so => so.Order)
                .WithMany(o => o.Suspensions)
                .HasForeignKey(so => so.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
