namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Car;
    using System.Collections.Generic;

    public interface ICarService
    {
        bool Exists(int id);

        void Add(CarAddServiceModel model);

        bool Remove(int id);

        int Total();

        IEnumerable<CarListingServiceModel> All(int page = 1);

        IEnumerable<CarInfoServiceModel> AllInfo();

        CarInfoServiceModel CarInfo(int id);
    }
}
