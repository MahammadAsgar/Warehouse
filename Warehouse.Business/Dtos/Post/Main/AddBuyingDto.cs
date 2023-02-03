using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.Business.Dtos.Post.Main
{
    public class AddBuyingDto
    {
        public int ProductId { get; set; }
        public int MeasureTypeId { get; set; }
        public double? UnitOfMeasure { get; set; }
        public double? Price { get; set; }
    }
}
