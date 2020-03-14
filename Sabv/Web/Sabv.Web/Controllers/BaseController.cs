namespace Sabv.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sabv.Web.ViewModels;
    using System.Diagnostics;

    public class BaseController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
