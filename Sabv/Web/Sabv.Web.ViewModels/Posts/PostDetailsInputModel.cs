namespace Sabv.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Sabv.Common;

    public class PostDetailsInputModel
    {
        public string PostCategory { get; set; }

        public string Condition { get; set; }

        public int Make { get; set; }

        public string Model { get; set; }

        [Range(GlobalConstants.Post.MinMileage, double.MaxValue)]
        public int MaxMileage { get; set; }

        public string EngineType { get; set; }

        [Range(GlobalConstants.Post.MinHorsepower, GlobalConstants.Post.MaxHorsepower)]
        public int HorsepowerFrom { get; set; }

        [Range(GlobalConstants.Post.MinHorsepower, GlobalConstants.Post.MaxHorsepower)]
        public int HorsepowerTo { get; set; }

        public int Eurostandard { get; set; }

        public string TransmissionType { get; set; }

        public string VehicleCategory { get; set; }

        [Range(GlobalConstants.Post.MinPrice, GlobalConstants.Post.MaxPrice)]
        public decimal PriceFrom { get; set; }

        [Range(GlobalConstants.Post.MinPrice, GlobalConstants.Post.MaxPrice)]
        public decimal PriceTo { get; set; }

        public string Currency { get; set; }

        public int YearFrom { get; set; }

        public int YearTo { get; set; }

        public string Color { get; set; }

        public string Town { get; set; }
    }
}
