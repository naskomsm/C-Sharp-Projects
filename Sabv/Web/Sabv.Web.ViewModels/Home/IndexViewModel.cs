namespace Sabv.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using Sabv.Data.Models;

    public class IndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Image> FirstThreeImages { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
