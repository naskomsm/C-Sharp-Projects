namespace Sabv.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;
    using Sabv.Services.Models.MainInfos;

    public interface IMainInfoService
    {
        ICollection<MainInfo> GetAll();

        Task<string> AddAsync(AddMainInfoModel model);

        Task<bool> RemoveAsync(string id);
    }
}
