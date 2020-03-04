namespace Sabv.Data.Models.Extras
{

    using Sabv.Data.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Comfort : BaseModel<int>
    {
        public bool ASS { get; set; }

        public bool Bluetooth { get; set; }

        public bool DVD { get; set; }

        public bool Steptronic { get; set; }

        public bool USB { get; set; }

        public bool Airmatic { get; set; }

        public bool Keyless { get; set; }

        public bool BordComputer { get; set; }

        public bool LightSensor { get; set; }

        public bool ElectricMirrors { get; set; }

        public bool ElectricWindows { get; set; }

        public bool EPS { get; set; }

        public bool Navigation { get; set; }

        public bool SeatHeat { get; set; }

        public bool ACC { get; set; }

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
