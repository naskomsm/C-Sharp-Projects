namespace Tweeter.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Tweeter.Data;
    using Tweeter.Data.Models;
    using Tweeter.Services.Models.Picture;

    public class PictureService : IPictureService
    {
        private readonly TweeterDbContext data;

        public PictureService(TweeterDbContext data)
        {
            this.data = data;
        }

        public void Add(PictureAddServiceModel model)
        {
            var picture = new Picture()
            {
                ImageTitle = model.ImageTitle,
                ImageData = model.ImageData
            };

            this.data.Pictures.Add(picture);
            this.data.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.data.Pictures.Any(p => p.Id == id);
        }

        public bool Remove(int id)
        {
            if (!this.Exists(id))
            {
                return false;
            }

            var picture = this.data.Pictures.FirstOrDefault(x => x.Id == id);
            this.data.Pictures.Remove(picture);
            this.data.SaveChanges();

            return true;
        }
    }
}
