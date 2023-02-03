using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Dtos.Get.Main
{
    public class GetSellingDto
    {
        public int Id { get; set; }
        public GetProductDto Product { get; set; }
        public GetMeasureTypeDto MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public double? Price { get; set; }
        public bool IsActive { get; set; }
    }
}
