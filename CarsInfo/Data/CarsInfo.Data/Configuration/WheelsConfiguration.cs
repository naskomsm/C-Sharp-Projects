namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WheelsConfiguration : IEntityTypeConfiguration<Wheels>
    {
        public void Configure(EntityTypeBuilder<Wheels> wheels)
        {
            wheels
                .HasOne(w => w.Image)
                .WithMany(i => i.Wheels)
                .HasForeignKey(w => w.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            wheels
                .HasMany(w => w.Cars)
                .WithOne(c => c.Wheels)
                .HasForeignKey(c => c.WheelsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
