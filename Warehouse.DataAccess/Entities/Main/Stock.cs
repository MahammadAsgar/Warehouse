using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Stock : EntityBase
    {
        public int MeasuredProductId { get; set; }
        public MeasuredProduct MeasuredProduct { get; set; }
        public double? UnitOfMeasure { get; set; }
        public bool IsActive { get; set; }
    }
}
