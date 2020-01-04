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
                .HasForeignKey(c => c.CategoryId);

            car
                .HasOne(c => c.Engine)
                .WithMany(e => e.Cars)
                .HasForeignKey(c => c.EngineId);

            car
               .HasOne(c => c.Brakes)
               .WithMany(b => b.Cars)
               .HasForeignKey(c => c.BrakesId);

            car
                .HasOne(c => c.Image)
                .WithMany(i => i.Cars)
                .HasForeignKey(c => c.ImageId);
        }
    }
}
