namespace Sabv.Web.ViewModels.Posts
{
    using Sabv.Services.Datasets.Models;
    using System.Collections.Generic;

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
