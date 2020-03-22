namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IColorService
    {
        IEnumerable<T> GetAll<T>();

        Color GetColorByName(string name);

        IEnumerable<Color> GetAll();

        Task AddAsync(string name);
    }
}
