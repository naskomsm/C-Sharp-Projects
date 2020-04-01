namespace Sabv.Data.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sabv.Data.Models;

    public class CommentConfiguration : IEntityTypeConfiguration<UserLikes>
    {
        public void Configure(EntityTypeBuilder<UserLikes> builder)
        {
            builder.HasKey(k => new { k.CommentId, k.UserId });

            builder
                .HasOne(ul => ul.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(ul => ul.Comment)
                .WithMany(l => l.UserLikes)
                .HasForeignKey(ul => ul.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
