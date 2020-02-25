namespace Sabv.Web.ViewModels.Posts
{
    using Sabv.Data.Models;

    public class DetailsViewModel
    {
        public string Id { get; set; }

        public MainInfo MainInfo { get; set; }

        public AdditionalInfo AdditionalInfo { get; set; }

        public string Name { get; set; }

        public string VehicleCategory { get; set; }

        public string PostCategory { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public string UserImageUrl { get; set; }
    }
}
