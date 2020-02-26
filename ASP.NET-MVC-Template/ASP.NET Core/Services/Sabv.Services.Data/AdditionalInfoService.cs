namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Data.Models.AdditioalInfoFiles;
    using Sabv.Data.Models.AdditionalInfoFiles;
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
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                Town = model.Town,
                ComfortInfo = new ComfortInfo
                {
                    AirSuspension = model.AirSuspension,
                    ClimateControl = model.ClimateControl,
                    ElectricMirrors = model.ElectricMirrors,
                    ElectricWindows = model.ElectricWindows,
                    RainSensor = model.RainSensor,
                    StartStopFunction = model.StartStopFunction,
                    USBAudio = model.USBAudio,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                },
                ExteriorInfo = new ExteriorInfo
                {
                    FiveDoors = model.FiveDoors,
                    ThreeDoors = model.ThreeDoors,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                },
                OtherInfo = new OtherInfo
                {
                    AllWheelDrive = model.AllWheelDrive,
                    Barter = model.Barter,
                    Tuned = model.Tuned,
                    IsDeleted = false,
                },
                SafetyInfo = new SafetyInfo
                {
                    ABS = model.ABS,
                    GPS = model.GPS,
                    Parktronic = model.Parktronic,
                    TractionControl = model.TractionControl,
                    Airbags = model.Airbags,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                },
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
