namespace CarsInfo.Services.Models.Car
{
    using CarsInfo.Data.Models.Enums.Car;
    using System.ComponentModel.DataAnnotations;
    using static Data.Models.DataValidation.Car;
    using Image = Data.Models.Image;
    using CarsInfo.Data.Models;

    public class CarAddServiceModel
    {
        [Required]
        [MaxLength(BrandLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelLength)]
        public string Model { get; set; }

        [Required]
        [Range(20000, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(GenerationLength)]
        public string Generation { get; set; }

        [Required]
        [MaxLength(ColorLength)]
        public string Color { get; set; }

        [Required]
        [Range(MinimumYear, MaximumYear)]
        public int YearStart { get; set; }

        public int? YearEnd { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public int Doors { get; set; }

        // In MM
        [Required]
        [Range(0, MaximumLength)]
        public double Length { get; set; }

        [Required]
        [Range(0, MaximumWidth)]
        public double Width { get; set; }

        [Required]
        [Range(0, MaximumHeight)]
        public double Height { get; set; }

        // Combined
        public double FuelConsumption { get; set; }

        [Required]
        [Range(800, MaximumWeight)]
        public double Weight { get; set; }

        [Required]
        [Range(500, MaximumMaxWeight)]
        public double MaxWeight { get; set; }

        // EURO
        public EmissionStandard EmissionStandard { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public int EngineId { get; set; }

        public Engine Engine { get; set; }

        [Required]
        public int BrakesId { get; set; }

        public Brakes Brakes { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        [Required]
        public bool ABS { get; set; }

        [Required]
        public WheelDrive WheelDrive { get; set; }

        [Required]
        public int WheelsId { get; set; }

        public Wheels Wheels { get; set; }

        [Required]
        public int SuspensionId { get; set; }

        public Suspension Suspension { get; set; }
    }
}
