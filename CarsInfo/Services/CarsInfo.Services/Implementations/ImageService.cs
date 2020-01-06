namespace CarsInfo.Services.Implementations
{
    using System;
    using System.Linq;
    using CarsInfo.Data;
    using CarsInfo.Data.Models;
    using CarsInfo.Services.Models.Image;

    public class ImageService : IImageService
    {
        private readonly CarsInfoDbContext data;

        public ImageService(CarsInfoDbContext data)
        {
            this.data = data;
        }

        public void Add(ImageAddServiceModel model)
        {
            if (!DataValidation.IsValid(model))
            {
                throw new ArgumentException("Invalid data.");
            }

            var image = new Image()
            {
                ImageTitle = model.ImageTitle,
                ImageData = model.ImageData
            };

            this.data.Images.Add(image);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Images.Any(i => i.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var image = this.data.Images.FirstOrDefault(x => x.Id == id);
            this.data.Images.Remove(image);
            this.data.SaveChanges();

            return true;
        }
    }
}
