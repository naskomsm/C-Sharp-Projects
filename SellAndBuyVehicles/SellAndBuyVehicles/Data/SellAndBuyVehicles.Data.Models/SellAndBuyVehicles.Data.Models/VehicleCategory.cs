namespace SellAndBuyVehicles.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.VehicleCategory;

    public class VehicleCategory
    {
        public int Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        ICollection<BaseVehicle> Vehicles { get; set; } = new HashSet<BaseVehicle>();
    }
}
