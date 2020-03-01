namespace Sabv.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Sabv.Data.Models.Enums;

    public class CheckTextInputModel
    {
        [Required]
        public string PostCategory { get; set; }

        [Required]
        public string Make { get; set; }

        public Condition Condition { get; set; }

        [Required]
        public string Model { get; set; }

        public string Modification { get; set; }

        public double Mileage { get; set; }

        public EngineType EngineType { get; set; }

        public int HorsePower { get; set; }

        public EuroStandard EuroStandard { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string CarCategory { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        public string Color { get; set; }

        public string Town { get; set; }

        // Comfort
        public bool StartStopFunction { get; set; }

        public bool AirSuspension { get; set; }

        public bool ClimateControl { get; set; }

        public bool RainSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool USBAudio { get; set; }

        // Exterior
        public bool ThreeDoors { get; set; }

        public bool FiveDoors { get; set; }

        // Other
        public bool AllWheelDrive { get; set; }

        public bool Barter { get; set; }

        public bool Tuned { get; set; }

        // Safety
        public bool GPS { get; set; }

        public bool ABS { get; set; }

        public bool TractionControl { get; set; }

        public bool Parktronic { get; set; }

        public bool Airbags { get; set; }

        public string Description { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }
    }
}
