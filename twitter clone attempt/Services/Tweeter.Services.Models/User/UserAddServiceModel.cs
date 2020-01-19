namespace Tweeter.Services.Models.User
{
    using System;
    using Tweeter.Data.Models;

    public class UserAddServiceModel
    {
        public string Email { get; set; }

        public DateTime Joined { get; set; }

        public int? PictureId { get; set; }

        public Picture Picture { get; set; }
    }
}
