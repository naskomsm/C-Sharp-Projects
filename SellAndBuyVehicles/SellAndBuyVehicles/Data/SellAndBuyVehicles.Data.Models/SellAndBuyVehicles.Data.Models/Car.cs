namespace SellAndBuyVehicles.Data.Models
{
    using SellAndBuyVehicles.Data.Models.Enums;
    using SellAndBuyVehicles.Data.Models.BaseModels;

    public class Car : BaseVehicle
    {
        public int Id { get; set; }

        public EuroStandard EuroStandard { get; set; }
    }
}
