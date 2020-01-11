namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Suspension;
    using System.Collections.Generic;

    public interface ISuspensionService
    {
        bool Exists(int id);

        void Add(SuspensionAddServiceModel model);

        bool Remove(int id);

        int Total();

        IEnumerable<SuspensionListingServiceModel> All(int page = 1);

        IEnumerable<SuspensionInfoServiceModel> AllInfo();

        SuspensionInfoServiceModel SuspensionInfo(int id);
    }
}
