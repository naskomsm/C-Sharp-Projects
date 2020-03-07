namespace Sabv.Services.Data
{
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IJsonService
    {
        Task WriteInJsonMakesAsync(Model[] models);
    }
}
