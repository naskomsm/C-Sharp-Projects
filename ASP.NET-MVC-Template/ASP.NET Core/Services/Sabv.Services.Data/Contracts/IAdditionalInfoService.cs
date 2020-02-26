namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Data.Models.AdditionalInfoFiles;
    using Sabv.Services.Models.AdditionalInfos;

    public interface IAdditionalInfoService
    {
        ICollection<AdditionalInfo> GetAll();

        Task AddAsync(AddAdditionalInfoModel model);

        Task<bool> RemoveAsync(string id);
    }
}
