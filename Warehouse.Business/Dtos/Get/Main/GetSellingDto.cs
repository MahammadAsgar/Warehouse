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
        public GetProductNameDto Product { get; set; }
        public GetMeasureTypeNameDto MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public double? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime SellingDate { get; set; }
    }
}
