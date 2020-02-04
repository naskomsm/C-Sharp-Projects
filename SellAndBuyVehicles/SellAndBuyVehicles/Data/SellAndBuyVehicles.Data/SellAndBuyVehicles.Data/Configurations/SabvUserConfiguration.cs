namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SellAndBuyVehicles.Data.Models;

    public class SabvUserConfiguration : IEntityTypeConfiguration<SabvUser>
    {
        public void Configure(EntityTypeBuilder<SabvUser> user)
        {
            user
                .HasMany(u => u.Posts)
                .WithOne(p => p.SabvUser)
                .HasForeignKey(p => p.SabvUserId)
                .OnDelete(DeleteBehavior.Restrict);

            user
                .HasMany(u => u.Favourites)
                .WithOne(f => f.SabvUser)
                .HasForeignKey(f => f.SabvUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
