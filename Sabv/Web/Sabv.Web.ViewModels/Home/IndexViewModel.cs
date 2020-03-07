namespace Sabv.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<PostIndexViewModel> Posts { get; set; }
    }
}
