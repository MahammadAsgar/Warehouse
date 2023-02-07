using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Buying:EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MeasureTypeId { get; set; }
        public MeasureType MeasureType { get; set; }
        public double? UnitOfMeasure { get; set; }
        public double? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime BuyingDate { get; set; }
    }
}
