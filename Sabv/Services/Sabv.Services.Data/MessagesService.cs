namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> messagesRepo;

        public MessagesService(IDeletableEntityRepository<Message> messagesRepo)
        {
            this.messagesRepo = messagesRepo;
        }

        public async Task AddAsync(string content, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException("Message content cannot be null or empty.");
            }

            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            await this.messagesRepo.AddAsync(new Message()
            {
                Content = content,
                User = user,
                UserId = user.Id,
            });

            await this.messagesRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = this.messagesRepo.All().FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new ArgumentNullException("Entity with given id not found.");
            }

            this.messagesRepo.Delete(entity);
            await this.messagesRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.messagesRepo.All().To<T>().ToList();
        }

        public IEnumerable<Message> GetAll()
        {
            return this.messagesRepo.All().ToList();
        }
    }
}
