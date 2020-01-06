namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Data.Models.Enums.Suspension;
    using CarsInfo.Services.Models.Suspension;

    public class SuspensionService : ISuspensionService
    {
        private readonly CarsInfoDbContext data;

        public SuspensionService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(SuspensionAddServiceModel model)
        {
            var isTypeValid = Enum.IsDefined(typeof(SuspensionType), model.Type);

            if (!isTypeValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            var suspension = new Suspension()
            {
                Type = model.Type,
                CarBrandMadeFor = model.CarBrandMadeFor,
                CategoryId = model.CategoryId,
                Category = model.Category,
                ImageId = model.ImageId,
                Image = model.Image
            };

            this.data.Suspensions.Add(suspension);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Suspensions.Any(s => s.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var suspension = this.data.Suspensions.FirstOrDefault(x => x.Id == id);
            this.data.Suspensions.Remove(suspension);
            this.data.SaveChanges();

            return true;
        }
    }
}
