namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Suspension;

    public interface ISuspensionService
    {
        bool Exists(int id);

        void Add(SuspensionAddServiceModel model);

        bool Remove(int id);
    }
}
