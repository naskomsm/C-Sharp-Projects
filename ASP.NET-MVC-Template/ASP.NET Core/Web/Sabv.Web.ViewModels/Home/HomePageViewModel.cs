namespace Sabv.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public ICollection<string> Categories { get; set; }

        public ICollection<string> Cities { get; set; }

        public ICollection<string> Years { get; set; }
    }
}
