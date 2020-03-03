namespace Sabv.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sabv.Data.Models.PostsImages;

    public class PostsImagesConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.HasKey(k => new { k.ImageId, k.PostId });

            builder
                .HasOne(pi => pi.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pi => pi.Image)
                .WithMany(i => i.Posts)
                .HasForeignKey(i => i.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
