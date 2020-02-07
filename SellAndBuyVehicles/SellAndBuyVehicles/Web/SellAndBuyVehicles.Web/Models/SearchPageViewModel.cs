namespace SellAndBuyVehicles.Web.Models
{
    public class SearchPageViewModel
    {
        public string[] Categories { get; set; }

        public string[] Cities { get; set; }

        public string[] Makes { get; set; }

        public string[] Years { get; set; }

        public string[] Colors { get; set; }

        public string[] CarTypeCategory { get; set; }

        public CarFeatures Features { get; set; }
    }
}
