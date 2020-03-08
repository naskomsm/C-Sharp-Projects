namespace Sabv.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class CreatePageViewModel
    {
        public ICollection<Category> Categories { get; set; }

        public ICollection<Make> Makes { get; set; }

        public ICollection<VehicleCategory> VehicleCategories { get; set; }

        public ICollection<Color> Colors { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
