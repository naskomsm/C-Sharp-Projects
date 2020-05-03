namespace Sabv.Web.Infrastructure.Informants
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Sabv.Web.Infrastructure.Informants.Contracts;

    public static class Informant
    {
        public static List<SelectListItem> GetItems(IInformant informant)
        {
            return informant.GetItems().ToList();
        }
    }
}
