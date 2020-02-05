namespace SIS.MvcFramework.Interfaces
{
    using SIS.HTTP;
    using System.Collections.Generic;

    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);

        void ConfigureServices();
    }
}
