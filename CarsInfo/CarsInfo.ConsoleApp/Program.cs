namespace CarsInfo.ConsoleApp
{
    using CarsInfo.Data;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main()
        {
            using var data = new CarsInfoDbContext();

            data.Database.Migrate();
        }
    }
}
