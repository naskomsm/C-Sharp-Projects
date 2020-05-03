namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class YearFromInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            var yearsFrom = new List<SelectListItem>();
            yearsFrom.Add(new SelectListItem() { Text = "All", Selected = true });
            for (int i = 2021; i >= 1960; i--)
            {
                yearsFrom.Add(new SelectListItem() { Text = i.ToString() });
            }

            return yearsFrom;
        }
    }
}
