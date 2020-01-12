namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> image)
        {
            image
                .HasMany(i => i.Cars)
                .WithOne(c => c.Image)
                .HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            image
                .HasMany(i => i.Wheels)
                .WithOne(w => w.Image)
                .HasForeignKey(w => w.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            image
                .HasMany(i => i.Brakes)
                .WithOne(b => b.Image)
                .HasForeignKey(b => b.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            image
                .HasMany(i => i.Suspensions)
                .WithOne(s => s.Image)
                .HasForeignKey(s => s.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            image
                .HasMany(i => i.Engines)
                .WithOne(e => e.Image)
                .HasForeignKey(e => e.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
