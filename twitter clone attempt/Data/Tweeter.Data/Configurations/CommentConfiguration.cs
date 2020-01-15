namespace Tweeter.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tweeter.Data.Models;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            comment
                .HasOne(c => c.Tweet)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TweetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
