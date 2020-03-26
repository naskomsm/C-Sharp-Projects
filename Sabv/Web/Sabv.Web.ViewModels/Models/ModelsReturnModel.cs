namespace Sabv.Web.ViewModels.Models
{
    using Sabv.Data.Models;
    using Sabv.Services.Mapping;

    public class ModelsReturnModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }
    }
}
