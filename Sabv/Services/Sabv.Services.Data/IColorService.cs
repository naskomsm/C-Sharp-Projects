namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IColorService
    {
        IEnumerable<T> GetAll<T>();

        Color GetColorByName(string name);

        IEnumerable<T> GetAllAsNoTracking<T>();

        Task AddAsync(string name);
    }
}
