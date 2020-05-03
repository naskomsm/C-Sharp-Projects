namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class TransmissionTypeInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "All", Selected = true },
                new SelectListItem() { Text = "Manual", Value = "Manual" },
                new SelectListItem() { Text = "Automatic", Value = "Automatic" },
            };
        }
    }
}
