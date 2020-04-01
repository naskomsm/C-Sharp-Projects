namespace Sabv.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sabv.Data.Models;

    public interface ICommentsService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<Comment> GetAll();

        Task<int> AddAsync(string content, ApplicationUser user, Post post);

        Task Like(int commentId, ApplicationUser user);

        Task DeleteAsync(int id);
    }
}
