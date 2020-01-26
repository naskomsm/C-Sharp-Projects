namespace SellAndBuyVehicles.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class SabvUser : IdentityUser
    {
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<Post> Favourites { get; set; } = new HashSet<Post>();
    }
}
