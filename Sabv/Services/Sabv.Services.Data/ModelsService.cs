﻿namespace Sabv.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Sabv.Data.Common.Repositories;
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class ModelsService : IModelsService
    {
        private readonly IDeletableEntityRepository<Model> modelsRepo;

        public ModelsService(IDeletableEntityRepository<Model> modelsRepo)
        {
            this.modelsRepo = modelsRepo;
        }

        public async Task AddAsync(string name, Make make)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            if (make == null)
            {
                throw new ArgumentNullException("Make cannot be null.");
            }

            await this.modelsRepo.AddAsync(new Model()
            {
                Name = name,
                Make = make,
                MakeId = make.Id,
            });

            await this.modelsRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.modelsRepo.All().OrderBy(x => x.Name).To<T>().ToList();
        }

        public IEnumerable<Model> GetAll()
        {
            return this.modelsRepo.All().OrderBy(x => x.Name).ToList();
        }

        public Model GetModelByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty.");
            }

            return this.modelsRepo.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
