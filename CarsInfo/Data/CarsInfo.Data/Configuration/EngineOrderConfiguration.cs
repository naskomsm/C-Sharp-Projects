namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EngineOrderConfiguration : IEntityTypeConfiguration<EngineOrder>
    {
        public void Configure(EntityTypeBuilder<EngineOrder> engineOrder)
        {
            engineOrder.HasKey(key => new { key.EngineId, key.OrderId });

            engineOrder
                .HasOne(eo => eo.Engine)
                .WithMany(e => e.Orders)
                .HasForeignKey(eo => eo.EngineId)
                .OnDelete(DeleteBehavior.Restrict);

            engineOrder
                .HasOne(eo => eo.Order)
                .WithMany(o => o.Engines)
                .HasForeignKey(eo => eo.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
