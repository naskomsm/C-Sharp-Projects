namespace Sabv.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Common.Models;
    using Sabv.Data.Models.Enums;

    public class MainInfo : BaseModel<string>
    {
        public MainInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public DateTime VehicleCreatedOn { get; set; }

        [Required]
        public EngineType EngineType { get; set; }

        [Required]
        public TransmissionType TransmissionType { get; set; }

        [Required]
        [Range(DataValidation.Post.MinHorsePower, DataValidation.Post.MaxHorsePower)]
        public int HorsePower { get; set; }

        [Required]
        [Range(DataValidation.Post.MinMileage, DataValidation.Post.MaxMileage)]
        public double Mileage { get; set; }

        [Required]
        [MaxLength(DataValidation.Post.MaxColorLength)]
        public string Color { get; set; }
    }
}
