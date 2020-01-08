namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Brakes;
    using System.Collections.Generic;

    public interface IBrakesService
    {
        bool Exists(int id);

        void Add(BrakesAddServiceModel model);

        bool Remove(int id);

        int Total();

        IEnumerable<BrakesListingServiceModel> All(int page = 1);

        BrakesInfoServiceModel BrakesInfo(int id);
    }
}
