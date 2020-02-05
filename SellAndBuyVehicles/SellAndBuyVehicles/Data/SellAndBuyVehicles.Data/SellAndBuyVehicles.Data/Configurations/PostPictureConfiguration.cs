namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using SellAndBuyVehicles.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostPictureConfiguration : IEntityTypeConfiguration<PostPicture>
    {
        public void Configure(EntityTypeBuilder<PostPicture> postPicture)
        {
            postPicture
                .HasOne(pp => pp.Post)
                .WithMany(p => p.PostsPictures)
                .HasForeignKey(pp => pp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            postPicture
                .HasOne(pp => pp.Picture)
                .WithMany(p => p.PostsPictures)
                .HasForeignKey(pp => pp.PictureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
