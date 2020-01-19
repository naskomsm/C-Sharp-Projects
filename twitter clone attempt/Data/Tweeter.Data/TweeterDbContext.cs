namespace Tweeter.Data
{
    using Tweeter.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TweeterDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Following> Followings { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DataSettings.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
