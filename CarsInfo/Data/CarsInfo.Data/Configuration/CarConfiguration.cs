namespace CarsInfo.Data.Configuration
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            car
                .HasOne(c => c.Engine)
                .WithMany(e => e.Cars)
                .HasForeignKey(c => c.EngineId)
                .OnDelete(DeleteBehavior.Restrict);

            car
               .HasOne(c => c.Brakes)
               .WithMany(b => b.Cars)
               .HasForeignKey(c => c.BrakesId)
               .OnDelete(DeleteBehavior.Restrict);

            car
                .HasOne(c => c.Image)
                .WithMany(i => i.Cars)
                .HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            car
                .HasOne(c => c.Wheels)
                .WithMany(w => w.Cars)
                .HasForeignKey(c => c.WheelsId)
                .OnDelete(DeleteBehavior.Restrict);

            car
                .HasOne(c => c.Suspension)
                .WithMany(s => s.Cars)
                .HasForeignKey(c => c.SuspensionId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
