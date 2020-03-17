namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface IMessagesService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<Message> GetAll();

        Task AddAsync(string content, ApplicationUser user);

        Task DeleteAsync(int id);
    }
}
