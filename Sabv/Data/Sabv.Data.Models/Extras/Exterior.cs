namespace Sabv.Data.Models.Extras
{
    using System.Collections.Generic;
    using System.Linq;

    using Sabv.Data.Common.Models;

    public class Exterior : BaseModel<int>
    {
        public bool LED { get; set; }

        public bool Rims { get; set; }

        public bool Metalic { get; set; }

        public bool FourDoors { get; set; }

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
