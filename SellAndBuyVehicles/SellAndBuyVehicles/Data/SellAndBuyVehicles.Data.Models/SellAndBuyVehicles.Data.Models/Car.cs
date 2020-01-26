namespace SellAndBuyVehicles.Data.Models
{
    using SellAndBuyVehicles.Data.Models.Enums;

    public class Car : BaseVehicle
    {
        public int Id { get; set; }

        public EuroStandard EuroStandard { get; set; }
    }
}
