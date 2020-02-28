namespace Sabv.Services.Datasets.Models
{
    using System.Collections.Generic;

    public class DataSetsViewModel
    {
        public ICollection<string> Categories { get; set; }

        public ICollection<string> Cities { get; set; }

        public ICollection<string> Years { get; set; }

        public ICollection<string> Colors { get; set; }

        public VehicleFeatures Features { get; set; }

        public ICollection<string> CarTypeCategories { get; set; }
    }
}
