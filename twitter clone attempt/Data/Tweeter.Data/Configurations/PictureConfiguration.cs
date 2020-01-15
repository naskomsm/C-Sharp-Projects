namespace Tweeter.Data.Configurations
{
    using Tweeter.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> picture)
        {
            picture
                .HasMany(p => p.Users)
                .WithOne(u => u.Picture)
                .HasForeignKey(u => u.PictureId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
