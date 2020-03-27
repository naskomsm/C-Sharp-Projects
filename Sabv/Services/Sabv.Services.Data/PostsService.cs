namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;
    using Sabv.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IMakesService makesService;

        public PostsService(IDeletableEntityRepository<Post> postsRepo, IMakesService makesService)
        {
            this.postsRepo = postsRepo;
            this.makesService = makesService;
        }

        public async Task AddAsync(Post postToAdd)
        {
            if (postToAdd == null)
            {
                throw new ArgumentNullException("Post cannot be null.");
            }

            await this.postsRepo.AddAsync(postToAdd);
            await this.postsRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.postsRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<Post> GetAll()
        {
            return this.postsRepo.All().OrderBy(x => x.Name).ToList();
        }

        public T GetDetails<T>(int id)
        {
            var entity = this.postsRepo.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
            if (entity == null)
            {
                throw new ArgumentNullException("Entity with given id not found.");
            }

            return entity;
        }

        public IEnumerable<T> GetLatest<T>(int postCount)
        {
            if (postCount <= 0)
            {
                throw new ArgumentNullException("Invalid post count.");
            }

            return this.postsRepo.All().OrderBy(x => x.CreatedOn).Take(postCount).To<T>().ToList();
        }

        public IEnumerable<Post> Filter(PostDetailsInputModel inputModel)
        {
            var posts = this.GetAll().ToList();

            if (inputModel.PostCategory != null && inputModel.PostCategory != "All")
            {
                posts = posts
                    .Where(x => x.Category.Name.ToString().ToLower() == inputModel.PostCategory.ToLower())
                    .ToList();
            }

            if (inputModel.Condition != null)
            {
                posts = posts
                    .Where(x => x.Condition.ToString().ToLower() == inputModel.Condition.ToLower())
                    .ToList();
            }

            if (inputModel.Make != 0)
            {
                var makeFromService = this.makesService.GetAll().FirstOrDefault(x => x.Id == inputModel.Make);

                posts = posts
                    .Where(x => x.Make.Name.ToLower() == makeFromService.Name.ToLower())
                    .ToList();
            }

            if (inputModel.Model != null && inputModel.Model != "All")
            {
                posts = posts
                    .Where(x => x.Model.Name.ToLower() == inputModel.Model.ToLower())
                    .ToList();
            }

            if (inputModel.MaxMileage != 0)
            {
                posts = posts
                    .Where(x => x.Mileage <= inputModel.MaxMileage)
                    .ToList();
            }

            if (inputModel.EngineType != null && inputModel.EngineType != "All")
            {
                posts = posts
                    .Where(x => x.EngineType.ToString().ToLower() == inputModel.EngineType.ToLower())
                    .ToList();
            }

            if (inputModel.HorsepowerFrom != 0)
            {
                    posts = posts
                        .Where(x => x.Horsepower >= inputModel.HorsepowerFrom)
                        .ToList();
            }

            if (inputModel.HorsepowerTo != 0)
            {
                    posts = posts
                        .Where(x => x.Horsepower <= inputModel.HorsepowerTo)
                        .ToList();
            }

            if (inputModel.Eurostandard != 0)
            {
                posts = posts
                    .Where(x => (int)x.Eurostandard == inputModel.Eurostandard)
                    .ToList();
            }

            if (inputModel.TransmissionType != null && inputModel.TransmissionType != "All")
            {
                posts = posts
                    .Where(x => x.TransmissionType.ToString().ToLower() == inputModel.TransmissionType.ToLower())
                    .ToList();
            }

            if (inputModel.VehicleCategory != null && inputModel.VehicleCategory != "All")
            {
                posts = posts
                    .Where(x => x.VehicleCategory.Name.ToLower() == inputModel.VehicleCategory.ToLower())
                    .ToList();
            }

            if (inputModel.PriceFrom != 0)
            {
                    posts = posts
                        .Where(x => x.Price >= inputModel.PriceFrom)
                        .ToList();
            }

            if (inputModel.PriceTo != 0)
            {
                    posts = posts
                        .Where(x => x.Price <= inputModel.PriceTo)
                        .ToList();
            }

            if (inputModel.Currency != null && inputModel.Currency != "All")
            {
                posts = posts
                    .Where(x => x.Currency.ToString().ToLower() == inputModel.Currency.ToLower())
                    .ToList();
            }

            if (inputModel.YearFrom != 0)
            {
                    var year = new DateTime(inputModel.YearFrom, 1, 1);

                    posts = posts
                        .Where(x => x.ManufactureDate >= year)
                        .ToList();
            }

            if (inputModel.YearTo != 0)
            {
                    var year = new DateTime(inputModel.YearFrom, 1, 1);
                    posts = posts
                        .Where(x => x.ManufactureDate <= year)
                        .ToList();
            }

            if (inputModel.Color != null && inputModel.Color != "All")
            {
                posts = posts
                    .Where(x => x.Color.Name.ToLower() == inputModel.Color.ToLower())
                    .ToList();
            }

            if (inputModel.Town != null && inputModel.Town != "All")
            {
                posts = posts
                    .Where(x => x.City.Name.ToLower() == inputModel.Town.ToLower())
                    .ToList();
            }

            return posts;
        }

        public int Total()
        {
            return this.postsRepo.All().Count();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = this.postsRepo.All().FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                throw new ArgumentNullException("Entity with given id cannot be found.");
            }

            this.postsRepo.Delete(entity);
            await this.postsRepo.SaveChangesAsync();
        }

        public async Task AddImageToPost(int postId, PostImage postImage)
        {
            var post = this.GetAll().FirstOrDefault(x => x.Id == postId);
            post.Images.Add(postImage);
            await this.postsRepo.SaveChangesAsync();
        }
    }
}
