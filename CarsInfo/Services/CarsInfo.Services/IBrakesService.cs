namespace CarsInfo.Services
{
    using CarsInfo.Services.Models.Brakes;

    public interface IBrakesService
    {
        bool Exists(int id);

        void Add(BrakesAddServiceModel model);

        bool Remove(int id);
    }
}
