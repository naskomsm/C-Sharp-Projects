namespace PetStore.Services.Models.Pet
{
    using System;

    public class PetAddServiceModel
    {
        public DateTime BirthDate { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Gender { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }
    }
}
