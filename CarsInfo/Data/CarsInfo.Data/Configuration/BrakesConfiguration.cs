namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BrakesConfiguration : IEntityTypeConfiguration<Brakes>
    {
        public void Configure(EntityTypeBuilder<Brakes> brakes)
        {
            brakes
                .HasMany(b => b.Cars)
                .WithOne(c => c.Brakes)
                .HasForeignKey(c => c.BrakesId)
                .OnDelete(DeleteBehavior.Restrict);

            brakes
                .HasOne(b => b.Image)
                .WithMany(i => i.Brakes)
                .HasForeignKey(b => b.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
