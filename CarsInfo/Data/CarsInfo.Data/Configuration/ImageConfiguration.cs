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
                .HasForeignKey(c => c.ImageId);
        }
    }
}
