namespace Sabv.Data.Models
{
    using Sabv.Data.Common.Models;
    using Sabv.Services.Mapping;

    public class City : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
