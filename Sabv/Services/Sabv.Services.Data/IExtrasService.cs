namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models.Extras;

    public interface IExtrasService
    {
        IEnumerable<Comfort> GetAllComforts();

        Comfort GetByIdComfort(int id);

        Task AddComfortAsync(Comfort comfort);

        IEnumerable<Exterior> GetAllExteriors();

        Exterior GetByIdExterior(int id);

        Task AddExteriorAsync(Exterior exterior);

        IEnumerable<Other> GetAllOthers();

        Other GetByIdOther(int id);

        Task AddOtherAsync(Other other);

        IEnumerable<Safety> GetAllSafeties();

        Safety GetByIdSafety(int id);

        Task AddSafetyAsync(Safety safety);
    }
}
