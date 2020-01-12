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
                .HasMany(e => e.Cars)
                .WithOne(c => c.Engine)
                .HasForeignKey(c => c.EngineId)
                .OnDelete(DeleteBehavior.Restrict);

            engine
                .HasOne(e => e.Image)
                .WithMany(i => i.Engines)
                .HasForeignKey(e => e.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
