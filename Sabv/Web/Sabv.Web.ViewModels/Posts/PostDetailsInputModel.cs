namespace Sabv.Web.ViewModels.Posts
{
    public class PostDetailsInputModel 
    {
        public string PostCategory { get; set; }

        public string Condition { get; set; }

        public int Make { get; set; }

        public string Model { get; set; }

        public int MaxMileage { get; set; }

        public string EngineType { get; set; }

        public int HorsepowerFrom { get; set; }

        public int HorsepowerTo { get; set; }

        public int Eurostandard { get; set; }

        public string TransmissionType { get; set; }

        public string VehicleCategory { get; set; }

        public decimal PriceFrom { get; set; }

        public decimal PriceTo { get; set; }

        public string Currency { get; set; }

        public int YearFrom { get; set; }

        public int YearTo { get; set; }

        public string Color { get; set; }

        public string Town { get; set; }
    }
}
