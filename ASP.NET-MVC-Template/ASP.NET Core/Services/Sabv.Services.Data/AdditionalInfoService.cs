namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Data.Contracts;
    using Sabv.Services.Models.AdditionalInfos;

    public class AdditionalInfoService : IAdditionalInfoService
    {
        private readonly IDeletableEntityRepository<AdditionalInfo> additionalInfoRepo;

        public AdditionalInfoService(IDeletableEntityRepository<AdditionalInfo> additionalInfoRepo)
        {
            this.additionalInfoRepo = additionalInfoRepo;
        }

        public async Task AddAsync(AddAdditionalInfoModel model)
        {
            var additionalInfo = new AdditionalInfo()
            {
                ABS = model.ABS,
                Airbags = model.Airbags,
                AirSuspension = model.AirSuspension,
                AllWheelDrive = model.AllWheelDrive,
                Barter = model.Barter,
                ClimateControl = model.ClimateControl,
                CreatedOn = DateTime.UtcNow,
                ElectricMirrors = model.ElectricMirrors,
                ElectricWindows = model.ElectricWindows,
                FiveDoors = model.FiveDoors,
                GPS = model.GPS,
                IsDeleted = false,
                RainSensor = model.RainSensor,
                Parktronic = model.Parktronic,
                ThreeDoors = model.ThreeDoors,
                StartStopFunction = model.StartStopFunction,
                Town = model.Town,
                TractionControl = model.TractionControl,
                Tuned = model.Tuned,
                USBAudio = model.USBAudio,
            };

            await this.additionalInfoRepo.AddAsync(additionalInfo);
            await this.additionalInfoRepo.SaveChangesAsync();
        }

        public ICollection<AdditionalInfo> GetAll()
        {
            return this.additionalInfoRepo.All().ToList();
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var additionalInfo = await this.additionalInfoRepo.GetByIdWithDeletedAsync(id);

            if (additionalInfo == null)
            {
                return false;
            }

            this.additionalInfoRepo.Delete(additionalInfo);

            return true;
        }
    }
}
