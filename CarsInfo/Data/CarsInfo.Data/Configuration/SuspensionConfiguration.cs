namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SuspensionConfiguration : IEntityTypeConfiguration<Suspension>
    {
        public void Configure(EntityTypeBuilder<Suspension> suspension)
        {
            suspension
                 .HasOne(s => s.Category)
                 .WithMany(cat => cat.Suspensions)
                 .HasForeignKey(s => s.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            suspension
                .HasOne(s => s.Image)
                .WithMany(i => i.Suspensions)
                .HasForeignKey(s => s.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            suspension
                .HasMany(s => s.Cars)
                .WithOne(c => c.Suspension)
                .HasForeignKey(c => c.SuspensionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
