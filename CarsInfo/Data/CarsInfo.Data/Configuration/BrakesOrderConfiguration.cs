namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrakesOrderConfiguration : IEntityTypeConfiguration<BrakesOrder>
    {
        public void Configure(EntityTypeBuilder<BrakesOrder> brakesOrder)
        {
            brakesOrder.HasKey(key => new { key.BrakesId, key.OrderId });

            brakesOrder
                .HasOne(bo => bo.Brakes)
                .WithMany(b => b.Orders)
                .HasForeignKey(bo => bo.BrakesId)
                .OnDelete(DeleteBehavior.Restrict);

            brakesOrder
               .HasOne(bo => bo.Order)
               .WithMany(o => o.Brakes)
               .HasForeignKey(bo => bo.OrderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
