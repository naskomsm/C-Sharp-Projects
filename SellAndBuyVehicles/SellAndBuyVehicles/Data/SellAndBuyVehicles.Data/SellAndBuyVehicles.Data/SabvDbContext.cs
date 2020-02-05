namespace SellAndBuyVehicles.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SellAndBuyVehicles.Data.Models;

    public class SabvDbContext : IdentityDbContext<SabvUser>
    {
        public SabvDbContext(DbContextOptions<SabvDbContext> options)
          : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<SabvUser> SabvUsers { get; set; }

        public DbSet<VehicleCategory> VehicleCategories { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

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
