using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Sabv.Web.Areas.Identity.IdentityHostingStartup))]

namespace Sabv.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
