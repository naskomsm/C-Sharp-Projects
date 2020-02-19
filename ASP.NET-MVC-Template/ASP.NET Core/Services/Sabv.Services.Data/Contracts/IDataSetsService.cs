namespace Sabv.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Sabv.Services.Datasets.Models;

    public interface IDataSetsService
    {
        Task<DataSetsViewModel> GetAllDataSetsAsync();
    }
}
