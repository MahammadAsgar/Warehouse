using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class MeasuredProduct : EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MeasureTypeId { get; set; }
        public MeasureType MeasureType { get; set; }
    }
}
