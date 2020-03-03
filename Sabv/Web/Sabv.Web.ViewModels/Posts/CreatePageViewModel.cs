namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Extras;
    using Sabv.Data.Models.Makes;

    public class CreatePageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Make> Makes { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public Comfort Comfort { get; set; }

        public Safety Safety { get; set; }

        public Other Other { get; set; }

        public Exterior Exterior { get; set; }

        public IEnumerable<VehicleCategory> VehicleCategories { get; set; }

        public ICollection<string> Months { get; set; }

        public ICollection<string> Colors { get; set; }
    }
}
