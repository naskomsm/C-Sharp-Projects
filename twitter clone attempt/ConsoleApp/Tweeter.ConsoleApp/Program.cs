namespace Tweeter.ConsoleApp
{
    using Microsoft.EntityFrameworkCore;
    using Tweeter.Data;

    public class Program
    {
        public static void Main()
        {
            using var data = new TweeterDbContext();
            data.Database.Migrate();
        }
    }
}
