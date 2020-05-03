namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class EurostandardInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Euro 1", Value = "1" },
                new SelectListItem() { Text = "Euro 2", Value = "2" },
                new SelectListItem() { Text = "Euro 3", Value = "3" },
                new SelectListItem() { Text = "Euro 4", Value = "4" },
                new SelectListItem() { Text = "Euro 5", Value = "5" },
                new SelectListItem() { Text = "Euro 6", Value = "6" },
            };
        }
    }
}
