namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SellAndBuyVehicles.Data.Models;
    using SellAndBuyVehicles.Data.Models.BaseModels;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post
                .HasOne(p => p.Vehicle)
                .WithOne(v => v.Post)
                .HasForeignKey<BaseVehicle>(v => v.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            post
                .HasOne(p => p.PostCategory)
                .WithMany(pc => pc.Posts)
                .HasForeignKey(p => p.PostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            post
                .HasOne(p => p.SabvUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.SabvUserId)
                .OnDelete(DeleteBehavior.Restrict);

            post
                .HasMany(p => p.PostsPictures)
                .WithOne(pp => pp.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
