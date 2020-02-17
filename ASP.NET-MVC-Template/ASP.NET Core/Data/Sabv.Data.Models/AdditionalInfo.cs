namespace Sabv.Data.Models
{
    using System;

    using Sabv.Data.Common.Models;

    public class AdditionalInfo : BaseModel<string>
    {
        public AdditionalInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

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
