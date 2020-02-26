namespace Sabv.Data.Models.AdditioalInfoFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sabv.Data.Common.Models;

    public class SafetyInfo : BaseDeletableModel<string>
    {
        public SafetyInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

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
