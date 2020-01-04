namespace CarsInfo.Data
{
    using CarsInfo.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarsInfoDbContext : DbContext
    {
        public DbSet<Brakes> Brakes { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cylinders> Cylinders { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Image> Images { get; set; }

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
