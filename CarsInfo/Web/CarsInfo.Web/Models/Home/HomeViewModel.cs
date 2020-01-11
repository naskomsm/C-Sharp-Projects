namespace CarsInfo.Web.Models.Home
{
    using CarsInfo.Services.Models.Brakes;
    using CarsInfo.Services.Models.Suspension;
    using CarsInfo.Services.Models.Wheels;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<BrakesInfoServiceModel> Brakes { get; set; }

        //public CarInfoServiceModel Car { get; set; }

        //public EngineInfoServiceModel Engine { get; set; }

        public SuspensionInfoServiceModel Suspension { get; set; }

        public WheelsInfoServiceModel Wheels { get; set; }
    }
}
