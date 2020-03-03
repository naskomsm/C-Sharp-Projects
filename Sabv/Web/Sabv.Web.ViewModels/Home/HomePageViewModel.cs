namespace Sabv.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Sabv.Data.Models.Categories;
    using Sabv.Data.Models.Cities;
    using Sabv.Data.Models.Makes;
    using Sabv.Data.Models.Posts;

    public class HomePageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<City> Cities { get; set; }

        public IEnumerable<Make> Makes { get; set; }

        public IEnumerable<Post> LatestPosts { get; set; }
    }
}
