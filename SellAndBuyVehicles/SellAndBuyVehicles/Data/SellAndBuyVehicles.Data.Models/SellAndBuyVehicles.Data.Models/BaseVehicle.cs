namespace SellAndBuyVehicles.Data.Models
{
    using SellAndBuyVehicles.Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;
    using static DataValidation.BaseClass;

    public abstract class BaseVehicle
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public bool IsUsed { get; set; }

        [Required]
        public DateTime ManufactureDate { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        [Required]
        [Range(MinHorsePower, MaxHorsePower)]
        public int HorsePower { get; set; }

        [Required]
        public TransimisionType TransimisionType { get; set; }

        [Required]
        [Range(MinMileage, MaxMileage)]
        public int Mileage { get; set; }

        [Required]
        [MinLength(MinColorLength)]
        [MaxLength(MaxColorLength)]
        public string Color { get; set; }

        public int VehicleCategoryId { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
