namespace Tweeter.Data.Models
{
    using System.Collections.Generic;

    public class Picture
    {
        public int Id { get; set; }

        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
