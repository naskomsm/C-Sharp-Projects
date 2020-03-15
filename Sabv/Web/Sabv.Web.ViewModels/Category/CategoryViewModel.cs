namespace Sabv.Web.ViewModels.Category
{
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public Image Image { get; set; }

        public string Description { get; set; }
    }
}
