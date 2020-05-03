namespace Sabv.Web.Infrastructure.Informants.Contracts
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IInformant
    {
        IEnumerable<SelectListItem> GetItems();
    }
}
