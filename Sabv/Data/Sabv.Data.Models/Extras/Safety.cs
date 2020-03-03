namespace Sabv.Data.Models.Extras
{
    using Sabv.Data.Common.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Safety : BaseModel<int>
    {
        public bool ASC { get; set; }

        public bool AFL { get; set; }

        public bool ABS { get; set; }

        public bool Airbags { get; set; }

        public bool EBD { get; set; }

        public bool ESP { get; set; }

        public bool TPMS { get; set; }

        public bool PDC { get; set; }

        public bool Isofix { get; set; }

        public bool DSA { get; set; }

        public bool ASR { get; set; }

        public bool DBS { get; set; }

        public bool Distronic { get; set; }

        public bool HDC { get; set; }

        public bool BAS { get; set; }

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
