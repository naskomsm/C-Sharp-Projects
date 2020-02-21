namespace Sabv.Web.ViewModels.Posts
{
    using Sabv.Data.Models;

    public class PostViewModel
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Mileage { get; set; }

        public string CreatedOn { get; set; }

        public MainInfo MainInfo { get; set; }
    }
}
