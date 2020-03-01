namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Data.Models.Enums;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.MainInfos;

    public class MainInfoService : IMainInfoService
    {
        private readonly IDeletableEntityRepository<MainInfo> mainInfoRepo;

        public MainInfoService(IDeletableEntityRepository<MainInfo> mainInfoRepo)
        {
            this.mainInfoRepo = mainInfoRepo;
        }

        public async Task<string> AddAsync(AddMainInfoModel model)
        {
            var mainInfo = new MainInfo()
            {
                Color = model.Color,
                EngineType = (EngineType)model.EngineType,
                HorsePower = model.Horsepower,
                Mileage = model.Mileage,
                TransmissionType = (TransmissionType)model.TransmissionType,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EuroStandard = (EuroStandard)model.EuroStandard,
                VehicleCreatedOn = model.VehicleCreatedOn,
            };

            await this.mainInfoRepo.AddAsync(mainInfo);
            await this.mainInfoRepo.SaveChangesAsync();

            return mainInfo.Id;
        }

        public ICollection<MainInfo> GetAll()
        {
            return this.mainInfoRepo.All().ToList();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var mainInfo = await this.mainInfoRepo.GetByIdWithDeletedAsync(id);

            if (mainInfo == null)
            {
                return false;
            }

            this.mainInfoRepo.Delete(mainInfo);
            return true;
        }
    }
}
