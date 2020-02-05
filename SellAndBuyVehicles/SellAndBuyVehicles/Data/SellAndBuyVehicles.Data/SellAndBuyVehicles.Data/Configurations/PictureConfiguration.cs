namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using SellAndBuyVehicles.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> picture)
        {
            picture
                .HasMany(p => p.PostsPictures)
                .WithOne(po => po.Picture)
                .HasForeignKey(po => po.PictureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
