using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Lenght { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public bool IsActive { get; set; }
        public GetCategoryNameDto Category { get; set; }
        public IEnumerable<GetProductFileDto> ProductFiles { get; set; }
    }
}
