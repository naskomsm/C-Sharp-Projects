namespace Sabv.Web.ViewModels.Posts
{

    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;

    public class CheckTextViewModel
    {
        public string PostCategory { get; set; }

        public string PhoneNumber { get; set; }

        public MainInfo MainInfo { get; set; }

        public string Email { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        public string CarCategory { get; set; }

        public string Town { get; set; }
    }
}
