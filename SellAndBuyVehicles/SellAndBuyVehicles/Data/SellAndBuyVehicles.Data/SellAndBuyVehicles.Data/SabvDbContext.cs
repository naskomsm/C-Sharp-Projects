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

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
