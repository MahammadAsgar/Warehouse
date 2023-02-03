using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Stock:EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MeasureTypeId { get; set; }
        public MeasureType MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
    }
}
