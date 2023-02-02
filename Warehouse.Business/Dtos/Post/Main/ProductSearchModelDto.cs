using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Post.Main
{
    public class ProductSearchModelDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CategoryTitle { get; set; }
        public string? MeatureTypeTitle { get; set; }
        public double? Volume { get; set; }
        public double? Weight { get; set; }
    }
}
