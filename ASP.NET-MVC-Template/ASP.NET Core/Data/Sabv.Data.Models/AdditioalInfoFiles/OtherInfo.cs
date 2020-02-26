namespace Sabv.Data.Models.AdditioalInfoFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sabv.Data.Common.Models;

    public class OtherInfo : BaseDeletableModel<string>
    {
        public OtherInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public bool AllWheelDrive { get; set; }

        public bool Barter { get; set; }

        public bool Tuned { get; set; }

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
