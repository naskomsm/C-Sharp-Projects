namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Wheels;

    public interface IWheelsService
    {
        bool Exists(int id);

        void Add(WheelsAddServiceModel model);

        bool Remove(int id);
    }
}
