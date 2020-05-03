namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class CurrencyInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "LV", Value = "LV" },
                new SelectListItem() { Text = "USD", Value = "USD" },
                new SelectListItem() { Text = "EUR", Value = "EUR" },
            };
        }
    }
}
