namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Sabv.Services.Datasets.Models;

    public class SearchPageViewModel
    {
        public ICollection<string> Categories { get; set; }

        public ICollection<string> Cities { get; set; }

        public ICollection<string> Years { get; set; }

        public ICollection<string> Colors { get; set; }

        public ICollection<string> CarTypeCategories { get; set; }

        public VehicleFeatures Features { get; set; }
    }
}
