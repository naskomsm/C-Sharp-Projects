namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Brakes;
    using CarsInfo.Data.Models.Enums.Brakes;

    public class BrakesService : IBrakesService
    {
        private readonly CarsInfoDbContext data;

        public BrakesService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(BrakesAddServiceModel model)
        {
            var isTypeValid = Enum.IsDefined(typeof(BrakesType), model.Type);

            if (!isTypeValid)
            {
                throw new ArgumentException("Cannot attach invalid enum to object.");
            }

            var brakes = new Brakes()
            {
                Type = model.Type,
                Used = model.Used
            };

            if(model.Image != null)
            {
                brakes.Image = model.Image;
            }

            this.data.Brakes.Add(brakes);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Brakes.Any(b => b.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var brakes = this.data.Brakes.FirstOrDefault(x => x.Id == id);
            this.data.Brakes.Remove(brakes);

            return true;
        }
    }
}
