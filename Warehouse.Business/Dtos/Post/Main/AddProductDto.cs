using Microsoft.AspNetCore.Http;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.Business.Dtos.Post.Main
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Lenght { get; set; }
        public double? Volume { get; set; }
        public double? Weight { get; set; }
        public int? CategoryId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
