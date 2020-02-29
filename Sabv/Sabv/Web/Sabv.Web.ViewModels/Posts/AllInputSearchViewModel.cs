namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Sabv.Data.Models;

    public class AllInputSearchViewModel
    {
        public string PostCategory { get; set; }

        public string Make { get; set; }

        public string Condition { get; set; }

        public string Model { get; set; }

        public string MaxMileage { get; set; }

        public string EngineType { get; set; }

        [Range(DataValidation.Post.MinHorsePower, DataValidation.Post.MaxHorsePower)]
        public string HorsePowerFrom { get; set; }

        [Range(DataValidation.Post.MinHorsePower, DataValidation.Post.MaxHorsePower)]
        public string HorsePowerTo { get; set; }

        public string EuroStandard { get; set; }

        public string TransmissionType { get; set; }

        public string CarCategory { get; set; }

        [Range(DataValidation.Post.MinPrice, DataValidation.Post.MaxPrice)]
        public string PriceFrom { get; set; }

        [Range(DataValidation.Post.MinPrice, DataValidation.Post.MaxPrice)]
        public string PriceTo { get; set; }

        public string Currency { get; set; }

        public string YearFrom { get; set; }

        public string YearTo { get; set; }

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

        public IEnumerable<string> GetAllTrueProperties
        {
            get
            {
                return this.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(bool) && (bool)p.GetValue(this, null))
                    .Select(p => p.Name);
            }
        }
    }
}
