namespace Sabv.Services.Data
{
    using Sabv.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IColorService
    {
        IEnumerable<T> GetAll<T>();

        Color GetColorByName(string name);

        IEnumerable<Color> GetAll();

        Task AddAsync(string name);
    }
}
