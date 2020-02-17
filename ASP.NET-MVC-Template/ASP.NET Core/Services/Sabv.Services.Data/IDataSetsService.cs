namespace Sabv.Services.Data
{
    using System.Threading.Tasks;

    using Sabv.Web.ViewModels;

    public interface IDataSetsService
    {
        Task<DataSetsViewModel> GetAllDataSets();
    }
}
