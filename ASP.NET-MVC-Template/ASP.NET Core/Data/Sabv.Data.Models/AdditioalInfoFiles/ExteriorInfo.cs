namespace Sabv.Data.Models.AdditioalInfoFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sabv.Data.Common.Models;

    public class ExteriorInfo : BaseDeletableModel<string>
    {
        public ExteriorInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public bool ThreeDoors { get; set; }

        public bool FiveDoors { get; set; }

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
