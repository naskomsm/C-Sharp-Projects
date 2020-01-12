namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Engine;
    using System.Collections.Generic;

    public interface IEngineService
    {
        bool Exists(int id);

        void Add(EngineAddServiceModel model);

        bool Remove(int id);

        int Total();

        IEnumerable<EngineListingServiceModel> All(int page = 1);

        IEnumerable<EngineInfoServiceModel> AllInfo();

        EngineInfoServiceModel EngineInfo(int id);
    }
}
