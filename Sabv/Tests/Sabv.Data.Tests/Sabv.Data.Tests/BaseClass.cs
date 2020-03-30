namespace Sabv.Data.Tests
{
    using Microsoft.Extensions.Configuration;

    public class BaseClass
    {
        protected BaseClass()
        {
            this.Configuration = new ConfigurationBuilder()
                .AddJsonFile("mockappsettings.Production.json")
                .Build();
        }

        protected IConfiguration Configuration { get; set; }
    }
}
