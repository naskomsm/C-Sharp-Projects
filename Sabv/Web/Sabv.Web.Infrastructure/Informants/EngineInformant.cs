namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class EngineInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Petrol", Value = "Petrol" },
                new SelectListItem() { Text = "Disel", Value = "Disel" },
                new SelectListItem() { Text = "Electric", Value = "Electric" },
                new SelectListItem() { Text = "Hybrid", Value = "Hybrid" },
            };
        }
    }
}
