namespace Tweeter.Data.Configurations
{
    using Tweeter.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TweetConfigruation : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> tweet)
        {
            tweet
                .HasOne(t => t.User)
                .WithMany(u => u.Tweets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            tweet
                .HasMany(t => t.Comments)
                .WithOne(c => c.Tweet)
                .HasForeignKey(c => c.TweetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
