namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public class YearToInformant : IInformant
    {
        public IEnumerable<SelectListItem> GetItems()
        {
            var yearsTo = new List<SelectListItem>();
            yearsTo.Add(new SelectListItem() { Text = "All", Selected = true });
            for (int i = 2021; i >= 1960; i--)
            {
                yearsTo.Add(new SelectListItem() { Text = i.ToString() });
            }

            return yearsTo;
        }
    }
}
