namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Engine;

    public interface IEngineService
    {
        bool Exists(int id);

        void Add(EngineAddServiceModel model);

        bool Remove(int id);
    }
}
