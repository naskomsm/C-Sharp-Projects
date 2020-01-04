namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> engine)
        {
            engine
                .HasOne(e => e.Cylinders)
                .WithOne(c => c.Engine)
                .HasForeignKey<Cylinders>(c => c.EngineId);
        }
    }
}
