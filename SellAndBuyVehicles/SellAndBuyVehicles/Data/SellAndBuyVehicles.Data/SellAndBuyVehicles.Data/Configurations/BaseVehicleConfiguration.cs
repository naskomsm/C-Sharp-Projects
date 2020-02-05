namespace SellAndBuyVehicles.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SellAndBuyVehicles.Data.Models.BaseModels;

    public class BaseVehicleConfiguration : IEntityTypeConfiguration<BaseVehicle>
    {
        public void Configure(EntityTypeBuilder<BaseVehicle> baseVehicle)
        {
            baseVehicle
                .HasOne(bv => bv.VehicleCategory)
                .WithMany(vc => vc.Vehicles)
                .HasForeignKey(bv => bv.VehicleCategoryId);
        }
    }
}
