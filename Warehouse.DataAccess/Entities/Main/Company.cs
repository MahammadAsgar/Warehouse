using Warehouse.DataAccess.Entities.Base;

namespace Warehouse.DataAccess.Entities.Main
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Selling> Sellings { get; set; }
        public ICollection<Buying> Buyings { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
