namespace Tweeter.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tweeter.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user
                .HasOne(u => u.Picture)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PictureId)
                .OnDelete(DeleteBehavior.Restrict);

            user
                .HasMany(u => u.Tweets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            user
               .HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
