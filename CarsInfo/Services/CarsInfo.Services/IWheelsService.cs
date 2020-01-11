namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Wheels;
    using System.Collections.Generic;

    public interface IWheelsService
    {
        bool Exists(int id);

        void Add(WheelsAddServiceModel model);

        bool Remove(int id);

        int Total();

        IEnumerable<WheelsListingServiceModel> All(int page = 1);

        IEnumerable<WheelsInfoServiceModel> AllInfo();

        WheelsInfoServiceModel WheelsInfo(int id);
    }
}
