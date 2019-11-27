namespace PetStore
{
    using Data;
    using Services.Implementations;

    public class Program
    {
        public static void Main()
        {
            // Test the service
            using var data = new PetStoreDbContext();
            
            var brandService = new BrandService(data);
            
            brandService.Create("Purrina");
            
            var brandWithToys = brandService.FindByIdWithToys(1);
        }
    }
}
