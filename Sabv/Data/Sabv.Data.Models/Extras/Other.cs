namespace Sabv.Data.Models.Extras
{

    using Sabv.Data.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Other : BaseModel<int>
    {
        public bool AllWheelDrive { get; set; }

        public bool LongBase { get; set; }

        public bool Service { get; set; }

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
