using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class ProductPrice : EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double? Price { get; set; }
    }
}
