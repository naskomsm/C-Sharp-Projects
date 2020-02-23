namespace Sabv.Services.Models.Posts
{
    using System;

    public class PostDetailsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public DateTime VehicleCreatedOn { get; set; }

        public string EngineType { get; set; }

        public string TransmissionType { get; set; }

        public int HorsePower { get; set; }

        public double Mileage { get; set; }

        public string Color { get; set; }

        public string Town { get; set; }

        public bool GPS { get; set; }

        public bool ABS { get; set; }

        public bool TractionControl { get; set; }

        public bool Parktronic { get; set; }

        public bool StartStopFunction { get; set; }

        public bool AirSuspension { get; set; }

        public bool ClimateControl { get; set; }

        public bool ThreeDoors { get; set; }

        public bool FiveDoors { get; set; }

        public bool AllWheelDrive { get; set; }

        public bool Barter { get; set; }

        public bool Tuned { get; set; }

        public bool RainSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool USBAudio { get; set; }

        public bool Airbags { get; set; }
    }
}
