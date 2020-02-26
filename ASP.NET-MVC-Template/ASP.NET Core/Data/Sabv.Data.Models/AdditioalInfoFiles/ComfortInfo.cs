namespace Sabv.Data.Models.AdditioalInfoFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sabv.Data.Common.Models;

    public class ComfortInfo : BaseDeletableModel<string>
    {
        public ComfortInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public bool StartStopFunction { get; set; }

        public bool AirSuspension { get; set; }

        public bool ClimateControl { get; set; }

        public bool RainSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool USBAudio { get; set; }

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
