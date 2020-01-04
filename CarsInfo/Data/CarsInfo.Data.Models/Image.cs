namespace CarsInfo.Data.Models
{
    using System.Collections.Generic;

    public class Image
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
