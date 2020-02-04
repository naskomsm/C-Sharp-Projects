namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SellAndBuyVehicles.Data.Models;

    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> postCategory)
        {
            postCategory
                .HasMany(po => po.Posts)
                .WithOne(p => p.PostCategory)
                .HasForeignKey(p => p.PostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
