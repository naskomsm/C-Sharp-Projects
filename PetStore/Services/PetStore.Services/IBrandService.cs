namespace PetStore.Services
{
    using Models.Brand;
    using System.Collections.Generic;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> All(int page = 1);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandInfoLIstingServiceModel Info(int id);

        int GetIdByName(string name);

        void Add(string name);

        BrandDeleteServiceModel GetBrandById(int id);

        bool Delete(int id);
    }
}
